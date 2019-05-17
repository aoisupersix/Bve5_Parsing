
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
   * テストをスキップするか？
   */
  skip_test: boolean | undefined
  // #endregion

}

/**
 * マップ構文の引数定義
 */
export interface Argument {

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
}
