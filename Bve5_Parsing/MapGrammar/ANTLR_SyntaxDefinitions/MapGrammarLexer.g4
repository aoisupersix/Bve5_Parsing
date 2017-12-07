lexer grammar MapGrammarLexer;

//インクルードディレクティブ
INCLUDE : I N C L U D E;

//マップ要素名
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
DRAWDISTANCE : D R A W D I S T A N C E;
CABILLUMINANCE : C A B I L L U M I N A N C E;
IRREGULARITY : I R R E G U L A R I T Y;
ADHESION : A D H E S I O N;
SOUND : S O U N D;
SOUND3D : S O U N D '3' D;
ROLLINGNOISE : R O L L I N G N O I S E;
FLANGENOISE : F L A N G E N O I S E;
JOINTNOISE : J O I N T N O I S E;
TRAIN : T R A I N;

X_ELEMENT : X;
Y_ELEMENT : Y;
CANT_ELEMENT : C A N T;

//関数名
SET_GAUGE : S E T G A U G E;
SET_CENTER : S E T C E N T E R;
SET_FUNCTION : S E T F U N C T I O N;
BEGIN_TRANSITION : B E G I N T R A N S I T I O N;
BEGIN : B E G I N;
BEGIN0 : B E G I N '0';
END : E N D;
INTERPOLATE : I N T E R P O L A T E;
CHANGE : C H A N G E;
POSITION : P O S I T I O N;
LOAD : L O A D;
PUT : P U T;
PUT0 : P U T '0';
PUTBETWEEN : P U T B E T W E E N;
SET_SPEEDLIMIT : S E T S P E E D L I M I T;
PASS : P A S S;
AMBIENT : A M B I E N T;
DIFFUSE : D I F F U S E;
DIRECTION : D I R E C T I O N;
PLAY : P L A Y;
ADD : A D D;
ENABLE : E N A B L E;
STOP : S T O P;

//ステートメント区切り
STATE_END : ';';
DOT : '.';
COMMA : ',';

//数字
NUM : '0'..'9'+ ('.' ('0'..'9')+)?;
NULL : N U L L;

//距離変数
DISTANCE : D I S T A N C E;

//演算子
EQUAL : '=';
PLUS : '+';
MINUS : '-';
MULT : '*';
DIV : '/';
MOD : '%';

//数学関数
ABS : A B S;
ATAN2 : A T A N '2';
CEIL : C E I L;
COS : C O S;
EXP : E X P;
FLOOR : F L O O R;
LOG : L O G;
POW : P O W;
RAND : R A N D;
SIN : S I N;
SQRT : S Q R T;

//括弧
OPN_PAR : '(';
CLS_PAR : ')';
OPN_BRA : '[';
CLS_BRA : ']';

//ignore case
fragment A:('a'|'A');
fragment B:('b'|'B');
fragment C:('c'|'C');
fragment D:('d'|'D');
fragment E:('e'|'E');
fragment F:('f'|'F');
fragment G:('g'|'G');
fragment H:('h'|'H');
fragment I:('i'|'I');
fragment J:('j'|'J');
fragment K:('k'|'K');
fragment L:('l'|'L');
fragment M:('m'|'M');
fragment N:('n'|'N');
fragment O:('o'|'O');
fragment P:('p'|'P');
fragment Q:('q'|'Q');
fragment R:('r'|'R');
fragment S:('s'|'S');
fragment T:('t'|'T');
fragment U:('u'|'U');
fragment V:('v'|'V');
fragment W:('w'|'W');
fragment X:('x'|'X');
fragment Y:('y'|'Y');
fragment Z:('z'|'Z');

WHITESPACE : (' ' | '\t' | '\r' | '\n' )+ -> skip;
COMMENT : ('//' | '#') ~[\r\n]* -> skip;

//変数
VAR_START : '$';
VAR : [a-zA-Z0-9_]+;

//文字列
QUOTE : '\'' -> pushMode(STRING_MODE) ;
//NEWLINE : ( '\r' '\n'? | '\n');
OUTER_CHAR : . -> skip ;

mode STRING_MODE;
RQUOTE : '\'' -> popMode ;
CHAR : . ;