ì
ZC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IAutentication.cs
	namespace 	
Comunication
 
{		 
[

 
ServiceContract

 
]

 
public 

	interface 
IAutentication #
{ 
[ 	
OperationContract	 
] 
int 
AutenticatePlayer 
( 
Domain $
.$ %
Player% +
player, 2
)2 3
;3 4
[ 	
OperationContract	 
] 
int 
AutenticateEmail 
( 
string #
email$ )
)) *
;* +
[ 	
OperationContract	 
] 
int 
	CodeEmail 
( 
string 
to 
,  
String! '
affair( .
,. /
int0 3
validationCode4 B
)B C
;C D
} 
} å
XC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IChatService.cs
	namespace 	
Comunication
 
{		 
[

 
ServiceContract

 
(

 
CallbackContract

 %
=

& '
typeof

( .
(

. / 
IChatServiceCallback

/ C
)

C D
)

D E
]

E F
public 

	interface 
IChatServices "
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SendMessage 
( 
string 
senderUsername  .
,. /
string0 6
message7 >
)> ?
;? @
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void #
SetChatOperationContext $
($ %
string% +
username, 4
)4 5
;5 6
} 
[ 
ServiceContract 
] 
public 

	interface  
IChatServiceCallback )
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
MessageSend 
( 
string 
message  '
)' (
;( )
} 
} ¢

^C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IDrawReviewService.cs
	namespace 	
Comunication
 
{		 
[

 
ServiceContract

 
(

 
CallbackContract

 %
=

& '
typeof

( .
(

. /
IDrawReviewCallback

/ B
)

B C
)

C D
]

D E
public 

	interface 
IDrawReviewService '
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
	SendDraws 
( 
byte 
[ 
] 
draw "
)" #
;# $
} 
[ 
ServiceContract 
] 
public 

	interface 
IDrawReviewCallback (
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
DistributeDraws 
( 
List !
<! "
byte" &
[& '
]' (
>( )
playersDraws* 6
)6 7
;7 8
} 
} „	
[C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IFriendRequests.cs
	namespace

 	
Comunication


 
{ 
[ 
ServiceContract 
] 
public 

	interface 
IFriendRequests $
{ 
[ 	
OperationContract	 
] 
int 
AcceptFriendRequest 
(  
FriendRequest  -
friendRequest. ;
); <
;< =
[ 	
OperationContract	 
] 
int !
DeclineFriendRequests !
(! "
FriendRequest" /
friendRequest0 =
)= >
;> ?
[ 	
OperationContract	 
] 
List 
< 
Domain 
. 
FriendRequest !
>! "!
GetFriendRequestsList# 8
(8 9
string9 ?
username@ H
)H I
;I J
[ 	
OperationContract	 
] 
int 
SendFriendRequests 
( 
FriendRequest ,
friendRequest- :
): ;
;; <
} 
} ˝
\C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IMatchManagement.cs
	namespace 	
Comunication
 
{		 
[

 
ServiceContract

 
(

 
CallbackContract

 %
=

& '
typeof

( .
(

. /
IMatchCallback

/ =
)

= >
)

> ?
]

? @
public 

	interface 
IMatchManagement %
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SendCard 
( 
string 
card !
)! "
;" #
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SelectTurnTime 
( 
) 
; 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
StartTurnSignal 
( 
string #
username$ ,
), -
;- .
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void $
SetMatchOperationContext %
(% &
string& ,
username- 5
)5 6
;6 7
} 
[ 
ServiceContract 
] 
public 

	interface 
IMatchCallback #
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
DistributeCard 
( 
string "
card# '
)' (
;( )
[   	
OperationContract  	 
(   
IsOneWay   #
=  $ %
true  & *
)  * +
]  + ,
void!! 
DistributeTurnTime!! 
(!!  
int!!  #
turnTime!!$ ,
)!!, -
;!!- .
[## 	
OperationContract##	 
(## 
IsOneWay## #
=##$ %
true##& *
)##* +
]##+ ,
void$$ !
ReturnStartTurnSignal$$ "
($$" #
int$$# &

turnNumber$$' 1
)$$1 2
;$$2 3
}&& 
}'' í
]C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IPlayerConnection.cs
	namespace		 	
Comunication		
 
{

 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /$
IPlayersServicesCallBack/ G
)G H
)H I
]I J
public 

	interface 
