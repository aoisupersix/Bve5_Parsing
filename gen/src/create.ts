import * as fs from 'fs'
import * as yaml from 'js-yaml'
import { MapStatement } from './mapGrammarDefinition';

function hello(name: string): string {
  return `Hello, ${name}!`
}

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDef: MapStatement[] = yaml.safeLoad(file)

console.log(mapDef)
