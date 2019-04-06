var fs = require('fs');
var stripBom = require('strip-bom');
var mustache = require('mustache');

parse("doc/map_grammar_ast.mst", "doc/map_grammar_syntax.json", "Bve5_Parsing/MapGrammar/AstNodes/SyntaxNodes.cs");

function parse(template, json, output) {
  fs.readFile(template, 'utf-8', function (err, template) {
    if (err) {
      console.error(err);
      process.exit(1);
    }
    else {
      fs.readFile(json, 'utf-8', function (err, data) {
        if (err) {
          console.error(err);
          process.exit(1);
        }
        else {
          // Jsonの前処理
          var jsonData = JSON.parse(stripBom(data));
          jsonData.states.forEach(state => {
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
            if (state.args.length == 0) {
              state["noarg"] = true;
            }else {
              state.args.slice(-1)[0]["last"] = true;
            }
          })
          var result = mustache.render(stripBom(template), jsonData);
          fs.writeFile(output, result, 'utf-8', function (err) {
            if (err) {
              console.error(err);
              process.exit(1);
            }
            else {
              console.log('finished!!');
            }
          });
        }
      });
    }
  });
}