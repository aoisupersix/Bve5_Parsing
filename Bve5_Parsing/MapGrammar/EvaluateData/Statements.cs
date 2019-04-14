using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bve5_Parsing.MapGrammar.EvaluateData
{
    /// <summary>
    /// Repeater.Beginの手動対応
    /// 可変長のstructureKeyへ対応する
    /// </summary>
    public partial class RepeaterBeginStatement
    {
        protected List<string> _structureKeys = new List<string>();

        /// <summary>
        /// StructureKeyN
        /// </summary>
        public ReadOnlyCollection<string> StructureKeys => _structureKeys.AsReadOnly();

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長のStructureKeys対応
        /// </summary>
        /// <returns></returns>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _structureKeys.Count(); i++)
            {
                syntax.SetArg($"structurekey{i + 1}", _structureKeys[i]);
            }

            return syntax;
        }

        public void AddStructureKey(string strKey)
        {
            _structureKeys.Add(strKey);
        }
    }

    /// <summary>
    /// Repeater.Begin0の手動対応
    /// 可変長のstructureKeyへ対応する
    /// </summary>
    public partial class RepeaterBegin0Statement
    {
        protected List<string> _structureKeys = new List<string>();

        /// <summary>
        /// StructureKeyN
        /// </summary>
        public ReadOnlyCollection<string> StructureKeys => _structureKeys.AsReadOnly();

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長のStructureKeys対応
        /// </summary>
        /// <returns></returns>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _structureKeys.Count(); i++)
            {
                syntax.SetArg($"structurekey{i + 1}", _structureKeys[i]);
            }

            return syntax;
        }


        public void AddStructureKey(string strKey)
        {
            _structureKeys.Add(strKey);
        }
    }

    /// <summary>
    /// Section.Beginの手動対応
    /// 可変長のsignalIndexへ対応する
    /// </summary>
    public partial class SectionBeginStatement
    {
        protected List<string> _signalIndexes = new List<string>();

        /// <summary>
        /// SignalIndexN
        /// </summary>
        public ReadOnlyCollection<string> SignalIndexes => _signalIndexes.AsReadOnly();

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長のSignalIndex対応
        /// </summary>
        /// <returns></returns>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _signalIndexes.Count(); i++)
            {
                syntax.SetArg($"signal{i}", _signalIndexes[i]);
            }

            return syntax;
        }


        public void AddSignalIndex(string sigIdx)
        {
            _signalIndexes.Add(sigIdx);
        }
    }

    /// <summary>
    /// Section.Setspeedlimitの手動対応
    /// 可変長の速度制限へ対応する
    /// </summary>
    public partial class SectionSetspeedlimitStatement
    {
        protected List<string> _speedLimits = new List<string>();

        /// <summary>
        /// SpeedLimitN(vN)
        /// </summary>
        public ReadOnlyCollection<string> SpeedLimits => _speedLimits.AsReadOnly();

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長のSpeedLimit対応
        /// </summary>
        /// <returns></returns>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _speedLimits.Count(); i++)
            {
                syntax.SetArg($"v{i}", _speedLimits[i]);
            }

            return syntax;
        }

        // TODO: NULLの可能性もある
        public void AddSpeedLimit(string spdLmt)
        {
            _speedLimits.Add(spdLmt);
        }
    }
}
