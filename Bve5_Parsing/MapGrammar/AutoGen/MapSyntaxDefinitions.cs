/*
 * このファイルは自動生成doc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */

namespace Bve5_Parsing.MapGrammar {

    /// <summary>
    /// マップ要素名
    /// </summary>
    public enum MapElementName
    {

        /// <summary>
        /// Curve
        /// </summary>
        [StringValue("Curve")]
        Curve,

        /// <summary>
        /// Gradient
        /// </summary>
        [StringValue("Gradient")]
        Gradient,

        /// <summary>
        /// Track
        /// </summary>
        [StringValue("Track")]
        Track,

        /// <summary>
        /// Structure
        /// </summary>
        [StringValue("Structure")]
        Structure,

        /// <summary>
        /// Repeater
        /// </summary>
        [StringValue("Repeater")]
        Repeater,

        /// <summary>
        /// Background
        /// </summary>
        [StringValue("Background")]
        Background,

        /// <summary>
        /// Station
        /// </summary>
        [StringValue("Station")]
        Station,

        /// <summary>
        /// Section
        /// </summary>
        [StringValue("Section")]
        Section,

        /// <summary>
        /// Signal
        /// </summary>
        [StringValue("Signal")]
        Signal,

        /// <summary>
        /// Beacon
        /// </summary>
        [StringValue("Beacon")]
        Beacon,

        /// <summary>
        /// Speedlimit
        /// </summary>
        [StringValue("Speedlimit")]
        Speedlimit,

        /// <summary>
        /// Pretrain
        /// </summary>
        [StringValue("Pretrain")]
        Pretrain,

        /// <summary>
        /// Light
        /// </summary>
        [StringValue("Light")]
        Light,

        /// <summary>
        /// Fog
        /// </summary>
        [StringValue("Fog")]
        Fog,

        /// <summary>
        /// Drawdistance
        /// </summary>
        [StringValue("Drawdistance")]
        Drawdistance,

        /// <summary>
        /// Cabilluminance
        /// </summary>
        [StringValue("Cabilluminance")]
        Cabilluminance,

        /// <summary>
        /// Irregularity
        /// </summary>
        [StringValue("Irregularity")]
        Irregularity,

        /// <summary>
        /// Adhision
        /// </summary>
        [StringValue("Adhision")]
        Adhision,

        /// <summary>
        /// Sound
        /// </summary>
        [StringValue("Sound")]
        Sound,

        /// <summary>
        /// Sound3d
        /// </summary>
        [StringValue("Sound3d")]
        Sound3d,

        /// <summary>
        /// Rollingnoise
        /// </summary>
        [StringValue("Rollingnoise")]
        Rollingnoise,

        /// <summary>
        /// Flangenoise
        /// </summary>
        [StringValue("Flangenoise")]
        Flangenoise,

        /// <summary>
        /// Jointnoise
        /// </summary>
        [StringValue("Jointnoise")]
        Jointnoise,

        /// <summary>
        /// Train
        /// </summary>
        [StringValue("Train")]
        Train,
    }

    /// <summary>
    /// マップ関数名
    /// </summary>
    public enum MapFunctionName {

        /// <summary>
        /// Setgauge（Setgauge）
        /// </summary>
        [StringValue("Setgauge")]
        Setgauge,

        /// <summary>
        /// Setcenter（Setcenter）
        /// </summary>
        [StringValue("Setcenter")]
        Setcenter,

        /// <summary>
        /// Setfunction（Setfunction）
        /// </summary>
        [StringValue("Setfunction")]
        Setfunction,

        /// <summary>
        /// BeginTransition（BeginTransition）
        /// </summary>
        [StringValue("BeginTransition")]
        BeginTransition,

        /// <summary>
        /// Begin（Begin）
        /// </summary>
        [StringValue("Begin")]
        Begin,

        /// <summary>
        /// End（End）
        /// </summary>
        [StringValue("End")]
        End,

        /// <summary>
        /// Interpolate（Interpolate）
        /// </summary>
        [StringValue("Interpolate")]
        Interpolate,

        /// <summary>
        /// Change（Change）
        /// </summary>
        [StringValue("Change")]
        Change,

        /// <summary>
        /// Begintransition（Begintransition）
        /// </summary>
        [StringValue("Begintransition")]
        Begintransition,

        /// <summary>
        /// X_Interpolate（X.Interpolate）
        /// </summary>
        [StringValue("X.Interpolate")]
        X_Interpolate,

        /// <summary>
        /// Y_Interpolate（Y.Interpolate）
        /// </summary>
        [StringValue("Y.Interpolate")]
        Y_Interpolate,

        /// <summary>
        /// Position（Position）
        /// </summary>
        [StringValue("Position")]
        Position,

        /// <summary>
        /// Cant_Setgauge（Cant.Setgauge）
        /// </summary>
        [StringValue("Cant.Setgauge")]
        Cant_Setgauge,

        /// <summary>
        /// Cant_Setcenter（Cant.Setcenter）
        /// </summary>
        [StringValue("Cant.Setcenter")]
        Cant_Setcenter,

        /// <summary>
        /// Cant_Setfunction（Cant.Setfunction）
        /// </summary>
        [StringValue("Cant.Setfunction")]
        Cant_Setfunction,

        /// <summary>
        /// Cant_Begintransition（Cant.Begintransition）
        /// </summary>
        [StringValue("Cant.Begintransition")]
        Cant_Begintransition,

        /// <summary>
        /// Cant_Begin（Cant.Begin）
        /// </summary>
        [StringValue("Cant.Begin")]
        Cant_Begin,

        /// <summary>
        /// Cant_End（Cant.End）
        /// </summary>
        [StringValue("Cant.End")]
        Cant_End,

        /// <summary>
        /// Cant_Interpolate（Cant.Interpolate）
        /// </summary>
        [StringValue("Cant.Interpolate")]
        Cant_Interpolate,

        /// <summary>
        /// Load（Load）
        /// </summary>
        [StringValue("Load")]
        Load,

        /// <summary>
        /// Put（Put）
        /// </summary>
        [StringValue("Put")]
        Put,

        /// <summary>
        /// Put0（Put0）
        /// </summary>
        [StringValue("Put0")]
        Put0,

        /// <summary>
        /// Putbetween（Putbetween）
        /// </summary>
        [StringValue("Putbetween")]
        Putbetween,

        /// <summary>
        /// Begin0（Begin0）
        /// </summary>
        [StringValue("Begin0")]
        Begin0,

        /// <summary>
        /// Setspeedlimit（Setspeedlimit）
        /// </summary>
        [StringValue("Setspeedlimit")]
        Setspeedlimit,

        /// <summary>
        /// Pass（Pass）
        /// </summary>
        [StringValue("Pass")]
        Pass,

        /// <summary>
        /// Ambient（Ambient）
        /// </summary>
        [StringValue("Ambient")]
        Ambient,

        /// <summary>
        /// Diffuse（Diffuse）
        /// </summary>
        [StringValue("Diffuse")]
        Diffuse,

        /// <summary>
        /// Play（Play）
        /// </summary>
        [StringValue("Play")]
        Play,

        /// <summary>
        /// Add（Add）
        /// </summary>
        [StringValue("Add")]
        Add,

        /// <summary>
        /// Enable（Enable）
        /// </summary>
        [StringValue("Enable")]
        Enable,

        /// <summary>
        /// Stop（Stop）
        /// </summary>
        [StringValue("Stop")]
        Stop,
    }

}