import * as fs from 'fs'
import * as yaml from 'js-yaml'
import path from 'path'

const mapGrammarDir = path.join(__dirname, '..', '..', 'Bve5_Parsing', 'MapGrammar')
const testDir = path.join(__dirname, '..', '..', 'Bve5_ParsingTests', 'AutoGen')

const generate = (templateName: string, mapData: IMapData, outputPath: string): void => {
  const template = fs.readFileSync(path.join(__dirname, '..', 'template', templateName), 'utf8')
  const output = render(template, mapData)
  fs.writeFileSync(outputPath, output, 'utf8')
}

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const definition: IMapDefinition[] = yaml.safeLoad(file)
const mapData = convert(definition)

generate('map_grammar_ast.mst', mapData, path.join(mapGrammarDir, 'AstNodes', 'AutoGen', 'SyntaxNodes.cs'))
generate('map_grammar_statements.mst', mapData, path.join(mapGrammarDir, 'EvaluateData', 'AutoGen', 'Statements.cs'))
generate('map_grammar_ast_visitor.mst', mapData, path.join(mapGrammarDir, 'AstNodes', 'AutoGen', 'AstVisitor.cs'))
generate('map_grammar_enum.mst', mapData, path.join(mapGrammarDir, 'AutoGen', 'MapSyntaxDefinitions.cs'))
generate('map_grammar_test.mst', mapData, path.join(testDir, 'MapGrammarSyntaxTests.cs'))
