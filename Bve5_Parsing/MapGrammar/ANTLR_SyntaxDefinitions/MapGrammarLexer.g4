lexer grammar MapGrammarLexer;

//マップ要素名
CURVE : C U R V E;
GRADIENT : G R A D I E N T;
TRACK : T R A C K;

X_ELEMENT : X;
Y_ELEMENT : Y;
CANT_ELEMENT : C A N T;

//関数名
SET_GAUGE : S E T G A U G E;
SET_CENTER : S E T C E N T E R;
SET_FUNCTION : S E T F U N C T I O N;
BEGIN_TRANSITION : B E G I N T R A N S I T I O N;
BEGIN : B E G I N;
END : E N D;
INTERPOLATE : I N T E R P O L A T E;
CHANGE : C H A N G E;
POSITION : P O S I T I O N;

//ステートメント区切り
STATE_END : ';';
DOT : '.';
COMMA : ',';

//数字
NUM : '0'..'9'+ ('.' ('0'..'9')+)?;

//変数
VAR_START : '$';
VAR : [a-zA-Z0-9_]+;

//演算子
EQUAL : '=';
PLUS : '+';
MINUS : '-';
MULT : '*';
DIV : '/';
MOD : '%';

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

WHITESPACE : (' ' | '\t' | '\r' | '\n' )+ -> channel(HIDDEN);

//文字列
QUOTE : '\'' -> pushMode(STRING_MODE) ;
//NEWLINE : ( '\r' '\n'? | '\n');
OUTER_CHAR : . -> skip ;

mode STRING_MODE;
RQUOTE : '\'' -> popMode ;
CHAR : . ;