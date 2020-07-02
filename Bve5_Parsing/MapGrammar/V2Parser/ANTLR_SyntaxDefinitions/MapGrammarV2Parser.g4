/*
 *	MapGrammarV2のANTLR構文定義ファイルです。
 */
parser grammar MapGrammarV2Parser;
options{
	tokenVocab=MapGrammarV2Lexer;
}

root :
	(statement STATE_END+)* EOF
	;

statement :
	  distance							#distState
	| varAssign 						#varAssignState
	| INCLUDE include					#includeState
	| GAUGE gauge						#gaugeState
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
	| SPEEDLIMIT speedlimit 			#speedlimitState
	| PRETRAIN pretrain 				#pretrainState
	| LIGHT light 						#lightState
	| FOG fog 							#fogState
	| DRAWDISTANCE drawdistance 		#drawdistanceState
	| CABILLUMINANCE cabilluminance 	#cabilluminanceState
	| IRREGULARITY irregularity 		#irregularityState
	| ADHESION adhesion 				#adhesionState
	| SOUND sound 						#soundState
	| SOUND3D sound3d 					#sound3dState
	| ROLLINGNOISE rollingnoise 		#rollingnoiseState
	| FLANGENOISE flangenoise 			#flangenoiseState
	| JOINTNOISE jointnoise 			#jointnoiseState
	| TRAIN train 						#trainState
	| LEGACY legacy						#legacyState
	;

//距離程
distance :
	expr
	;

//変数/数式
varAssign :
	v=var EQUAL expr;

//インクルード構文
include :
	filepath=expr
	;

gauge :
	DOT func=SET OPN_PAR value=nullableExpr CLS_PAR
    ;

//平面曲線
curve :
	  DOT func=(SET_GAUGE | GAUGE) OPN_PAR value=nullableExpr CLS_PAR
	| DOT func=SET_CENTER OPN_PAR x=nullableExpr CLS_PAR
	| DOT func=SET_FUNCTION OPN_PAR id=nullableExpr CLS_PAR
	| DOT func=BEGIN_TRANSITION OPN_PAR CLS_PAR
	| DOT func=(BEGIN | BEGIN_CIRCULAR) OPN_PAR radius=nullableExpr (COMMA cant=nullableExpr)? CLS_PAR
	| DOT func=END OPN_PAR CLS_PAR
	| DOT func=INTERPOLATE OPN_PAR radius=nullableExpr (COMMA cant=nullableExpr)? CLS_PAR
	| DOT func=CHANGE OPN_PAR radius=nullableExpr CLS_PAR
	;

//縦曲線
gradient :
	  DOT func=BEGIN_TRANSITION OPN_PAR CLS_PAR
	| DOT func=(BEGIN | BEGIN_CONST) OPN_PAR gradientArgs=nullableExpr CLS_PAR	//引数名gradientが被るのでgradientArgsにしている
	| DOT func=END OPN_PAR CLS_PAR
	| DOT func=INTERPOLATE OPN_PAR gradientArgs=nullableExpr CLS_PAR
	;

//他軌道
track :
	| OPN_BRA key=expr CLS_BRA DOT element=X_ELEMENT DOT func=INTERPOLATE OPN_PAR x=nullableExpr (COMMA radius=nullableExpr)? CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=Y_ELEMENT DOT func=INTERPOLATE OPN_PAR y=nullableExpr (COMMA radius=nullableExpr)? CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=POSITION OPN_PAR x=nullableExpr COMMA y=nullableExpr (COMMA radiush=nullableExpr (COMMA radiusv=nullableExpr)?)? CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=SET_GAUGE OPN_PAR gaugeArgs=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=SET_CENTER OPN_PAR x=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=SET_FUNCTION OPN_PAR id=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=BEGIN_TRANSITION OPN_PAR CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=BEGIN OPN_PAR cant=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=END OPN_PAR CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT element=CANT_ELEMENT DOT func=INTERPOLATE OPN_PAR cant=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=CANT_ELEMENT OPN_PAR cant=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=GAUGE OPN_PAR gaugeArgs=nullableExpr CLS_PAR
	;

//ストラクチャ
structure :
	  DOT func=LOAD OPN_PAR filepath=expr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUT OPN_PAR trackkey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUT0 OPN_PAR trackkey=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUTBETWEEN OPN_PAR trackkey1=nullableExpr COMMA trackkey2=nullableExpr (COMMA flag=nullableExpr)? CLS_PAR
	;

//連続ストラクチャ
repeater :
	  OPN_BRA key=expr CLS_BRA DOT func=BEGIN OPN_PAR trackkey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr COMMA interval=nullableExpr exprArgs+ CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=BEGIN0 OPN_PAR trackkey=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr COMMA interval=nullableExpr exprArgs+ CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=END OPN_PAR CLS_PAR
	;

//背景
background :
	DOT func=CHANGE OPN_PAR structurekey=nullableExpr CLS_PAR
	;

//停車場
station :
	  DOT func=LOAD OPN_PAR filepath=expr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUT OPN_PAR door=nullableExpr COMMA margin1=nullableExpr COMMA margin2=nullableExpr CLS_PAR
	;

//閉そく
section :
	  DOT func=(BEGIN | BEGIN_NEW) OPN_PAR nullableExpr exprArgs* CLS_PAR
	| DOT func=SET_SPEEDLIMIT OPN_PAR nullableExpr exprArgs* CLS_PAR
	;

//信号機
signal :
	  DOT func=LOAD OPN_PAR filepath=expr CLS_PAR
	| DOT func=SPEEDLIMIT OPN_PAR nullableExpr exprArgs* CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUT OPN_PAR sectionArgs=nullableExpr COMMA trackkey=nullableExpr COMMA x=nullableExpr COMMA y=nullableExpr (COMMA z=nullableExpr COMMA rx=nullableExpr COMMA ry=nullableExpr COMMA rz=nullableExpr COMMA tilt=nullableExpr COMMA span=nullableExpr)? CLS_PAR
	;

