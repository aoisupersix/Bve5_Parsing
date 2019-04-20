/*
 *	MapGrammarV1のANTLR構文定義ファイルです。
 */
parser grammar MapGrammarV1Parser;

options {
	tokenVocab=MapGrammarV1Lexer;
}

root :
	(statement STATE_END*)* EOF
	;

statement :
	  distance						#distState
	| CURVE curve 						#curveState
	| GRADIENT gradient 				#gradientState
	| TRACK track 						#trackState
	| STRUCTURE structure 				#structureState
	| REPEATER repeater 				#repeaterState
	| BACKGROUND background 			#backgroundState
	| STATION station 					#stationState
	| SECTION section 					#sectionState
	| SIGNAL signal 					#signalState
	| BEACON beacon 					#beaconState
	| SPEEDLIMIT speedLimit 			#speedLimitState
	| PRETRAIN preTrain 				#preTrainState
	| LIGHT light 						#lightState
	| FOG fog 							#fogState
	| CABILLUMINANCE cabIlluminance 	#cabIlluminanceState
	| IRREGULARITY irregularity 		#irregularityState
	| ADHESION adhesion 				#adhesionState
	| SOUND sound 						#soundState
	| SOUND3D sound3d 					#sound3dState
	| ROLLINGNOISE rollingNoise 		#rollingNoiseState
	| FLANGENOISE flangeNoise 			#flangeNoiseState
	| JOINTNOISE jointNoise 			#jointNoiseState
	| TRAIN train 						#trainState
	| LEGACY legacy						#legacyState
	;

// Current distance
distance :
	dist=NUM
	;

// Lateral curve of own track
curve :
	  DOT func=GAUGE ARG_START value=nullableExpr ARG_END
	| DOT func=BEGIN_TRANSITION ARG_START ARG_END
	| DOT func=BEGIN_CIRCULAR ARG_START radius=nullableExpr COMMA cant=nullableExpr ARG_END
	| DOT func=END ARG_START ARG_END
	;

// Gradient of own track
gradient :
	  DOT func=BEGIN_TRANSITION ARG_START ARG_END
	| DOT func=BEGIN_CONST ARG_START gradientArgs=nullableExpr ARG_END	// Since the argument name gradient is the same, we use gradientArgs
	| DOT func=END ARG_START ARG_END
	;

// Other track
track :
	  KEY_START key=expr KEY_END func=GAUGE ARG_START gauge=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=POSITION ARG_START x=nullableExpr COMMA y=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=POSITION ARG_START x=nullableExpr COMMA y=nullableExpr COMMA radiusH=nullableExpr COMMA radiusV=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=CANT ARG_START cant=nullableExpr ARG_END
	;

// Structure
structure :
	  DOT func=LOAD ARG_START path=expr ARG_END
	| KEY_START key=expr KEY_END func=PUT ARG_START trackKey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=PUT0 ARG_START trackKey=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=PUTBETWEEN ARG_START trackKey1=nullableExpr COMMA trackKey2=nullableExpr ARG_END
	;

// Continious structure
repeater :
	  KEY_START key=expr KEY_END func=BEGIN ARG_START trackKey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr COMMA interval=nullableExpr exprArgs+ ARG_END
	| KEY_START key=expr KEY_END func=BEGIN0 ARG_START trackKey=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr COMMA interval=nullableExpr exprArgs+ ARG_END
	| KEY_START key=expr KEY_END func=END ARG_START ARG_END
	;

// Background
background :
	DOT func=CHANGE ARG_START structureKey=nullableExpr ARG_END
	;

// Station
station :
	  DOT func=LOAD ARG_START path=expr ARG_END
	| KEY_START key=expr KEY_END func=PUT ARG_START door=nullableExpr COMMA margin1=nullableExpr COMMA margin2=nullableExpr ARG_END
	;

// Section (block)
section :
	DOT func=BEGIN_NEW ARG_START nullableExpr exprArgs* ARG_END
	;

