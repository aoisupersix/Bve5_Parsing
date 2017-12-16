/*
 * ScenarioGrammarのANTLR字句定義ファイルです
 */
lexer grammar ScenarioGrammarLexer;

//ヘッダー
BVETS : B V E T S;
MAP : M A P;

//シナリオ情報
ROUTE : R O U T E;
VEHICLE : V E H I C L E;
TITLE : T I T L E;
ROUTETITLE : R O U T E T I T L E;
VEHICLETITLE : V E H I C L E T I T L E;
AUTHOR : A U T H O R;
COMMENT : C O M M E N T;

EQUAL : '=' -> pushMode(WEIGHTING_MODE);

ESCAPE_COMMENT : ('#' | ';') ~[\r\n]* -> skip;
WHITESPACE : [\t ]+ -> skip;

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

mode STRING_MODE;
S_NEWLINE : ( '\r' '\n'? | '\n') -> popMode;
S_CHAR : .;

mode WEIGHTING_MODE;
W_NEWLINE : ('\r' '\n'? | '\n') -> popMode;
W_WS : [\t ]+ -> skip;
ASTERISK : '*';
NUM : '0'..'9'+ ('.' ('0'..'9')+)?;
W_SECTION : '|';
W_CHAR : .;
