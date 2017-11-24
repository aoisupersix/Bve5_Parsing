lexer grammar MapGrammarLexer;

//各構文
CURVE : C U R V E;

//ステートメント区切り
END : ';';

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

//文字列
QUOTE : '\'' -> pushMode(STRING_MODE) ;
WS : [ \t\r\n]+ -> skip ;
NEWLINE : ( '\r' '\n'? | '\n');
OUTER_CHAR : . -> skip ;

mode STRING_MODE;
RQUOTE : '\'' -> popMode ;
CHAR : . ;

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