// Signal
signal :
	  DOT func=LOAD ARG_START path=expr ARG_END
	| DOT func=SPEEDLIMIT ARG_START nullableExpr exprArgs* ARG_END
	| KEY_START key=expr KEY_END func=PUT ARG_START sectionArgs=nullableExpr COMMA trackKey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=PUT ARG_START sectionArgs=nullableExpr COMMA trackKey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr ARG_END
	;

// Beacon (ground coil)
beacon :
	DOT func=PUT ARG_START type=nullableExpr COMMA sectionArgs=nullableExpr COMMA sendData=nullableExpr ARG_END
	;

// Speed limit
speedLimit :
	  DOT func=BEGIN ARG_START v=nullableExpr ARG_END
	| DOT func=END ARG_START ARG_END
	;

// Leading train
preTrain :
	DOT func=PASS ARG_START nullableExpr ARG_END
	;

// Light
light :
	  DOT func=AMBIENT ARG_START red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr ARG_END
	| DOT func=DIFFUSE ARG_START red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr ARG_END
	| DOT func=DIRECTION ARG_START pitch=nullableExpr COMMA yaw=nullableExpr ARG_END
	;

// Fog effect
fog :
	DOT func=SET ARG_START density=nullableExpr COMMA red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr ARG_END
	;

// Illuminance of instrument panel
cabIlluminance :
	DOT func=SET ARG_START value=nullableExpr ARG_END
	;

// Track irregularity
irregularity :
	DOT func=CHANGE ARG_START x=nullableExpr COMMA y=nullableExpr COMMA r=nullableExpr COMMA lx=nullableExpr COMMA ly=nullableExpr COMMA lr=nullableExpr ARG_END
	;

// Wheel-rail adhesion
adhesion :
	  DOT func=CHANGE ARG_START a=nullableExpr ARG_END
	| DOT func=CHANGE ARG_START a=nullableExpr COMMA b=nullableExpr COMMA c=nullableExpr ARG_END
	;

// Sound
sound :
	  DOT func=LOAD ARG_START path=expr ARG_END
	| KEY_START key=expr KEY_END func=PLAY ARG_START ARG_END
	;

// Sound on ground
sound3d :
	  DOT func=LOAD ARG_START path=expr ARG_END
	| KEY_START key=expr KEY_END func=PUT ARG_START x=nullableExpr COMMA y=nullableExpr ARG_END
	;

// Wheel rolling sound
rollingNoise :
	DOT func=CHANGE ARG_START index=nullableExpr ARG_END
	;

// Flange rasping sound
flangeNoise :
	DOT func=CHANGE ARG_START index=nullableExpr ARG_END
	;

// Rail joint sound
jointNoise :
	DOT func=PLAY ARG_START index=nullableExpr ARG_END
	;

// Other train
train :
	  DOT func=ADD ARG_START trainKey=nullableExpr COMMA path=expr ARG_END
	| DOT func=ADD ARG_START trainKey=nullableExpr COMMA path=expr COMMA trackKey=nullableExpr COMMA direction=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=ENABLE ARG_START time=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=STOP ARG_START decelerate=nullableExpr COMMA stopTime=nullableExpr COMMA accelerate=nullableExpr COMMA speed=nullableExpr ARG_END
	| KEY_START key=expr KEY_END func=SET_TRACK ARG_START trackKey=nullableExpr COMMA direction=nullableExpr ARG_END
	;

// Legacy syntax
legacy :
	  DOT func=FOG ARG_START startArg=nullableExpr COMMA endArg=nullableExpr COMMA red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr ARG_END
	| DOT func=CURVE ARG_START radius=nullableExpr COMMA cant=nullableExpr ARG_END
	| DOT func=PITCH ARG_START rate=nullableExpr ARG_END
	| DOT func=TURN ARG_START slope=nullableExpr ARG_END
	;

// Continuous mathematical argument
exprArgs :
	COMMA arg=nullableExpr
	;

nullableExpr :
	  expr
	| nullSyntax=NULL
	| /* epsilon */
	;

expr :
	  num=NUM #numberExpr
	| str=string	#stringExpr
	;

string returns [string text]:
	v=CHAR* { $text = $v.text ;}
	;