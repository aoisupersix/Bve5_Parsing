import * as mapDef from '../definition/iMapDefinition'
import { IMapStatement } from '../definition/iMapStatement'
import { convertArguments } from './convertArgument';

/**
 * 引数に指定された全てのマップ構文定義をIMapStatementに変換します。
 * @param mapDefinitions 変換対象のマップ構文定義
 */
export const convertMapStatements = (mapDefinitions: mapDef.IMapDefinition[]): IMapStatement[] => {
  return mapDefinitions.map(mapDef => convertMapStatemnet(mapDef))
}

/**
 * マップ構文定義から必要な情報を付加したIMapStatementを返します。
 * @param mapDefinition マップ構文定義(yaml)
 */
export const convertMapStatemnet = (mapDefinition: mapDef.IMapDefinition): IMapStatement => {
  const statement: IMapStatement = <any>mapDefinition

  // 種別判定
  statement.syntax1 = mapDef.isSyntax1(mapDefinition)
  statement.syntax2 = mapDef.isSyntax2(mapDefinition)
  statement.syntax3 = mapDef.isSyntax3(mapDefinition)
  statement.nofunc = mapDef.hasFunc(mapDefinition) === false
  statement.noarg = mapDef.hasArg(mapDefinition) === false

  // 小文字
  statement.elem_lower = mapDefinition.elem.toLowerCase()

  // [FIX ME] 副要素を持つ場合のみ
  statement.sub_elem_lower = mapDefinition.sub_elem!.toLowerCase()

  if (mapDef.hasFunc(mapDefinition)) {
    statement.func_lower = mapDefinition.func!.toLowerCase()
  }

  // 引数変換
  statement.args = convertArguments(mapDefinition.args)

  return statement
}
