parser grammar MapGrammarParser;
options{
	tokenVocab=MapGrammarLexer;
}

compileUnit :
	varAssign+ EOF
	;

statement :
	CURVE expr END
	;

varAssign :
	v=var EQUAL expr END;

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