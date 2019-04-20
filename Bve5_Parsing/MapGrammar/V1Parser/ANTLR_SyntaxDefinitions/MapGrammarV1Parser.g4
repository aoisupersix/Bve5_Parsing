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
	  DOT func=GAUGE ARG_START value=arg ARG_END
	| DOT func=BEGIN_TRANSITION ARG_START ARG_END
	| DOT func=BEGIN_CIRCULAR ARG_START radius=arg COMMA cant=arg ARG_END
	| DOT func=END ARG_START ARG_END
	;

// Gradient of own track
gradient :
	  DOT func=BEGIN_TRANSITION ARG_START ARG_END
	| DOT func=BEGIN_CONST ARG_START gradientArgs=arg ARG_END	// Since the argument name gradient is the same, we use gradientArgs
	| DOT func=END ARG_START ARG_END
	;

// Other track
track :
	  KEY_START key=arg KEY_END func=GAUGE ARG_START gauge=arg ARG_END
	| KEY_START key=arg KEY_END func=POSITION ARG_START x=arg COMMA y=arg ARG_END
	| KEY_START key=arg KEY_END func=POSITION ARG_START x=arg COMMA y=arg COMMA radiusH=arg COMMA radiusV=arg ARG_END
	| KEY_START key=arg KEY_END func=CANT ARG_START cant=arg ARG_END
	;

// Structure
structure :
	  DOT func=LOAD ARG_START path=arg ARG_END
	| KEY_START key=arg KEY_END func=PUT ARG_START trackKey=arg COMMA x=arg COMMA y=arg COMMA z=arg COMMA rx=arg COMMA ry=arg COMMA rz=arg COMMA tilt=arg COMMA span=arg ARG_END
	| KEY_START key=arg KEY_END func=PUT0 ARG_START trackKey=arg COMMA tilt=arg COMMA span=arg ARG_END
	| KEY_START key=arg KEY_END func=PUTBETWEEN ARG_START trackKey1=arg COMMA trackKey2=arg ARG_END
	;

// Continious structure
repeater :
	  KEY_START key=arg KEY_END func=BEGIN ARG_START trackKey=arg COMMA x=arg COMMA y=arg COMMA z=arg COMMA rx=arg COMMA ry=arg COMMA rz=arg COMMA tilt=arg COMMA span=arg COMMA interval=arg args+ ARG_END
	| KEY_START key=arg KEY_END func=BEGIN0 ARG_START trackKey=arg COMMA tilt=arg COMMA span=arg COMMA interval=arg args+ ARG_END
	| KEY_START key=arg KEY_END func=END ARG_START ARG_END
	;

// Background
background :
	DOT func=CHANGE ARG_START structureKey=arg ARG_END
	;

// Station
station :
	  DOT func=LOAD ARG_START path=arg ARG_END
	| KEY_START key=arg KEY_END func=PUT ARG_START door=arg COMMA margin1=arg COMMA margin2=arg ARG_END
	;

// Section (block)
section :
	DOT func=BEGIN_NEW ARG_START arg args* ARG_END
	;

// Signal
signal :
	  DOT func=LOAD ARG_START path=arg ARG_END
	| DOT func=SPEEDLIMIT ARG_START arg args* ARG_END
	| KEY_START key=arg KEY_END func=PUT ARG_START sectionArgs=arg COMMA trackKey=arg COMMA x=arg COMMA y=arg ARG_END
	| KEY_START key=arg KEY_END func=PUT ARG_START sectionArgs=arg COMMA trackKey=arg COMMA x=arg COMMA y=arg COMMA z=arg COMMA rx=arg COMMA ry=arg COMMA rz=arg COMMA tilt=arg COMMA span=arg ARG_END
	;

// Beacon (ground coil)
beacon :
	DOT func=PUT ARG_START type=arg COMMA sectionArgs=arg COMMA sendData=arg ARG_END
	;

// Speed limit
speedLimit :
	  DOT func=BEGIN ARG_START v=arg ARG_END
	| DOT func=END ARG_START ARG_END
	;

// Leading train
preTrain :
	DOT func=PASS ARG_START arg ARG_END
	;

// Light
light :
	  DOT func=AMBIENT ARG_START red=arg COMMA green=arg COMMA blue=arg ARG_END
	| DOT func=DIFFUSE ARG_START red=arg COMMA green=arg COMMA blue=arg ARG_END
	| DOT func=DIRECTION ARG_START pitch=arg COMMA yaw=arg ARG_END
	;

// Fog effect
fog :
	DOT func=SET ARG_START density=arg COMMA red=arg COMMA green=arg COMMA blue=arg ARG_END
	;

// Illuminance of instrument panel
cabIlluminance :
	DOT func=SET ARG_START value=arg ARG_END
	;

// Track irregularity
irregularity :
	DOT func=CHANGE ARG_START x=arg COMMA y=arg COMMA r=arg COMMA lx=arg COMMA ly=arg COMMA lr=arg ARG_END
	;

// Wheel-rail adhesion
adhesion :
	  DOT func=CHANGE ARG_START a=arg ARG_END
	| DOT func=CHANGE ARG_START a=arg COMMA b=arg COMMA c=arg ARG_END
	;

// Sound
sound :
	  DOT func=LOAD ARG_START path=arg ARG_END
	| KEY_START key=arg KEY_END func=PLAY ARG_START ARG_END
	;

// Sound on ground
sound3d :
	  DOT func=LOAD ARG_START path=arg ARG_END
	| KEY_START key=arg KEY_END func=PUT ARG_START x=arg COMMA y=arg ARG_END
	;

// Wheel rolling sound
rollingNoise :
	DOT func=CHANGE ARG_START index=arg ARG_END
	;

// Flange rasping sound
flangeNoise :
	DOT func=CHANGE ARG_START index=arg ARG_END
	;

// Rail joint sound
jointNoise :
	DOT func=PLAY ARG_START index=arg ARG_END
	;

// Other train
train :
	  DOT func=ADD ARG_START trainKey=arg COMMA path=arg ARG_END
	| DOT func=ADD ARG_START trainKey=arg COMMA path=arg COMMA trackKey=arg COMMA direction=arg ARG_END
	| KEY_START key=arg KEY_END func=ENABLE ARG_START time=arg ARG_END
	| KEY_START key=arg KEY_END func=STOP ARG_START decelerate=arg COMMA stopTime=arg COMMA accelerate=arg COMMA speed=arg ARG_END
	| KEY_START key=arg KEY_END func=SET_TRACK ARG_START trackKey=arg COMMA direction=arg ARG_END
	;

// Legacy syntax
legacy :
	  DOT func=FOG ARG_START startArg=arg COMMA endArg=arg COMMA red=arg COMMA green=arg COMMA blue=arg ARG_END
	| DOT func=CURVE ARG_START radius=arg COMMA cant=arg ARG_END
	| DOT func=PITCH ARG_START rate=arg ARG_END
	| DOT func=TURN ARG_START slope=arg ARG_END
	;

// Continuous mathematical argument
args :
	COMMA arg
	;

arg :
	  str=string
	| nullSyntax=NULL
	| /* epsilon */
	;

string returns [string text]:
	v=string_text { $text = $v.text ;}
	;
	
string_text :
	CHAR*
	;