//地上子
beacon :
	DOT func=PUT OPN_PAR type=nullableExpr COMMA sectionArgs=nullableExpr COMMA senddata=nullableExpr CLS_PAR
	;

//速度制限
speedlimit :
	  DOT func=BEGIN OPN_PAR v=nullableExpr CLS_PAR
	| DOT func=END OPN_PAR CLS_PAR
	| DOT func=SET_SIGNAL OPN_PAR nullableExpr exprArgs* CLS_PAR
	;

//先行列車
pretrain :
	DOT func=PASS OPN_PAR nullableExpr CLS_PAR
	;

//光源
light :
	  DOT func=AMBIENT OPN_PAR red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr CLS_PAR
	| DOT func=DIFFUSE OPN_PAR red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr CLS_PAR
	| DOT func=DIRECTION OPN_PAR pitch=nullableExpr COMMA yaw=nullableExpr CLS_PAR
	;

//霧効果
fog :
	  DOT func=INTERPOLATE OPN_PAR density=nullableExpr (COMMA red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr)? CLS_PAR
	| DOT func=SET OPN_PAR density=nullableExpr COMMA red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr CLS_PAR
	;

//風景描画距離
drawdistance :
	DOT func=CHANGE OPN_PAR value=nullableExpr CLS_PAR
	;

//運転台の明るさ
cabilluminance :
	DOT func=(INTERPOLATE | SET) OPN_PAR value=nullableExpr CLS_PAR
	;

//軌道変位
irregularity :
	DOT func=CHANGE OPN_PAR x=nullableExpr COMMA y=nullableExpr COMMA r=nullableExpr COMMA lx=nullableExpr COMMA ly=nullableExpr COMMA lr=nullableExpr CLS_PAR
	;

//粘着特性
adhesion :
	DOT func=CHANGE OPN_PAR a=nullableExpr (COMMA b=nullableExpr COMMA c=nullableExpr)? CLS_PAR
	;

//音
sound :
	  DOT func=LOAD OPN_PAR filepath=expr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PLAY OPN_PAR CLS_PAR
	;

//固定音源
sound3d :
	  DOT func=LOAD OPN_PAR filepath=expr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=PUT OPN_PAR x=nullableExpr COMMA y=nullableExpr CLS_PAR
	;

//走行音
rollingnoise :
	DOT func=CHANGE OPN_PAR index=nullableExpr CLS_PAR
	;

//フランジきしり音
flangenoise :
	DOT func=CHANGE OPN_PAR index=nullableExpr CLS_PAR
	;

//分岐器通過音
jointnoise :
	DOT func=PLAY OPN_PAR index=nullableExpr CLS_PAR
	;

//他列車
train :
	  DOT func=ADD OPN_PAR trainkey=nullableExpr COMMA filepath=expr (COMMA trackkey=nullableExpr COMMA direction=nullableExpr)? CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=LOAD OPN_PAR filepath=expr COMMA trackkey=nullableExpr COMMA direction=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=ENABLE OPN_PAR time=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=STOP OPN_PAR decelerate=nullableExpr COMMA stoptime=nullableExpr COMMA accelerate=nullableExpr COMMA speed=nullableExpr CLS_PAR
	| OPN_BRA key=expr CLS_BRA DOT func=SET_TRACK OPN_PAR trackkey=nullableExpr COMMA direction=nullableExpr CLS_PAR
	;

//レガシー関数
legacy :
	  DOT func=FOG OPN_PAR fogstart=nullableExpr COMMA fogend=nullableExpr COMMA red=nullableExpr COMMA green=nullableExpr COMMA blue=nullableExpr CLS_PAR
	| DOT func=CURVE OPN_PAR radius=nullableExpr COMMA cant=nullableExpr CLS_PAR
	| DOT func=PITCH OPN_PAR rate=nullableExpr CLS_PAR
	| DOT func=TURN OPN_PAR slope=nullableExpr CLS_PAR
	;

//連続数式引数
exprArgs :
	COMMA arg=nullableExpr;

nullableExpr :
	  expr
	| nullSyntax=NULL
	| /* epsilon */
	;

expr :
	  OPN_PAR expr CLS_PAR								#parensExpr
	| op=(PLUS | MINUS) expr							#unaryExpr
	| left=expr op=(MULT | DIV) right=expr				#infixExpr
	| left=expr op=(PLUS | MINUS | MOD) right=expr		#infixExpr
	| func=ABS OPN_PAR value=expr CLS_PAR				#absExpr
	| func=ATAN2 OPN_PAR y=expr COMMA x=expr CLS_PAR	#atan2Expr
	| func=CEIL OPN_PAR value=expr CLS_PAR				#ceilExpr
	| func=COS OPN_PAR value=expr CLS_PAR				#cosExpr
	| func=EXP OPN_PAR value=expr CLS_PAR				#expExpr
	| func=FLOOR OPN_PAR value=expr CLS_PAR				#floorExpr
	| func=LOG OPN_PAR value=expr CLS_PAR				#logExpr
	| func=POW OPN_PAR x=expr COMMA y=expr CLS_PAR		#powExpr
	| func=RAND OPN_PAR value=expr? CLS_PAR				#randExpr
	| func=SIN OPN_PAR value=expr CLS_PAR				#sinExpr
	| func=SQRT OPN_PAR value=expr CLS_PAR				#sqrtExpr
	| v=var												#varExpr
	| num=NUM											#numberExpr
	| str=string										#stringExpr
	| dist=DISTANCE										#distanceExpr
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
