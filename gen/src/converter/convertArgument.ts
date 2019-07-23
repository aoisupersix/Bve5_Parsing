import { IArgumentDefinition } from '../definition/iArgumentDefinition'
import { IArgument } from '../definition/iArgument'

export const convertArguments = (argDefs: IArgumentDefinition[]): IArgument[] => {
  return argDefs.map(argDef => convertArgument(argDef))
}

const convertArgument = (argDef: IArgumentDefinition): IArgument => {
  const argument: IArgument = <any>argDef
  argument.last = false
  return argument
}
