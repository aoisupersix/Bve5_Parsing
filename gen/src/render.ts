import mustache from 'mustache'
import stripBom from 'strip-bom'
import { IMapData } from './definition/iMapData';

/**
 * ステートメントをテンプレートに書き出します。
 * @param template Mustacheのレンダー先
 * @param mapData 出力対象のデータ
 */
export const render = (template: string, mapData: IMapData): string => {
  return mustache.render(stripBom(template), mapData)
}
