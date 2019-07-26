import * as fs from 'fs'
import * as mustache from 'mustache'
import stripBom from 'strip-bom'
import { promisify } from 'util'
import { IMapStatement } from './definition/iMapStatement';

/**
 * ステートメントをテンプレートに書き出します。
 * @param template Mustacheのレンダー先
 * @param outputPath 出力先パス
 * @param statements 出力対象のステートメント
 */
export const render = (template: string, outputPath: string, statements: IMapStatement[]): Promise<void> => {
  const output = mustache.render(stripBom(template), statements)
  return promisify(fs.writeFile)(outputPath, output, { encoding: 'utf-8' })
}
