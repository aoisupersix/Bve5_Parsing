const fs = require('fs');
const linq = require('linq');
const stripBom = require('strip-bom');
const mustache = require('mustache');

const jsonData = loadJson("./map_grammar_syntax.json");

// Ast生成
const astTemp = loadFile("./map_grammar_ast.mst");
parse(astTemp, jsonData, "../Bve5_Parsing/MapGrammar/AutoGen/SyntaxNodes.cs");

// Statement生成
const stateTemp = loadFile("./map_grammar_statements.mst");
parse(stateTemp, jsonData, "../Bve5_Parsing/MapGrammar/AutoGen/Statements.cs");

// AstVisitor生成
const astVisitorTemp = loadFile("./map_grammar_ast_visitor.mst");
parse(astVisitorTemp, jsonData, "../Bve5_Parsing/MapGrammar/AutoGen/AstVisitor.cs");

// 構文名定義生成
const enumTemp = loadFile("./map_grammar_enum.mst");
parse(enumTemp, jsonData, "../Bve5_Parsing/MapGrammar/AutoGen/MapSyntaxDefinitions.cs");

// 構文テスト生成
const testTemp = loadFile("./map_grammar_test.mst");
parse(testTemp, jsonData, "../Bve5_ParsingTests/AutoGen/MapGrammarSyntaxTests.cs");

console.log("all completed !");

function loadJson(jsonPath) {
  const json = JSON.parse(loadFile(jsonPath));
  let elems = [];
  let subElems = [];
  let funcs = [];
  //Jsonの前処理
  json.states.forEach(state => {
    // 構文種別の判定
    if (state.key === undefined) {
      state["syntax1"] = true;
      state["syntax2"] = false;
      state["syntax3"] = false;
    }else if(state.sub_elem === undefined) {
      state["syntax1"] = false;
      state["syntax2"] = true;
      state["syntax3"] = false;
    }else {
      state["syntax1"] = false;
      state["syntax2"] = false;
      state["syntax3"] = true;
    }

    // テスト用に構文が取りうる引数の全パターンを作成
    // 引数は必ず指定順に並んでいることとする
    const argPattern = []
    const nonOptArgs = linq.from(state.args).where(a => !a.opt).toArray();
    const optArgs = linq.from(state.args).where(a => a.opt).toArray();
    argPattern.push(deepCopy(nonOptArgs));

    while(optArgs.length > 0) {
      nonOptArgs.push(optArgs.shift());
      argPattern.push(deepCopy(nonOptArgs));
    }
    argPattern.forEach((val) => {
      if (val.length <= 0) {
        val["noarg"] = true;
      }else {
        val.forEach((a) => {
          a.name = (a.name + '').toLowerCase();
        });
        val.slice(-1)[0]["last"] = true;
      }
    });
    state["argPattern"] = argPattern;

    // 引数があるか
    if (state.args.length <= 0) {
      state["noarg"] = true;
    }else {
      state.args.slice(-1)[0]["last"] = true;
    }

    // マップ要素名取得
    if (linq.from(elems).all(e => e["name"] != state.elem)) {
      elems.push({name: state.elem});
    }

    // サブ要素名取得
    if (state.syntax3 && linq.from(subElems).all(e => e["name"] != state.sub_elem)) {
      subElems.push({name: state.sub_elem});
    }

    // 関数名取得
    let funcName = state.func;
    let funcString = funcName;
    if (linq.from(funcs).all(f => f["name"] != funcName)) {
      funcs.push({name: funcName, str: funcString});
    }

    // 小文字要素名＆関数名作成
    state["elem_lower"] = (state.elem + '').toLowerCase();
    state["func_lower"] = (state.func + '').toLowerCase();
    if (state.syntax3 == true) {
      state["sub_elem_lower"] = (state.sub_elem + '').toLowerCase();
    }
  });

  json["elems"] = elems;
  json["subElems"] = subElems;
  json["funcs"] = funcs;
  return json
}

function loadFile(filePath) {
  return fs.readFileSync(filePath, 'utf-8');
}

function deepCopy(array) {
  return JSON.parse(JSON.stringify(array));
}

function parse(template, jsonData, outputPath) {
  const output = mustache.render(stripBom(template), jsonData);
  fs.writeFile(outputPath, output, 'utf-8', (err) => {
    if (err) {
      console.error(err);
      process.exit(1);
    }
    console.log(outputPath + " generation completed.");
  });
}