IPlayerConnection &
{ 
[ 	
OperationContract	 
] 
void 
Connect 
( 
string 
username $
)$ %
;% &
[ 	
OperationContract	 
] 
void 

Disconnect 
( 
string 
username '
)' (
;( )
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
SendOnlinePlayers 
( 
string %
username& .
). /
;/ 0
[ 	
OperationContract	 
] 
List 
< 
string 
>  
GetNameOnlinePlayers )
() *
)* +
;+ ,
[ 	
OperationContract	 
] 
void 
SendMathInvitation 
(  
string  &
invitingPlayer' 5
,5 6
string7 =
invitedPlayer> K
)K L
;L M
[ 	
OperationContract	 
] 
int  
FindPlayerIsConected  
(  !
string! '
usernamePlayer( 6
)6 7
;7 8
[   	
OperationContract  	 
]   
int!! 
FindPlayerInGroup!! 
(!! 
string!! $
usernameToFind!!% 3
)!!3 4
;!!4 5
[## 	
OperationContract##	 
]## 
int$$ 
GroupIsNotFull$$ 
($$ 
)$$ 
;$$ 
[&& 	
OperationContract&&	 
]&& 
List'' 
<'' 
string'' 
>'' *
GetListUsernamesPlayersInGroup'' 3
(''3 4
)''4 5
;''5 6
[)) 	
OperationContract))	 
()) 
IsOneWay)) #
=))$ %
true))& *
)))* +
]))+ ,
void** 

StartMatch** 
(** 
string** 
username** '
)**' (
;**( )
}++ 
[-- 
ServiceContract-- 
]-- 
public.. 

	interface.. $
IPlayersServicesCallBack.. -
{// 
[00 	
OperationContract00	 
(00 
IsOneWay00 #
=00$ %
true00& *
)00* +
]00+ ,
void11 
PlayersCallBack11 
(11 
Friends11 $
[11$ %
]11% &
friends11' .
)11. /
;11/ 0
[44 	
OperationContract44	 
]44 
int55 !
NotifyMatchInvitation55 !
(55! "
string55" (
invitingPlayer55) 7
)557 8
;558 9
[77 	
OperationContract77	 
(77 
IsOneWay77 #
=77$ %
true77& *
)77* +
]77+ ,
void88 
OpenMatchWindow88 
(88 
)88 
;88 
}99 
}:: õ
]C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\IPlayerManagement.cs
	namespace		 	
Comunication		
 
{

 
[ 
ServiceContract 
] 
public 

	interface 
IPlayerManagement &
{ 
[ 	
OperationContract	 
] 
int 
	AddPlayer 
( 
Player 
player #
)# $
;$ %
[ 	
OperationContract	 
] 
int 
UpdateDataPlayer 
( 
string #
username$ ,
,, -
Player. 4
player5 ;
); <
;< =
[ 	
OperationContract	 
] 
Player 
GetDataPlayer 
( 
string #
username$ ,
), -
;- .
[ 	
OperationContract	 
] 
int  
UpdatePlayerPassword  
(  !
string! '
username( 0
,0 1
string2 8
password9 A
)A B
;B C
[ 	
OperationContract	 
] 
int 
UpdatePassword 
( 
string !
email" '
,' (
string) /
password0 8
)8 9
;9 :
[ 	
OperationContract	 
] 
Friends 
[ 
] 

GetFriends 
( 
String #
username$ ,
), -
;- .
[   	
OperationContract  	 
]   
int!! 
DeleteFriend!! 
(!! 
Friends!!  
friendToDelete!!! /
)!!/ 0
;!!0 1
[## 	
OperationContract##	 
]## 
int$$ 

FindPlayer$$ 
($$ 
string$$ 
username$$ &
)$$& '
;$$' (
}%% 
}(( å”
bC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\ImplementationServices.cs
	namespace 	
Comunication
 
{ 
[ 
ServiceBehavior 
( 
InstanceContextMode (
=) *
InstanceContextMode+ >
.> ?
Single? E
)E F
]F G
public 

partial 
class "
ImplementationServices /
:0 1
IPlayerManagement2 C
{ 
PlayerLogic 
playerLogic 
=  !
new" %
PlayerLogic& 1
(1 2
)2 3
;3 4
public 
int 
	AddPlayer 
( 
Player #
player$ *
)* +
{ 	
return 
playerLogic 
. 
	AddPlayer (
(( )
player) /
)/ 0
;0 1
} 	
public 
int 
UpdateDataPlayer #
(# $
string$ *
username+ 3
,3 4
Player5 ;
player< B
)B C
{ 	
return 
playerLogic 
. 
UpdateDataPlayer /
(/ 0
username0 8
,8 9
player: @
)@ A
;A B
} 	
public 
Player 
GetDataPlayer #
(# $
string$ *
username+ 3
)3 4
{ 	
return 
playerLogic 
. 
ObtainPlayerData /
(/ 0
username0 8
)8 9
;9 :
}   	
public"" 
int""  
UpdatePlayerPassword"" '
(""' (
string""( .
username""/ 7
,""7 8
string""9 ?
password""@ H
)""H I
{## 	
return$$ 
playerLogic$$ 
.$$ 
UpdatePassword$$ -
($$- .
username$$. 6
,$$6 7
password$$8 @
)$$@ A
;$$A B
}%% 	
public'' 
int'' 
UpdatePassword'' !
(''! "
string''" (
email'') .
,''. /
string''0 6
password''7 ?
)''? @
{(( 	
return)) 
playerLogic)) 
.)) 
UpdatePasswordEmail)) 2
())2 3
email))3 8
,))8 9
password)): B
)))B C
;))C D
}** 	
public,, 
Friends,, 
[,, 
],, 

