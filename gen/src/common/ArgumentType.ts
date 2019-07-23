
// #region インタフェース定義
/**
 * 引数の型
 */
export interface IArgumentType {
  /**
   * 型名
   */
  readonly typeName: string

  /**
   * テストに用いる値
   */
  readonly testValue: string

  /**
   * 引数に指定された型が一致するか？
   * @param typeString 型名を示す文字列
   */
  isType(typeString: string): boolean

  /**
   * C#上でテストに用いる値を取得します。
   */
  getCSharpTestValue(): string
}
// #endregion

/**
 * Double型
 */
class DoubleArgument implements IArgumentType {
  readonly typeName = 'Double'
  readonly testValue = '1.0'

  isType(typeString: string): boolean {
    // 現在は大文字小文字無視で型名を判定している
    return typeString.replace('?', '').toLowerCase() === this.typeName.toLowerCase()
  }
  getCSharpTestValue(): string {
    return this.testValue
  }
}

/**
 * String型
 */
class StringArgument implements IArgumentType {
  readonly typeName = 'String'
  readonly testValue = 'string_value'

  isType(typeString: string): boolean {
    return typeString.replace('?', '').toLowerCase() === this.typeName.toLowerCase()
  }
  getCSharpTestValue(): string {
    return `"${this.testValue}"`
  }
}

/**
 * 引数の型定義
 */
export const argumentTypes: IArgumentType[] = [
  new DoubleArgument(),
  new StringArgument(),
]
