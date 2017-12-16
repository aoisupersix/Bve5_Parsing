/*
 * ScenarioGrammarのANTLR構文定義ファイルです
 */
parser grammar ScenarioGrammarParser;

options{
	tokenVocab=ScenarioGrammarLexer;
}
root :
	ROUTE EQUAL weight_path (W_SECTION weight_path)* W_NEWLINE;

weight_path :
	string_path (ASTERISK NUM)?
	;

string_path :
	W_CHAR*
	;