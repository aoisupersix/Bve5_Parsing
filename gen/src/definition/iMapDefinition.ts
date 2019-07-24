import { IArgumentDefinition } from './iArgumentDefinition'
import { IArgument } from './iArgument';

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
   * IMapStatementがこのインタフェースを継承している関係で、同名で型の異なる変数(つまりargs)が定義できない。
   * そのため暫定措置として、argsはIArgumentDefinition(yaml読み込み時)とIArgumentの両方を許可している。
   */
  args: IArgumentDefinition[] | IArgument[]

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

// #region IMapDefinition判定用便利関数

/**
 * 引数に指定されたマップ構文がキーを保持しているか
 * @param mapDefinition マップ構文定義
 */
export const hasKey = (mapDefinition: IMapDefinition): boolean => mapDefinition.key !== undefined

/**
 * 引数に指定されたマップ構文がマップ副要素を保持しているか
 * @param mapDefinition マップ構文定義
 */
export const hasSubElem = (mapDefinition: IMapDefinition): boolean => mapDefinition.sub_elem !== undefined

/**
 * 引数に指定されたマップ構文定義が関数名を保持しているか
 * @param mapDefinition マップ構文定義
 */
export const hasFunc = (mapDefinition: IMapDefinition): boolean =>
  mapDefinition.func !== undefined && mapDefinition.func.trim() !== ''

/**
 * 引数に指定されたマップ構文定義が引数を保持しているか
 * @param mapDefinition マップ構文定義
 */
export const hasArg = (mapDefinition: IMapDefinition): boolean => mapDefinition.args.length > 0

/**
 * 引数に指定されたマップ構文定義がSyntax1かどうか
 * @param mapDefinition マップ構文定義
 */
export const isSyntax1 = (mapDefinition: IMapDefinition): boolean => hasKey(mapDefinition) === false

/**
 * 引数に指定されたマップ構文定義がSyntax2かどうか
 * @param mapDefinition マップ構文定義
 */
export const isSyntax2 = (mapDefinition: IMapDefinition): boolean =>
  !isSyntax1(mapDefinition) && hasSubElem(mapDefinition) === false

/**
 * 引数に指定されたマップ構文定義がSyntax3かどうか
 * @param mapDefinition マップ構文定義
 */
export const isSyntax3 = (mapDefinition: IMapDefinition): boolean =>
  !isSyntax1(mapDefinition) && !isSyntax2(mapDefinition)

// #endregion