GetFriends,, #
(,,# $
String,,$ *
username,,+ 3
),,3 4
{-- 	
List.. 
<.. 
Friends.. 
>.. 
friends.. !
=.." #
playerLogic..$ /
.../ 0
RecoverFriends..0 >
(..> ?
username..? G
)..G H
;..H I
return// 
friends// 
.// 
ToArray// "
(//" #
)//# $
;//$ %
}00 	
public22 
int22 
DeleteFriend22 
(22  
Friends22  '
friendToDelete22( 6
)226 7
{33 	
return44 
playerLogic44 
.44 
DeleteFriend44 +
(44+ ,
friendToDelete44, :
)44: ;
;44; <
}55 	
public77 
int77 

FindPlayer77 
(77 
string77 $
username77% -
)77- .
{88 	
return99 
playerLogic99 
.99 

FindPlayer99 )
(99) *
username99* 2
)992 3
;993 4
}:: 	
};; 
public== 

partial== 
class== "
ImplementationServices== /
:==0 1
IAutentication==2 @
{>> 
public?? 
int?? 
AutenticatePlayer?? $
(??$ %
Player??% +
player??, 2
)??2 3
{@@ 	
PlayerLogicAA 
newPlayerLogicAA &
=AA' (
newAA) ,
PlayerLogicAA- 8
(AA8 9
)AA9 :
;AA: ;
returnBB 
newPlayerLogicBB !
.BB! "
AutenticatePlayerBB" 3
(BB3 4
playerBB4 :
)BB: ;
;BB; <
}CC 	
publicEE 
intEE 
AutenticateEmailEE #
(EE# $
stringEE$ *
emailEE+ 0
)EE0 1
{FF 	
PlayerLogicGG 
playerNewLogicGG &
=GG' (
newGG) ,
PlayerLogicGG- 8
(GG8 9
)GG9 :
;GG: ;
returnHH 
playerNewLogicHH !
.HH! "
AutenticateEmailHH" 2
(HH2 3
emailHH3 8
)HH8 9
;HH9 :
}II 	
publicKK 
intKK 
	CodeEmailKK 
(KK 
stringKK #
toKK$ &
,KK& '
StringKK( .
affairKK/ 5
,KK5 6
intKK7 :
validationCodeKK; I
)KKI J
{LL 	
	SendEmailMM 
	sendEmailMM 
=MM  !
newMM" %
	SendEmailMM& /
(MM/ 0
)MM0 1
;MM1 2
returnNN 
	sendEmailNN 
.NN 
SendNewEmailNN )
(NN) *
toNN* ,
,NN, -
affairNN. 4
,NN4 5
validationCodeNN6 D
)NND E
;NNE F
}OO 	
}PP 
publicRR 

partialRR 
classRR "
ImplementationServicesRR /
:RR0 1
IFriendRequestsRR2 A
{SS 
FriendRequestsLogicTT 
friendRequestLogicTT .
=TT/ 0
newTT1 4
FriendRequestsLogicTT5 H
(TTH I
)TTI J
;TTJ K
publicVV 
intVV 
AcceptFriendRequestVV &
(VV& '
FriendRequestVV' 4
friendRequestVV5 B
)VVB C
{WW 	
returnXX 
friendRequestLogicXX %
.XX% &
AcceptFriendRequestXX& 9
(XX9 :
friendRequestXX: G
)XXG H
;XXH I
}YY 	
public[[ 
int[[ !
DeclineFriendRequests[[ (
([[( )
FriendRequest[[) 6
friendRequest[[7 D
)[[D E
{\\ 	
return]] 
friendRequestLogic]] %
.]]% &
DeleteFriendRequest]]& 9
(]]9 :
friendRequest]]: G
)]]G H
;]]H I
}^^ 	
public`` 
List`` 
<`` 
FriendRequest`` !
>``! "!
GetFriendRequestsList``# 8
(``8 9
string``9 ?
username``@ H
)``H I
{aa 	
returnbb 
friendRequestLogicbb %
.bb% &%
GetFriendRequestsOfPlayerbb& ?
(bb? @
usernamebb@ H
)bbH I
;bbI J
}cc 	
publicee 
intee 
SendFriendRequestsee %
(ee% &
FriendRequestee& 3
friendRequestee4 A
)eeA B
{ff 	
returngg 
friendRequestLogicgg %
.gg% &
SendFriendRequestsgg& 8
(gg8 9
friendRequestgg9 F
)ggF G
;ggG H
}hh 	
}ii 
publicll 

