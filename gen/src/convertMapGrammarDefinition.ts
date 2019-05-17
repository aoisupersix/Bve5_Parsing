import { MapStatement } from './mapGrammarDefinition'

/**
 * マップ構文定義ファイルから色々な情報を付加した中間出力を生成します。
 */
export function convert(mapGrammarData: MapStatement[]) : void {
  mapGrammarData.map(setSyntaxType)
}

function setSyntaxType(element: object, index: number, array: object[]) {
}
