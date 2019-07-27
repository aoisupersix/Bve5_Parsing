import { IMapStatement } from './iMapStatement'

/**
 * テンプレートエンジンに食わせるマップデータ
 */
export interface IMapData {
  /**
   * 構文の定義
   */
  states: IMapStatement[]

  /**
   * 全構文のマップ要素名
   */
  elems: string[]

  /**
   * 全構文のマップ副要素名
   */
  subElems: string[]

  /**
   * 全構文のマップ関数名
   */
  funcs: string[]
}
