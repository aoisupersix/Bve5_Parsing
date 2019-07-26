import * as fs from 'fs'
import * as yaml from 'js-yaml'
import * as mustache from 'mustache'
import stripBom from 'strip-bom'
import { promisify } from 'util'

import { IMapDefinition } from './definition/iMapDefinition';
import { convertMapStatements } from './converter/convertMapStatement';
import { IMapStatement } from './definition/iMapStatement';

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const mapDefs: IMapDefinition[] = yaml.safeLoad(file)
const convertedMapDefs = convertMapStatements(mapDefs)
const json = JSON.stringify(convertedMapDefs)

console.log(json)

console.log(convertedMapDefs)

/**
 * ステートメントをテンプレートに書き出します。
 * @param template Mustacheのレンダー先
 * @param outputPath 出力先パス
 * @param statements 出力対象のステートメント
 */
const render = (template: string, outputPath: string, statements: IMapStatement[]): Promise<void> => {
  const output = mustache.render(stripBom(template), statements)
  return promisify(fs.writeFile)(outputPath, output, { encoding: 'utf-8' })
}
