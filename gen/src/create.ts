import * as fs from 'fs'
import * as yaml from 'js-yaml'
import * as mustache from 'mustache'
import stripBom from 'strip-bom'

import { IMapDefinition } from './definition/iMapDefinition';
import { convertMapStatements } from './converter/convertMapStatement';
import { IMapStatement } from './definition/iMapStatement';

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDefs: IMapDefinition[] = yaml.safeLoad(file)
const convertedMapDefs = convertMapStatements(mapDefs)
const json = JSON.stringify(convertedMapDefs)

console.log(json)

console.log(convertedMapDefs)

const parse = (template: string, outputPath: string, statements: IMapStatement[]): void => {
  const output = mustache.render(stripBom(template), statements)
  fs.writeFile(outputPath, output, { encoding: 'utf-8' }, _ => console.log(`${outputPath} generation completed.`))
}
