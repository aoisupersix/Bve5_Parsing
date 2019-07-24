import { IMapDefinition } from '../definition/iMapDefinition'
import { IMapStatement } from '../definition/iMapStatement'

/**
 * 引数に指定された全てのマップ構文定義をIMapStatementに変換します。
 * @param mapDefinitions 変換対象のマップ構文定義
 */
export const convertMapStatements = (mapDefinitions: IMapDefinition[]): IMapStatement[] => {
  return mapDefinitions.map(mapDef => convertMapStatemnet(mapDef))
}

/**
 * マップ構文定義から必要な情報を付加したIMapStatementを返します。
 * @param mapDefinition マップ構文定義(yaml)
 */
export const convertMapStatemnet = (mapDefinition: IMapDefinition): IMapStatement => {
  const statement: IMapStatement = <any>mapDefinition
  return statement
}
