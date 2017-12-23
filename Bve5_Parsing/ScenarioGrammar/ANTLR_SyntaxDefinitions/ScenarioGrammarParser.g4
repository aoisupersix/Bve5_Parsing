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
	  stateName=ROUTE EQUAL weight_path (SECTION weight_path)* NEWLINE?		#routeState
	| stateName=VEHICLE EQUAL weight_path (SECTION weight_path)* NEWLINE?	#vehicleState
	| stateName=TITLE EQUAL string NEWLINE?									#titleState
	| stateName=IMAGE EQUAL string NEWLINE?									#imageState
	| stateName=ROUTETITLE EQUAL string NEWLINE?							#routeTitleState
	| stateName=VEHICLETITLE EQUAL string NEWLINE?							#vehicleTitleState
	| stateName=AUTHOR EQUAL string NEWLINE?								#authorState
	| stateName=COMMENT EQUAL string NEWLINE?								#commentState
	;

encoding returns [string text]:
	v=ENCODE_CHAR* {$text = $v.text; }
	;

weight_path :
	string (ASTERISK NUM)?
	;

string :
	CHAR*
	;