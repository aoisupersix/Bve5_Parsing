import { MapStatement } from './mapGrammarDefinition'

/**
 * 引数の型
 */
export enum ArgType {
  /**
   * 文字列
   */
  String = 'string',

  /**
   * 浮動小数点数
   */
  Double = 'double',
}

/**
 * マップ構文定義ファイルから色々な情報を付加した中間出力を生成します。
 */
export const convert = (mapGrammarData: MapStatement[]) : MapStatement[] => {
  const result = mapGrammarData.map(setSyntaxType)

  return result
}

/**
 * 構文種別をステートメントに設定します。
 */
const setSyntaxType = (element: MapStatement, index: number, array: MapStatement[]): MapStatement => {
  if (element.key === undefined) {
    element.syntax1 = true
    element.syntax2 = false
    element.syntax3 = false
  }else if (element.sub_elem === undefined) {
    element.syntax1 = false
    element.syntax2 = true
    element.syntax3 = false
  }else {
    element.syntax1 = false
    element.syntax2 = false
    element.syntax3 = true
  }
  return element
}

/**
 * テスト値を生成して引数に設定します。
 */
const setTestValue = (element: MapStatement, index: number, array: MapStatement[]): MapStatement => {
  element.args.forEach((val, idx, ary) => {
    const nullable = val.type.slice(-1) === '?' // null許容かどうか. 今は特に処理なし
    switch (val.type.replace('?', '').toLowerCase()) {
      case ArgType.String:
        break
      case ArgType.Double:
        break
    }
  })

  return element
}
