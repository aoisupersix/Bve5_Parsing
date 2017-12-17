/*
 * ScenarioGrammarのANTLR字句定義ファイルです
 */
lexer grammar ScenarioGrammarLexer;

//ヘッダー
BVETS : B V E T S;
SCENARIO : S C E N A R I O;
VERSION : '0'..'9'+ ('.' ('0'..'9')+)?;
SELECT_ENCODE : ':' -> pushMode(ENCODING_MODE);

//シナリオ情報
ROUTE : R O U T E;
VEHICLE : V E H I C L E;
TITLE : T I T L E;
IMAGE : I M A G E;
ROUTETITLE : R O U T E T I T L E;
VEHICLETITLE : V E H I C L E T I T L E;
AUTHOR : A U T H O R;
COMMENT : C O M M E N T;

EQUAL : '=' -> pushMode(TEXT_MODE);

ESCAPE_COMMENT : ('#' | ';') ~[\r\n]* -> skip;
WHITESPACE : [\t \r\n]+ -> skip;

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

mode ENCODING_MODE;
E_WS : [\t ]+ -> skip;
HEADER_END : ('\r' '\n'? | '\n') -> popMode;
ENCODE_CHAR : .;

mode TEXT_MODE;
T_COMMENT : ('#' | ';') ~[\r\n]* -> skip;
NEWLINE : ('\r' '\n'? | '\n') -> popMode;
T_WS : [\t ]+ -> skip;
ASTERISK : '*' -> pushMode(WEIGHTING_MODE);
SECTION : '|';
CHAR : .;

mode WEIGHTING_MODE;
W_WS : [\t ]+ -> skip;
NUM : '0'..'9'+ ('.' ('0'..'9')+)? -> popMode;

