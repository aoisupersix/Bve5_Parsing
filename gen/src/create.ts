import * as b5g from 'b5g'
import * as fs from 'fs'
import path from 'path'

const mapGrammarDir = path.join(__dirname, '..', '..', 'Bve5_Parsing', 'MapGrammar')
const testDir = path.join(__dirname, '..', '..', 'Bve5_ParsingTests', 'AutoGen')

const generate = (templateName: string, mapData: b5g.MapData, outputPath: string): void => {
  const template = fs.readFileSync(path.join(__dirname, '..', 'template', templateName), 'utf8')
  const output = b5g.render(template, mapData)
  fs.writeFileSync(outputPath, output, 'utf8')
}

b5g.getDefaultMapData().then((mapData) => {
  generate(
    'map_grammar_ast.mst',
    mapData,
    path.join(mapGrammarDir, 'AstNodes', 'AutoGen', 'SyntaxNodes.cs'))

  generate(
    'map_grammar_statements.mst',
    mapData,
    path.join(mapGrammarDir, 'EvaluateData', 'AutoGen', 'Statements.cs'))

  generate(
    'map_grammar_ast_visitor.mst',
    mapData,
    path.join(mapGrammarDir, 'AstNodes', 'AutoGen', 'AstVisitor.cs'))

  generate(
    'map_grammar_enum.mst',
    mapData,
    path.join(mapGrammarDir, 'AutoGen', 'MapSyntaxDefinitions.cs'))

  generate(
    'map_grammar_test.mst',
    mapData,
    path.join(testDir, 'MapGrammarSyntaxTests.cs'))
}).catch(err => console.error(err))
