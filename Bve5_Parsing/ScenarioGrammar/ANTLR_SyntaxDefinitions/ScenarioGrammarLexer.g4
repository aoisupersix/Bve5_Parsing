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
ROUTE : R O U T E -> pushMode(PATH_MODE);
VEHICLE : V E H I C L E -> pushMode(PATH_MODE);
TITLE : T I T L E;
IMAGE : I M A G E;
ROUTETITLE : R O U T E T I T L E;
VEHICLETITLE : V E H I C L E T I T L E;
AUTHOR : A U T H O R;
COMMENT : C O M M E N T;

EQUAL : '=' -> pushMode(INPUT_TEXT_MODE);

ESCAPE_COMMENT : SECTION_COMMENT -> skip;
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

//各構文内(主にmode)で使用する字句
fragment NEWLINE: ('\r' '\n'? | '\n');
fragment SECTION_WS: [\t ]+;
fragment SECTION_COMMENT: ('#' | ';') ~[\r\n]*;

mode ENCODING_MODE;
E_WS : SECTION_WS -> skip;
ENCODE_END : NEWLINE -> popMode;
ENCODE_CHAR : .;

mode PATH_MODE;
P_WS: SECTION_WS -> skip;
PATH_END: NEWLINE -> popMode;
PATH_EQUAL: '=' -> pushMode(INPUT_PATH_MODE);

mode INPUT_PATH_MODE;
IP_WS: SECTION_WS -> skip;
IP_COMMENT: SECTION_COMMENT -> skip;
INPUT_PATH_END: NEWLINE -> mode(DEFAULT_MODE);
ASTERISK : '*' -> pushMode(WEIGHTING_MODE);
SECTION : '|';
FILE_PATH : ~[*|#;\r\n]+;

mode WEIGHTING_MODE;
W_WS : SECTION_WS -> skip;
NUM : '0'..'9'+ ('.' ('0'..'9')+)? -> popMode;

mode INPUT_TEXT_MODE;
IT_WS : SECTION_WS -> skip;
IT_COMMENT : SECTION_COMMENT -> skip;
INPUT_TEXT_END : NEWLINE -> popMode;
INPUT_TEXT_CHAR : .;
