import { IArgumentDefinition } from '../definition/iArgumentDefinition'
import { IArgument } from '../definition/iArgument'
import { argumentTypes } from '../common/argumentTypes';

/**
 * IArgumentDefinitionに情報を付与したIArguementを生成して返します。
 * @param argDefs 引数定義（IArgumentDefinition）の配列
 */
export const convertArguments = (argDefs: IArgumentDefinition[]): IArgument[] => {
  const args = argDefs.map(argDef => convertArgument(argDef))

  if (args.length < 1) {
    return args
  }

  args.slice(-1)[0].last = true
  return args
}

/**
 * IArgumentDefinitionに情報を付与したIArguementを生成して返します。
 * @param argDef 引数定義（IArgumentDefinition）
 */
const convertArgument = (argDef: IArgumentDefinition): IArgument => {
  const argument: IArgument = <any>argDef
  argument.last = false

  // テスト値の設定
  const targetType = argumentTypes.find(type => type.isType(argument.type))!
  argument.test_value_map_grammar = targetType.getOutputValue()
  argument.test_value_map_grammar_non_quote = targetType.testValue
  argument.test_value_csharp = targetType.getCSharpTestValue()

  return argument
}
