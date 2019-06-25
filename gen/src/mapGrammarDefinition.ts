
/**
 * マップ構文のステートメント定義
 */
export interface MapStatement {
  // #region 最初から設定してある項目
  /**
   * マップ要素名
   */
  elem: string

  /**
   * キー名
   */
  key: string | undefined

  /**
   * マップ副要素名
   */
  sub_elem: string | undefined

  /**
   * マップ関数名
   */
  func: string | undefined

  /**
   * ステートメントが有効なマップバージョン
   */
  versions: string[]

  /**
   * 引数
   */
  args: Argument[]

  /**
   * 関数が取りうる引数のリスト
   * カンマ区切りの文字列で、引数がない場合は空文字
   */
  argPatterns: string[]

  /**
   * テストをスキップするか？
   */
  skip_test: boolean | undefined
  // #endregion

  // #region プログラムから追加する項目

  /**
   * 引数のとり得るパターン（結果用）
   */
  argPattern: Argument[][]

  /**
   * 小文字のマップ要素名
   */
  elem_lower: string

  /**
   * 小文字のマップ副要素名
   */
  sub_elem_lower: string

  /**
   * 小文字の関数名
   */
  func_lower: string | null

  /**
   * 構文タイプ1か？
   */
  syntax1: boolean

  /**
   * 構文タイプ2か？
   */
  syntax2: boolean

  /**
   * 構文タイプ3か？
   */
  syntax3: boolean

  /**
   * 関数名を持たないステートメントか？
   */
  nofunc: boolean

  /**
   * 引数を持たないステートメントか？
   */
  noarg: boolean
  // #endregion

}

/**
 * マップ構文の引数定義
 */
export interface Argument {

  // #region 最初から設定してある項目
  /**
   * 引数名
   */
  name: string

  /**
   * 引数の型
   */
  type: string

  /**
   * 引数の説明
   */
  desc: string

  /**
   * 省略可能な引数か？
   */
  opt: boolean
  // #endregion

  // #region プログラムから追加する項目

  /**
   * 最後の引数か？
   * 最後の引数以外はカンマを付ける関係で使う
   */
  last: boolean | null

  /**
   * テスト用値(構文出力用)
   */
  test_value_map_grammar: string

  /**
   * テスト用値
   */
  test_value_map_grammar_non_quote: string

  /**
   * C#用テスト値
   */
  test_value_csharp: string
  // #endregion
}
