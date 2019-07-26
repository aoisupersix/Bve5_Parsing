import { IMapDefinition } from './definition/iMapDefinition'
import { IMapStatement } from './definition/iMapStatement';
import { convertMapStatemnet } from './converter/convertMapStatement';

/**
 * 引数に指定された全てのマップ構文定義をIMapStatementに変換します。
 * @param mapDefinitions 変換対象のマップ構文定義
 */
export const convert = (mapDefinition: IMapDefinition[]): IMapStatement[] => {
  return mapDefinition.map(mapDef => convertMapStatemnet(mapDef))
}
