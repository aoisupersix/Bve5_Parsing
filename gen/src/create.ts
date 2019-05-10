import * as fs from 'fs'

function hello(name: string): string {
    return `Hello, ${name}!`
}

const file = fs.readFileSync(`${__dirname}/mapgrammar.json`, "utf8")
const json = JSON.parse(file)

console.log(json)

console.log(hello("TypeScript"))
