import { MapStatement, Argument } from './mapGrammarDefinition'

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
  const result = mapGrammarData
    .map(setSyntaxType)
    .map(setTestValue)
    .map(setArgPattern)

  return result
}

/**
 * 構文種別をステートメントに設定します。
 */
const setSyntaxType = (element: MapStatement): MapStatement => {
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
const setTestValue = (element: MapStatement): MapStatement => {
  element.args.forEach((val) => {
    // const nullable = val.type.slice(-1) === '?' // null許容かどうか. 今は特に処理なし
    // 引数のバリデートを追加したらここも変更する必要あり
    switch (val.type.replace('?', '').toLowerCase()) {
      case ArgType.String:
        val.test_value_map_grammar_non_quote = 'string_test_value'
        val.test_value_map_grammar = `'${val.test_value_map_grammar_non_quote}'`
        val.test_value_csharp = `"${val.test_value_map_grammar_non_quote}"`
        break
      case ArgType.Double:
        val.test_value_map_grammar_non_quote = '1.0'
        val.test_value_map_grammar = val.test_value_map_grammar_non_quote
        val.test_value_csharp = val.test_value_map_grammar_non_quote
        break
    }
  })

  return element
}

/**
 * 引数のパターンを生成します。
 * @param element MapElement
 */
const setArgPattern = (element: MapStatement): MapStatement => {
  // 引数なし
  if (element.argPatterns === undefined) {
    return element
  }

  const patterns = element.argPatterns.map((patternString) => {
    const argPattern = patternString
      .trim()
      .split(',')
      .filter(argName => argName !== '')
      .map((argName) => {
        const targets = element.args.filter(value => value.name.toLowerCase() === argName.toLowerCase())
        //#region 例外処理
        // TODO: Errorクラスの作成
        if (targets.length < 1) {
          console.error(`No matching argument was found. Argument name: ${argName}`)
        }
        if (targets.length > 1) {
          const matchingArgNames = targets.reduce((prev, current) => `${prev}, ${current.name}`, '')
          console.error(
            `Argument name: ${argName} can not be uniquely identified. Maching arguments: ${matchingArgNames}`)
        }
        //#endregion 例外処理
        return Object.assign({}, targets[0])
      })
    return argPattern
  })

  element.argPattern = patterns
  return element
}
