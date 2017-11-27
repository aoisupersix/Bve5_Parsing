parser grammar MapGrammarParser;
options{
	tokenVocab=MapGrammarLexer;
}

root :
	(statement STATE_END)* EOF
	;

statement :
	  distance								#distState
	| CURVE curve							#curveState
	| GRADIENT gradient						#gradientState
	| varAssign								#varAssignState
	;

//ãóó£íˆ
distance :
	expr
	;

//ïΩñ ã»ê¸
curve :
	  DOT func1=SET_GAUGE OPN_PAR value=nullableExpr CLS_PAR
	| DOT func1=SET_CENTER OPN_PAR x=nullableExpr CLS_PAR
	| DOT func1=SET_FUNCTION OPN_PAR id=nullableExpr CLS_PAR
	| DOT func1=BEGIN_TRANSITION OPN_PAR CLS_PAR
	| DOT func1=BEGIN OPN_PAR radius=nullableExpr (COMMA cant=nullableExpr)? CLS_PAR
	| DOT func1=END OPN_PAR CLS_PAR
	| DOT func1=INTERPOLATE OPN_PAR radius=nullableExpr CLS_PAR
	| DOT func1=INTERPOLATE OPN_PAR radius=nullableExpr COMMA cant=nullableExpr CLS_PAR
	| DOT func1=CHANGE OPN_PAR radius=nullableExpr CLS_PAR
	;

//ècã»ê¸
gradient :
	  DOT func1=BEGIN_TRANSITION OPN_PAR CLS_PAR
	| DOT func1=BEGIN OPN_PAR gradientArgs=nullableExpr CLS_PAR	//à¯êîñºgradientÇ™îÌÇÈÇÃÇ≈gradientArgsÇ…ÇµÇƒÇ¢ÇÈ
	| DOT func1=END OPN_PAR CLS_PAR
	| DOT func1=INTERPOLATE OPN_PAR gradientArgs=nullableExpr CLS_PAR
	;

//ïœêî/êîéÆ
varAssign :
	v=var EQUAL expr;

nullableExpr :
	expr
	| /* epsilon */
	;

expr :
	  OPN_PAR expr CLS_PAR							#parensExpr
	| op=(PLUS | MINUS) expr						#unaryExpr
	| left=expr op=(MULT | DIV) right=expr			#infixExpr
	| left=expr op=(PLUS | MINUS | MOD) right=expr	#infixExpr
	| v=var											#varExpr
	| num=NUM										#numberExpr
	| str=string									#stringExpr
	;

var returns [string varName]:
	VAR_START v=VAR { $varName = $v.text ;}
	;

string returns [string text]:
	QUOTE v=string_text RQUOTE { $text = $v.text ;}
	;

string_text :
	CHAR*
	;