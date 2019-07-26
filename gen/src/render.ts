import * as fs from 'fs'
import * as mustache from 'mustache'
import stripBom from 'strip-bom'
import { promisify } from 'util'
import { IMapStatement } from './definition/iMapStatement';

/**
 * ステートメントをテンプレートに書き出します。
 * @param template Mustacheのレンダー先
 * @param statements 出力対象のステートメント
 */
export const render = (template: string, statements: IMapStatement[]): string => {
  return mustache.render(stripBom(template), statements)
}
