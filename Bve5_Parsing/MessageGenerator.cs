namespace Bve5_Parsing
{
    /// <summary>
    /// メッセージの種別を表します。
    /// MessageGeneratorクラスのプロパティに対応します。
    /// </summary>
    public enum ParseMessageType
    {
        /// <summary>
        /// Default composite format string: 有効なマップファイルではありません。
        /// </summary>
        InvalidMapFormat,

        /// <summary>
        /// Default composite format string: {0}の検証に失敗しました。
        /// </summary>
        FailedPredicate,

        /// <summary>
        /// Default composite format string: 入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。
        /// </summary>
        InputMismatch,

        /// <summary>
        /// Default composite format string: 入力文字列{0}にマップ構文'{1}'がありません。
        /// </summary>
        MissingToken,

        /// <summary>
        /// Default composite format string: 入力文字列{0}のマップ構文を特定できませんでした。
        /// </summary>
        NoViable,

        /// <summary>
        /// Default composite format string: 入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。
        /// </summary>
        UnwantedToken,

        /// <summary>
        /// Default composite format string: {0}は無効な引数です。
        /// </summary>
        InvalidArgument,

        /// <summary>
        /// Default composite format string: '{0}'は有効な式ではありません。
        /// </summary>
        InvalidExpression,

        /// <summary>
        /// Default composite format string: ファイルパスが指定されていません。
        /// </summary>
        FilePathNotSpecified,

        /// <summary>
        /// Default composite format string: 指定されたファイル「{0}」は存在しません。
        /// </summary>
        FileNotFound,

        /// <summary>
        /// Default composite format string: 「{0}」の読み込みに失敗しました。
        /// </summary>
        FileFailedLoad
    }

    /// <summary>
    /// デフォルトのメッセージ生成クラス
    /// メッセージの種別に応じて、メッセージを生成します。
    /// このクラスを継承し、ErrorListenerまたはパーサーのコンストラクタに指定することで、メッセージをカスタマイズできます。
    /// </summary>
    public class MessageGenerator
    {
        // ReSharper disable UnusedMember.Global
        public virtual string InvalidMapFormat => "有効なマップファイルではありません。";
        public virtual string FailedPredicate => "{0}の検証に失敗しました。";
        public virtual string InputMismatch => "入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。";
        public virtual string MissingToken => "入力文字列{0}にマップ構文'{1}'がありません。";
        public virtual string NoViable => "入力文字列{0}のマップ構文を特定できませんでした。";
        public virtual string UnwantedToken => "入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。";
        public virtual string InvalidArgument => "{0}は無効な引数です。";
        public virtual string InvalidExpression => "'{0}'は有効な式ではありません。";
        public virtual string FilePathNotSpecified => "ファイルパスが指定されていません。";
        public virtual string FileNotFound => "指定されたファイル「{0}」は存在しません。";
        public virtual string FileFailedLoad => "「{0}」の読み込みに失敗しました。";
        // ReSharper restore UnusedMember.Global
        public virtual string FilePath => "（ファイルパス：{0}）";

        public virtual string GetMassage(ParseMessageType type, string filePath, params object[] args)
        {
            // ReSharper disable once PossibleNullReferenceException
            string msg = string.Format((string)GetType().GetProperty(type.ToString()).GetValue(this), args);

            if (filePath != null)
            {
                msg += string.Format(FilePath, filePath);
            }

            return msg;
        }
    }
}
