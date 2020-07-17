/*
 *	MapGrammarV1のANTLR字句定義ファイルです。
 */
lexer grammar MapGrammarV1Lexer;

// Map element name
CURVE : C U R V E;
GRADIENT : G R A D I E N T;
TRACK : T R A C K;
STRUCTURE : S T R U C T U R E;
REPEATER : R E P E A T E R;
BACKGROUND : B A C K G R O U N D;
STATION : S T A T I O N;
SECTION : S E C T I O N;
SIGNAL : S I G N A L;
BEACON : B E A C O N;
SPEEDLIMIT : S P E E D L I M I T;
PRETRAIN : P R E T R A I N;
LIGHT : L I G H T;
FOG : F O G;
CABILLUMINANCE : C A B I L L U M I N A N C E;
IRREGULARITY : I R R E G U L A R I T Y;
ADHESION : A D H E S I O N;
SOUND : S O U N D;
SOUND3D : S O U N D '3' D;
ROLLINGNOISE : R O L L I N G N O I S E;
FLANGENOISE : F L A N G E N O I S E;
JOINTNOISE : J O I N T N O I S E;
TRAIN : T R A I N;
LEGACY : L E G A C Y;

// Function name
GAUGE : G A U G E;
CANT : C A N T;
SET : S E T;
SET_SIGNAL : S E T S I G N A L;
SET_TRACK : S E T T R A C K;
BEGIN_TRANSITION : B E G I N T R A N S I T I O N;
BEGIN : B E G I N;
BEGIN0 : B E G I N '0';
BEGIN_CIRCULAR : B E G I N C I R C U L A R;
BEGIN_CONST : B E G I N C O N S T;
BEGIN_NEW : B E G I N N E W;
END : E N D;
CHANGE : C H A N G E;
POSITION : P O S I T I O N;
LOAD : L O A D;
PUT : P U T;
PUT0 : P U T '0';
PUTBETWEEN : P U T B E T W E E N;
PASS : P A S S;
AMBIENT : A M B I E N T;
DIFFUSE : D I F F U S E;
DIRECTION : D I R E C T I O N;
PLAY : P L A Y;
ADD : A D D;
ENABLE : E N A B L E;
STOP : S T O P;
PITCH : P I T C H;
TURN : T U R N;

// Statement delimiter
STATE_END : ';';
DOT : '.';

// Numbers
NUM : [0-9]+ ('.' [0-9]*)?
	  | '.' [0-9]+
;

// Brackets
ARG_START : '(' -> pushMode(ARG_MODE);
KEY_START : '[' -> pushMode(ARG_MODE);

WS : [\t \u3000\r\n]+ -> skip;
COMMENT : ('#' | '//') ~[\r\n]* -> skip;
ERROR_CHAR : . -> skip;

// Ignore case
fragment A : [aA];
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];

mode ARG_MODE;
ARG_END: ')' WS* STATE_END -> popMode;
KEY_END : ']' WS* DOT -> popMode;
ARG_FORCE_END: STATE_END -> popMode; //このルールは正常な構文であれば必ず通らないが、ARG_MODEを抜けるために作っておく。
COMMA : ',';
NULL : N U L L;
ARG_WS : WS -> skip;
ARG_COMMENT : COMMENT -> skip;
CHAR : .;
