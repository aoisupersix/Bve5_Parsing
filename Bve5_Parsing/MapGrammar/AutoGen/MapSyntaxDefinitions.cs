/*
 * このファイルはdoc/createMapGrammarTemplate.jsによって自動生成されています。
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
        /// Gauge
        /// </summary>
        [StringValue("Gauge")]
        Gauge,

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
        /// Speedlimit
        /// </summary>
        [StringValue("Speedlimit")]
        Speedlimit,

        /// <summary>
        /// Beacon
        /// </summary>
        [StringValue("Beacon")]
        Beacon,

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
        /// Adhesion
        /// </summary>
        [StringValue("Adhesion")]
        Adhesion,

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

        /// <summary>
        /// Legacy
        /// </summary>
        [StringValue("Legacy")]
        Legacy,

        /// <summary>
        /// Include
        /// </summary>
        [StringValue("Include")]
        Include,
    }

    /// <summary>
    /// マップ副要素名（一部構文のみに存在します）
    /// </summary>
    public enum MapSubElementName {

        /// <summary>
        /// X
        /// </summary>
        [StringValue("X")]
        X,

        /// <summary>
        /// Y
        /// </summary>
        [StringValue("Y")]
        Y,

        /// <summary>
        /// Cant
        /// </summary>
        [StringValue("Cant")]
        Cant,
    }

    /// <summary>
    /// マップ関数名
    /// </summary>
    public enum MapFunctionName {

        /// <summary>
        /// Setgauge
        /// </summary>
        [StringValue("Setgauge")]
        Setgauge,

        /// <summary>
        /// Set
        /// </summary>
        [StringValue("Set")]
        Set,

        /// <summary>
        /// Gauge
        /// </summary>
        [StringValue("Gauge")]
        Gauge,

        /// <summary>
        /// Setcenter
        /// </summary>
        [StringValue("Setcenter")]
        Setcenter,

        /// <summary>
        /// Setfunction
        /// </summary>
        [StringValue("Setfunction")]
        Setfunction,

        /// <summary>
        /// Begintransition
        /// </summary>
        [StringValue("Begintransition")]
        Begintransition,

        /// <summary>
        /// Begin
        /// </summary>
        [StringValue("Begin")]
        Begin,

        /// <summary>
        /// Begincircular
        /// </summary>
        [StringValue("Begincircular")]
        Begincircular,

        /// <summary>
        /// End
        /// </summary>
        [StringValue("End")]
        End,

        /// <summary>
        /// Interpolate
        /// </summary>
        [StringValue("Interpolate")]
        Interpolate,

        /// <summary>
        /// Change
        /// </summary>
        [StringValue("Change")]
        Change,

        /// <summary>
        /// Beginconst
        /// </summary>
        [StringValue("Beginconst")]
        Beginconst,

        /// <summary>
        /// Position
        /// </summary>
        [StringValue("Position")]
        Position,

        /// <summary>
        /// Cant
        /// </summary>
        [StringValue("Cant")]
        Cant,

        /// <summary>
        /// Load
        /// </summary>
        [StringValue("Load")]
        Load,

        /// <summary>
        /// Put
        /// </summary>
        [StringValue("Put")]
        Put,

        /// <summary>
        /// Put0
        /// </summary>
        [StringValue("Put0")]
        Put0,

        /// <summary>
        /// Putbetween
        /// </summary>
        [StringValue("Putbetween")]
        Putbetween,

        /// <summary>
        /// Begin0
        /// </summary>
        [StringValue("Begin0")]
        Begin0,

        /// <summary>
        /// Beginnew
        /// </summary>
        [StringValue("Beginnew")]
        Beginnew,

        /// <summary>
        /// Setspeedlimit
        /// </summary>
        [StringValue("Setspeedlimit")]
        Setspeedlimit,

        /// <summary>
        /// Speedlimit
        /// </summary>
        [StringValue("Speedlimit")]
        Speedlimit,

        /// <summary>
        /// Setsignal
        /// </summary>
        [StringValue("Setsignal")]
        Setsignal,

        /// <summary>
        /// Pass
        /// </summary>
        [StringValue("Pass")]
        Pass,

        /// <summary>
        /// Ambient
        /// </summary>
        [StringValue("Ambient")]
        Ambient,

        /// <summary>
        /// Diffuse
        /// </summary>
        [StringValue("Diffuse")]
        Diffuse,

        /// <summary>
        /// Direction
        /// </summary>
        [StringValue("Direction")]
        Direction,

        /// <summary>
        /// Play
        /// </summary>
        [StringValue("Play")]
        Play,

        /// <summary>
        /// Add
        /// </summary>
        [StringValue("Add")]
        Add,

        /// <summary>
        /// Enable
        /// </summary>
        [StringValue("Enable")]
        Enable,

        /// <summary>
        /// Stop
        /// </summary>
        [StringValue("Stop")]
        Stop,

        /// <summary>
        /// Settrack
        /// </summary>
        [StringValue("Settrack")]
        Settrack,

        /// <summary>
        /// Fog
        /// </summary>
        [StringValue("Fog")]
        Fog,

        /// <summary>
        /// Curve
        /// </summary>
        [StringValue("Curve")]
        Curve,

        /// <summary>
        /// Pitch
        /// </summary>
        [StringValue("Pitch")]
        Pitch,

        /// <summary>
        /// Turn
        /// </summary>
        [StringValue("Turn")]
        Turn,
    }

}
