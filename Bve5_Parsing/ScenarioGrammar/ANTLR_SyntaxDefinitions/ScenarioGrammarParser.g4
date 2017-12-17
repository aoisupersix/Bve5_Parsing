/*
 * ScenarioGrammarのANTLR構文定義ファイルです
 */
parser grammar ScenarioGrammarParser;

options{
	tokenVocab=ScenarioGrammarLexer;
}
root :
	BVETS SCENARIO VERSION ( SELECT_ENCODE encoding HEADER_END)? statement* EOF
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

encoding :
	ENCODE_CHAR*
	;

weight_path :
	string (ASTERISK NUM)?
	;

string :
	CHAR*
	;