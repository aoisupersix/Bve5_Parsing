
/**
 * 引数に指定されたバージョン文字列がマップファイルバージョン1.**かどうか
 * @param versionString バージョン文字列
 */
export const isMapVersion1 = (versionString: string): boolean => versionString.trim().slice(0, 1) === '1'

/**
 * 引数に指定されたバージョン文字列がマップファイルバージョン2.**かどうか
 * @param versionString バージョン文字列
 */
export const isMapVersion2 = (versionString: string): boolean => versionString.trim().slice(0, 1) === '2'
