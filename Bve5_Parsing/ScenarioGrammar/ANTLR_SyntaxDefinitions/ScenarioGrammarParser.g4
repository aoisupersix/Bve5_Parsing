/*
 * ScenarioGrammarのANTLR構文定義ファイルです
 */
parser grammar ScenarioGrammarParser;

options{
	tokenVocab=ScenarioGrammarLexer;
}
root :
	statement* EOF
	;

statement :
	  ROUTE EQUAL weight_path (SECTION weight_path)* NEWLINE?
	| VEHICLE EQUAL weight_path (SECTION weight_path)* NEWLINE?
	| TITLE EQUAL string NEWLINE?
	| IMAGE EQUAL string NEWLINE?
	| ROUTETITLE EQUAL string NEWLINE?
	| VEHICLETITLE EQUAL string NEWLINE?
	| AUTHOR EQUAL string NEWLINE?
	| COMMENT EQUAL string NEWLINE?
	;

weight_path :
	string (ASTERISK NUM)?
	;

string :
	CHAR*
	;