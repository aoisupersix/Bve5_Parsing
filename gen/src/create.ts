import * as fs from 'fs'
import * as yaml from 'js-yaml'

function hello(name: string): string {
  return `Hello, ${name}!`
}

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDef = yaml.safeLoad(file)

console.log(mapDef)
