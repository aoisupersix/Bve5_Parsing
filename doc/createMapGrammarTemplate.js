const fs = require('fs');
const linq = require('linq');
const stripBom = require('strip-bom');
const mustache = require('mustache');

const jsonData = loadJson("doc/map_grammar_syntax.json");

// Ast生成
const astTemp = loadFile("doc/map_grammar_ast.mst");
parse(astTemp, jsonData, "Bve5_Parsing/MapGrammar/AstNodes/SyntaxNodes.cs");

console.log("all completed !");

function loadJson(jsonPath) {
  const json = JSON.parse(loadFile(jsonPath));
  let elems = [];
  let funcs = [];
  //Jsonの前処理
  json.states.forEach(state => {
    // 構文種別の判定
    if (state.key === undefined) {
      state["syntax1"] = true;
      state["syntax2"] = false;
      state["syntax3"] = false;
    }else if(state.elem2 === undefined) {
      state["syntax1"] = false;
      state["syntax2"] = true;
      state["syntax3"] = false;
    }else {
      state["syntax1"] = false;
      state["syntax2"] = false;
      state["syntax3"] = true;
    }

    // 引数があるか
    if (state.args.length == 0) {
      state["noarg"] = true;
    }else {
      state.args.slice(-1)[0]["last"] = true;
    }

    // マップ要素名取得
    if (linq.from(elems).all(e => e != state.elem)) {
      elems.push(state.elem);
    }

    // 関数名取得
    let funcName = state.func;
    if (state.syntax3 == true) {
      funcName = state.elem2 + "_" + funcName;
    }
    if (linq.from(funcs).all(f => f != funcName)) {
      funcs.push(funcName);
    }
  });

  json["elems"] = elems;
  json["funcs"] = funcs;
  return json
}

function loadFile(filePath) {
  return fs.readFileSync(filePath, 'utf-8');
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