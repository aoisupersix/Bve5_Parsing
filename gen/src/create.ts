import * as fs from 'fs'
import * as yaml from 'js-yaml'

import { IMapDefinition } from './definition/iMapDefinition';
import { convertMapStatements } from './converter/convertMapStatement';

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDefs: IMapDefinition[] = yaml.safeLoad(file)
const convertedMapDefs = convertMapStatements(mapDefs)
const json = JSON.stringify(convertedMapDefs)

console.log(json)

console.log(convertedMapDefs)
