import { IMapDefinition, isSyntax1, isSyntax2, isSyntax3 } from '../definition/iMapDefinition'
import { IMapStatement } from '../definition/iMapStatement'
import { convertArguments } from './convertArgument';

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

  // 種別判定
  statement.syntax1 = isSyntax1(mapDefinition)
  statement.syntax2 = isSyntax2(mapDefinition)
  statement.syntax3 = isSyntax3(mapDefinition)

  // 引数変換
  statement.args = convertArguments(mapDefinition.args)

  return statement
}
