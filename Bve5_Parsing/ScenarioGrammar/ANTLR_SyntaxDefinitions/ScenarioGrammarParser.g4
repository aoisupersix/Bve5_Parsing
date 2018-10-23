/*
 * ScenarioGrammarのANTLR構文定義ファイルです
 */
parser grammar ScenarioGrammarParser;

options{
	tokenVocab=ScenarioGrammarLexer;
}
root :
	BVETS SCENARIO VERSION ( SELECT_ENCODE encoding ENCODE_END?)? statement* EOF
	;

statement :
	  stateName=ROUTE PATH_EQUAL (weight_path (SECTION weight_path)*)? (INPUT_PATH_END | PATH_END)?		#routeState
	| stateName=VEHICLE PATH_EQUAL (weight_path (SECTION weight_path)*)? (INPUT_PATH_END | PATH_END)?	#vehicleState
	| stateName=TITLE EQUAL string INPUT_TEXT_END?														#titleState
	| stateName=IMAGE EQUAL string INPUT_TEXT_END?														#imageState
	| stateName=ROUTETITLE EQUAL string INPUT_TEXT_END?													#routeTitleState
	| stateName=VEHICLETITLE EQUAL string INPUT_TEXT_END?												#vehicleTitleState
	| stateName=AUTHOR EQUAL string INPUT_TEXT_END?														#authorState
	| stateName=COMMENT EQUAL string INPUT_TEXT_END?													#commentState
	;

encoding returns [string text]:
	v=encode_string {$text = $v.text; }
	;

encode_string :
	ENCODE_CHAR*
	;

weight_path :
	path=FILE_PATH (ASTERISK NUM)?
	;

string :
	INPUT_TEXT_CHAR*
	;