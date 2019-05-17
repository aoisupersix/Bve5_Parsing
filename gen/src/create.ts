import * as fs from 'fs'
import * as yaml from 'js-yaml'
import { MapStatement } from './mapGrammarDefinition';
import { convert } from './convertMapGrammarDefinition';

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDef: MapStatement[] = yaml.safeLoad(file)
const convertedMapDef = convert(mapDef)
const json = JSON.stringify(convertedMapDef)

console.log(json)

console.log(convertedMapDef)