partialll 
classll "
ImplementationServicesll /
:ll0 1
IPlayerConnectionll2 C
{mm 
privatenn 
Listnn 
<nn 
ConnectedUsernn "
>nn" #
usersnn$ )
=nn* +
newnn, /
Listnn0 4
<nn4 5
ConnectedUsernn5 B
>nnB C
(nnC D
)nnD E
;nnE F
privateoo 
staticoo 
Listoo 
<oo 
ConnectedUseroo )
>oo) *
playersInGroupoo+ 9
=oo: ;
newoo< ?
Listoo@ D
<ooD E
ConnectedUserooE R
>ooR S
(ooS T
)ooT U
;ooU V
publicqq 
voidqq 
Connectqq 
(qq 
stringqq "
usernameqq# +
)qq+ ,
{rr 	
ConnectedUserss 
userss 
=ss  
newss! $
ConnectedUserss% 2
(ss2 3
)ss3 4
{tt 
usernameuu 
=uu 
usernameuu #
,uu# $
operationContextvv  
=vv! "
OperationContextvv# 3
.vv3 4
Currentvv4 ;
}ww 
;ww 
usersyy 
.yy 
Addyy 
(yy 
useryy 
)yy 
;yy 
}zz 	
public|| 
void|| 

Disconnect|| 
(|| 
string|| %
username||& .
)||. /
{}} 	
var~~ 
user~~ 
=~~ 
users~~ 
.~~ 
FirstOrDefault~~ +
(~~+ ,
i~~, -
=>~~. 0
i~~1 2
.~~2 3
username~~3 ;
==~~< >
username~~? G
)~~G H
;~~H I
if 
( 
user 
!= 
null 
) 
{
ÄÄ 
users
ÅÅ 
.
ÅÅ 
Remove
ÅÅ 
(
ÅÅ 
user
ÅÅ !
)
ÅÅ! "
;
ÅÅ" #
}
ÇÇ 
}
ÉÉ 	
public
ÖÖ 
List
ÖÖ 
<
ÖÖ 
string
ÖÖ 
>
ÖÖ "
GetNameOnlinePlayers
ÖÖ 0
(
ÖÖ0 1
)
ÖÖ1 2
{
ÜÜ 	
List
áá 
<
áá 
string
áá 
>
áá 
onlinePlayers
áá &
=
áá' (
new
áá) ,
List
áá- 1
<
áá1 2
string
áá2 8
>
áá8 9
(
áá9 :
)
áá: ;
;
áá; <
foreach
àà 
(
àà 
ConnectedUser
àà "
player
àà# )
in
àà* ,
users
àà- 2
)
àà2 3
{
ââ 
onlinePlayers
ää 
.
ää 
Add
ää !
(
ää! "
player
ää" (
.
ää( )
username
ää) 1
)
ää1 2
;
ää2 3
}
ãã 
return
çç 
onlinePlayers
çç  
;
çç  !
}
éé 	
public
êê 
void
êê 
SendOnlinePlayers
êê %
(
êê% &
string
êê& ,
username
êê- 5
)
êê5 6
{
ëë 	
Friends
íí 
[
íí 
]
íí 
friends
íí 
=
íí 

GetFriends
íí  *
(
íí* +
username
íí+ 3
)
íí3 4
;
íí4 5
users
ìì 
.
ìì 
Find
ìì 
(
ìì 
us
ìì 
=>
ìì 
us
ìì 
.
ìì  
username
ìì  (
.
ìì( )
Equals
ìì) /
(
ìì/ 0
username
ìì0 8
)
ìì8 9
)
ìì9 :
.
ìì: ;
operationContext
ìì; K
.
ììK L 
GetCallbackChannel
ììL ^
<
ìì^ _&
IPlayersServicesCallBack
ìì_ w
>
ììw x
(
ììx y
)
ììy z
.
ììz {
PlayersCallBackìì{ ä
(ììä ã
friendsììã í
)ììí ì
;ììì î
}
îî 	
public
óó 
void
óó  
SendMathInvitation
óó &
(
óó& '
string
óó' -
invitingPlayer
óó. <
,
óó< =
string
óó> D
invitedPlayer
óóE R
)
óóR S
{
òò 	
int
ôô 
operationOK
ôô 
=
ôô 
$num
ôô !
;
ôô! "
int
öö 
userNotFound
öö 
=
öö 
$num
öö "
;
öö" #
ConnectedUser
úú 
userConnected
úú '
=
úú( )
users
úú* /
.
úú/ 0
FirstOrDefault
úú0 >
(
úú> ?
user
úú? C
=>
úúD F
user
úúG K
.
úúK L
username
úúL T
.
úúT U
Equals
úúU [
(
úú[ \
invitedPlayer
úú\ i
)
úúi j
)
úúj k
;
úúk l
ConnectedUser
ùù 
	matchHost
ùù #
=
ùù$ %
users
ùù& +
.
ùù+ ,
FirstOrDefault
ùù, :
(
ùù: ;
user
ùù; ?
=>
ùù@ B
user
ùùC G
.
ùùG H
username
ùùH P
.
ùùP Q
Equals
ùùQ W
(
ùùW X
invitingPlayer
ùùX f
)
ùùf g
)
ùùg h
;
ùùh i
if
üü 
(
üü 
userConnected
üü 
!=
üü  
null
üü! %
)
üü% &
{
†† 
if
°° 
(
°° 
FindPlayerInGroup
°° %
(
°°% &
invitingPlayer
°°& 4
)
°°4 5
==
°°6 8
userNotFound
°°9 E
)
°°E F
{
¢¢ 
if
££ 
(
££ 
	matchHost
££ !
!=
££" $
null
££% )
)
££) *
{
§§ 
	matchHost
•• !
.
••! "
	hostState
••" +
=
••, -
true
••. 2
;
••2 3
}
¶¶ 
playersInGroup
®® "
.
®®" #
Add
®®# &
(
®®& '
	matchHost
®®' 0
)
®®0 1
;
®®1 2
}
©© 
if
¨¨ 
(
¨¨ 
userConnected
¨¨ !
.
¨¨! "
operationContext
¨¨" 2
.
¨¨2 3 
GetCallbackChannel
¨¨3 E
<
¨¨E F&
IPlayersServicesCallBack
¨¨F ^
>
¨¨^ _
(
¨¨_ `
)
¨¨` a
.
¨¨a b#
NotifyMatchInvitation
¨¨b w
(
¨¨w x
invitingPlayer¨¨x Ü
)¨¨Ü á
==¨¨à ä
operationOK¨¨ã ñ
)¨¨ñ ó
{
≠≠ 
playersInGroup
ÆÆ "
.
ÆÆ" #
Add
ÆÆ# &
(
ÆÆ& '
userConnected
ÆÆ' 4
)
ÆÆ4 5
;
ÆÆ5 6
}
ØØ 
}
∞∞ 
}
¥¥ 	
public
∂∂ 
int
∂∂ "
FindPlayerIsConected
∂∂ '
(
∂∂' (
string
∂∂( .
usernamePlayer
∂∂/ =
)
∂∂= >
{
∑∑ 	
int
∏∏ 

isConected
∏∏ 
=
∏∏ 
$num
∏∏  
;
∏∏  !
int
ππ 
userNotConected
ππ 
=
ππ  !
$num
ππ" %
;
ππ% &
if
ªª 
(
ªª 
users
ªª 
.
ªª 
FirstOrDefault
ªª $
(
ªª$ %
user
ªª% )
=>
ªª* ,
user
ªª- 1
.
ªª1 2
username
ªª2 :
.
ªª: ;
Equals
ªª; A
(
ªªA B
usernamePlayer
ªªB P
)
ªªP Q
)
ªªQ R
==
ªªS U
null
ªªV Z
)
ªªZ [
{
ºº 

isConected
ΩΩ 
=
ΩΩ 
userNotConected
ΩΩ ,
;
ΩΩ, -
}
ææ 
return
¿¿ 

isConected
¿¿ 
;
¿¿ 
}
¡¡ 	
public
√√ 
int
√√ 
FindPlayerInGroup
√√ $
(
√√$ %
string
√√% +
usernameToFind
√√, :
)
√√: ;
{
ƒƒ 	
int
≈≈ 

statusUser
≈≈ 
=
≈≈ 
$num
≈≈  
;
≈≈  !
int
∆∆ 
userNotFound
∆∆ 
=
∆∆ 
$num
∆∆ "
;
∆∆" #
if
«« 
(
«« 
playersInGroup
«« 
.
«« 
FirstOrDefault
«« -
(
««- .
user
««. 2
=>
««3 5
user
««6 :
.
««: ;
username
««; C
.
««C D
Equals
««D J
(
««J K
usernameToFind
««K Y
)
««Y Z
)
««Z [
==
««\ ^
null
««_ c
)
««c d
{
»» 

statusUser
…… 
=
…… 
userNotFound
…… )
;
……) *
}
   
return
ÀÀ 

statusUser
ÀÀ 
;
ÀÀ 
}
ÃÃ 	
public
ŒŒ 
int
ŒŒ 
GroupIsNotFull
ŒŒ !
(
ŒŒ! "
)
ŒŒ" #
{
œœ 	
int
–– 

statusCode
–– 
=
–– 
$num
––  
;
––  !
if
““ 
(
““ 
playersInGroup
““ 
.
““ 
Count
““ $
<=
““% '
$num
““( )
)
““) *
{
”” 

statusCode
‘‘ 
=
‘‘ 
$num
‘‘  
;
‘‘  !
}
’’ 
return
÷÷ 

statusCode
÷÷ 
;
÷÷ 
}
◊◊ 	
public
⁄⁄ 
List
⁄⁄ 
<
⁄⁄ 
string
⁄⁄ 
>
⁄⁄ ,
GetListUsernamesPlayersInGroup
⁄⁄ :
(
⁄⁄: ;
)
⁄⁄; <
{
€€ 	
List
‹‹ 
<
‹‹ 
string
‹‹ 
>
‹‹ 
groupPlayers
‹‹ %
=
‹‹& '
new
‹‹( +
List
‹‹, 0
<
‹‹0 1
string
‹‹1 7
>
‹‹7 8
(
‹‹8 9
)
‹‹9 :
;
‹‹: ;
foreach
ﬁﬁ 
(
ﬁﬁ 
ConnectedUser
ﬁﬁ "
playerConnected
ﬁﬁ# 2
in
ﬁﬁ3 5
playersInGroup
ﬁﬁ6 D
)
ﬁﬁD E
{
ﬂﬂ 
groupPlayers
‡‡ 
.
‡‡ 
Add
‡‡  
(
‡‡  !
playerConnected
‡‡! 0
.
‡‡0 1
username
‡‡1 9
)
‡‡9 :
;
‡‡: ;
}
·· 
return
‚‚ 
groupPlayers
‚‚ 
;
‚‚  
}
„„ 	
public
ÂÂ 
void
ÂÂ 

StartMatch
ÂÂ 
(
ÂÂ 
string
ÂÂ %
username
ÂÂ& .
)
ÂÂ. /
{
ÊÊ 	
foreach
ÁÁ 
(
ÁÁ 
ConnectedUser
ÁÁ "
user
ÁÁ# '
in
ÁÁ( *
playersInGroup
ÁÁ+ 9
)
ÁÁ9 :
{
ËË 
if
ÈÈ 
(
ÈÈ 
user
ÈÈ 
.
ÈÈ 
username
ÈÈ !
.
ÈÈ! "
Equals
ÈÈ" (
(
ÈÈ( )
username
ÈÈ) 1
)
ÈÈ1 2
&&
ÈÈ3 5
user
ÈÈ6 :
.
ÈÈ: ;
	hostState
ÈÈ; D
)
ÈÈD E
{
ÍÍ 
foreach
ÎÎ 
(
ÎÎ 
ConnectedUser
ÎÎ *
connectedUser
ÎÎ+ 8
in
ÎÎ9 ;
playersInGroup
ÎÎ< J
)
ÎÎJ K
{
ÏÏ 
connectedUser
ÌÌ %
.
ÌÌ% &
operationContext
ÌÌ& 6
.
ÌÌ6 7 
GetCallbackChannel
ÌÌ7 I
<
ÌÌI J&
IPlayersServicesCallBack
ÌÌJ b
>
ÌÌb c
(
ÌÌc d
)
ÌÌd e
.
ÌÌe f
OpenMatchWindow
ÌÌf u
(
ÌÌu v
)
ÌÌv w
;
ÌÌw x
}
ÓÓ 
}
ÔÔ 
}
 
}
ÒÒ 	
}
ÚÚ 
public
ÙÙ 

partial
ÙÙ 
class
ÙÙ $
ImplementationServices
ÙÙ /
:
ÙÙ0 1
IMatchManagement
ÙÙ2 B
{
ıı 
private
ˆˆ 
int
ˆˆ 

turnNumber
ˆˆ 
=
ˆˆ  
$num
ˆˆ! "
;
ˆˆ" #
public
¯¯ 
void
¯¯ 
SelectTurnTime
¯¯ "
(
¯¯" #
)
¯¯# $
{
˘˘ 	
int
˙˙ 
[
˙˙ 
]
˙˙ 
seconds
˙˙ 
=
˙˙ 
{
˙˙ 
$num
˙˙  
,
˙˙  !
$num
˙˙" $
,
˙˙$ %
$num
˙˙& (
,
˙˙( )
$num
˙˙* ,
}
˙˙- .
;
˙˙. /
Random
˚˚ 
random
˚˚ 
=
˚˚ 
new
˚˚ 
Random
˚˚  &
(
˚˚& '
)
˚˚' (
;
˚˚( )
int
¸¸ 
time
¸¸ 
=
¸¸ 
seconds
¸¸ 
[
¸¸ 
random
¸¸ %
.
¸¸% &
Next
¸¸& *
(
¸¸* +
seconds
¸¸+ 2
.
¸¸2 3
Length
¸¸3 9
)
¸¸9 :
]
¸¸: ;
;
¸¸; <
foreach
˝˝ 
(
˝˝ 
ConnectedUser
˝˝ "
user
˝˝# '
in
˝˝( *
playersInGroup
˝˝+ 9
)
˝˝9 :
{
˛˛ 
user
ˇˇ 
.
ˇˇ 
matchContext
ˇˇ !
.
ˇˇ! " 
GetCallbackChannel
ˇˇ" 4
<
ˇˇ4 5
IMatchCallback
ˇˇ5 C
>
ˇˇC D
(
ˇˇD E
)
ˇˇE F
.
ˇˇF G 
DistributeTurnTime
ˇˇG Y
(
ˇˇY Z
time
ˇˇZ ^
)
ˇˇ^ _
;
ˇˇ_ `
}
ÄÄ 
}
ÅÅ 	
public
ÉÉ 
void
ÉÉ 
SendCard
ÉÉ 
(
ÉÉ 
string
ÉÉ #
card
ÉÉ$ (
)
ÉÉ( )
{
ÑÑ 	
foreach
ÖÖ 
(
ÖÖ 
ConnectedUser
ÖÖ "
user
ÖÖ# '
in
ÖÖ( *
playersInGroup
ÖÖ+ 9
)
ÖÖ9 :
{
ÜÜ 
user
áá 
.
áá 
matchContext
áá !
.
áá! " 
GetCallbackChannel
áá" 4
<
áá4 5
IMatchCallback
áá5 C
>
ááC D
(
ááD E
)
ááE F
.
ááF G
DistributeCard
ááG U
(
ááU V
card
ááV Z
)
ááZ [
;
áá[ \
}
àà 
}
ââ 	
public
ãã 
void
ãã &
SetMatchOperationContext
ãã ,
(
ãã, -
string
ãã- 3
username
ãã4 <
)
ãã< =
{
åå 	
foreach
éé 
(
éé 
ConnectedUser
éé "
user
éé# '
in
éé( *
playersInGroup
éé+ 9
)
éé9 :
{
èè 
if
êê 
(
êê 
user
êê 
.
êê 
username
êê !
.
êê! "
Equals
êê" (
(
êê( )
username
êê) 1
)
êê1 2
)
êê2 3
{
ëë 
user
íí 
.
íí 
matchContext
íí %
=
íí& '
OperationContext
íí( 8
.
íí8 9
Current
íí9 @
;
íí@ A
}
ìì 
}
îî 
}
ïï 	
public
óó 
void
óó 
StartTurnSignal
óó #
(
óó# $
string
óó$ *
username
óó+ 3
)
óó3 4
{
òò 	
foreach
ôô 
(
ôô 
ConnectedUser
ôô "
user
ôô# '
in
ôô( *
playersInGroup
ôô+ 9
)
ôô9 :
{
öö 
if
õõ 
(
õõ 
user
õõ 
.
õõ 
username
õõ !
.
õõ! "
Equals
õõ" (
(
õõ( )
username
õõ) 1
)
õõ1 2
&&
õõ3 5
user
õõ6 :
.
õõ: ;
	hostState
õõ; D
)
õõD E
{
úú 
foreach
ùù 
(
ùù 
ConnectedUser
ùù *
	matchUser
ùù+ 4
in
ùù5 7
playersInGroup
ùù8 F
)
ùùF G
{
ûû 

turnNumber
üü "
++
üü" $
;
üü$ %
	matchUser
†† !
.
††! "
matchContext
††" .
.
††. / 
GetCallbackChannel
††/ A
<
††A B
IMatchCallback
††B P
>
††P Q
(
††Q R
)
††R S
.
††S T#
ReturnStartTurnSignal
††T i
(
††i j

turnNumber
††j t
)
††t u
;
††u v
}
°° 
}
¢¢ 
}
££ 
}
§§ 	
}
ßß 
public
©© 

partial
©© 
class
©© $
ImplementationServices
©© /
:
©©0 1
IChatServices
©©2 ?
{
™™ 
public
´´ 
void
´´ 
SendMessage
´´ 
(
´´  
string
´´  &
senderUsername
´´' 5
,
´´5 6
string
´´7 =
message
´´> E
)
´´E F
{
¨¨ 	
	ChatLogic
≠≠ 
	chatLogic
≠≠ 
=
≠≠  !
new
≠≠" %
	ChatLogic
≠≠& /
(
≠≠/ 0
)
≠≠0 1
;
≠≠1 2
string
ÆÆ 
completeMessage
ÆÆ "
=
ÆÆ# $
	chatLogic
ÆÆ% .
.
ÆÆ. /
BuildMessage
ÆÆ/ ;
(
ÆÆ; <
senderUsername
ÆÆ< J
,
ÆÆJ K
message
ÆÆL S
)
ÆÆS T
;
ÆÆT U
foreach
∞∞ 
(
∞∞ 
ConnectedUser
∞∞ "
user
∞∞# '
in
∞∞( *
playersInGroup
∞∞+ 9
)
∞∞9 :
{
±± 
user
≤≤ 
.
≤≤ 
chatContext
≤≤  
.
≤≤  ! 
GetCallbackChannel
≤≤! 3
<
≤≤3 4"
IChatServiceCallback
≤≤4 H
>
≤≤H I
(
≤≤I J
)
≤≤J K
.
≤≤K L
MessageSend
≤≤L W
(
≤≤W X
completeMessage
≤≤X g
)
≤≤g h
;
≤≤h i
}
≥≥ 
}
µµ 	
public
∑∑ 
void
∑∑ %
SetChatOperationContext
∑∑ +
(
∑∑+ ,
string
∑∑, 2
username
∑∑3 ;
)
∑∑; <
{
∏∏ 	
foreach
ππ 
(
ππ 
ConnectedUser
ππ "
user
ππ# '
in
ππ( *
playersInGroup
ππ+ 9
)
ππ9 :
{
∫∫ 
if
ªª 
(
ªª 
user
ªª 
.
ªª 
username
ªª !
.
ªª! "
Equals
ªª" (
(
ªª( )
username
ªª) 1
)
ªª1 2
)
ªª2 3
{
ºº 
user
ΩΩ 
.
ΩΩ 
chatContext
ΩΩ $
=
ΩΩ% &
OperationContext
ΩΩ' 7
.
ΩΩ7 8
Current
ΩΩ8 ?
;
ΩΩ? @
}
ææ 
}
øø 
}
¿¿ 	
}
¡¡ 
public
√√ 

partial
√√ 
class
√√ $
ImplementationServices
√√ /
:
√√0 1 
IDrawReviewService
√√2 D
{
ƒƒ 
List
≈≈ 
<
≈≈ 
byte
≈≈ 
[
≈≈ 
]
≈≈ 
>
≈≈ 
playersDraws
≈≈ !
=
≈≈" #
new
≈≈$ '
List
≈≈( ,
<
≈≈, -
byte
≈≈- 1
[
≈≈1 2
]
≈≈2 3
>
≈≈3 4
(
≈≈4 5
)
≈≈5 6
;
≈≈6 7
public
«« 
void
«« 
	SendDraws
«« 
(
«« 
byte
«« "
[
««" #
]
««# $
draw
««% )
)
««) *
{
»» 	
playersDraws
…… 
.
…… 
Add
…… 
(
…… 
draw
…… !
)
……! "
;
……" #
if
ÀÀ 
(
ÀÀ 
playersDraws
ÀÀ 
.
ÀÀ 
Count
ÀÀ "
>
ÀÀ# $
$num
ÀÀ% &
)
ÀÀ& '
{
ÃÃ 
foreach
ÕÕ 
(
ÕÕ 
ConnectedUser
ÕÕ &
user
ÕÕ' +
in
ÕÕ, .
playersInGroup
ÕÕ/ =
)
ÕÕ= >
{
ŒŒ 
user
œœ 
.
œœ 
drawContext
œœ $
.
œœ$ % 
GetCallbackChannel
œœ% 7
<
œœ7 8!
IDrawReviewCallback
œœ8 K
>
œœK L
(
œœL M
)
œœM N
.
œœN O
DistributeDraws
œœO ^
(
œœ^ _
playersDraws
œœ_ k
)
œœk l
;
œœl m
}
–– 
}
—— 
}
““ 	
}
”” 
}’’ é
cC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenServer\Comunication\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str '
)' (
]( )
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str )
)) *
]* +
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *