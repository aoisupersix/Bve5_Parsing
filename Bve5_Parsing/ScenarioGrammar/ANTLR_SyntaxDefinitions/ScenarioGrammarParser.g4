/*
 * ScenarioGrammarのANTLR構文定義ファイルです
 */
parser grammar ScenarioGrammarParser;

options{
	tokenVocab=ScenarioGrammarLexer;
}
root :
	ROUTE EQUAL weight_path (SECTION weight_path)* NEWLINE?
	;

weight_path :
	string (ASTERISK NUM)?
	;

string :
	CHAR*
	;