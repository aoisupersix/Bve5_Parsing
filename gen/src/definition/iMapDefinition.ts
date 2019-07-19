/**
 * マップ構文定義
 * mapgrammar.yamlのスキーマ
 */
export interface IMapDefinition {
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
  // args: Argument[]

  /**
   * 関数が取りうる引数のリスト
   * カンマ区切りの文字列で、引数がない場合は空文字
   */
  argPatterns: string[]

  /**
   * テストをスキップするか？
   */
  skip_test: boolean | undefined
}
