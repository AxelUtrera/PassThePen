�
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
} �
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
} �

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
} �	
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
} �
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
}'' �
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
}:: �
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
}(( ��
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
�� 
users
�� 
.
�� 
Remove
�� 
(
�� 
user
�� !
)
��! "
;
��" #
}
�� 
}
�� 	
public
�� 
List
�� 
<
�� 
string
�� 
>
�� "
GetNameOnlinePlayers
�� 0
(
��0 1
)
��1 2
{
�� 	
List
�� 
<
�� 
string
�� 
>
�� 
onlinePlayers
�� &
=
��' (
new
��) ,
List
��- 1
<
��1 2
string
��2 8
>
��8 9
(
��9 :
)
��: ;
;
��; <
foreach
�� 
(
�� 
ConnectedUser
�� "
player
��# )
in
��* ,
users
��- 2
)
��2 3
{
�� 
onlinePlayers
�� 
.
�� 
Add
�� !
(
��! "
player
��" (
.
��( )
username
��) 1
)
��1 2
;
��2 3
}
�� 
return
�� 
onlinePlayers
��  
;
��  !
}
�� 	
public
�� 
void
�� 
SendOnlinePlayers
�� %
(
��% &
string
��& ,
username
��- 5
)
��5 6
{
�� 	
Friends
�� 
[
�� 
]
�� 
friends
�� 
=
�� 

GetFriends
��  *
(
��* +
username
��+ 3
)
��3 4
;
��4 5
users
�� 
.
�� 
Find
�� 
(
�� 
us
�� 
=>
�� 
us
�� 
.
��  
username
��  (
.
��( )
Equals
��) /
(
��/ 0
username
��0 8
)
��8 9
)
��9 :
.
��: ;
operationContext
��; K
.
��K L 
GetCallbackChannel
��L ^
<
��^ _&
IPlayersServicesCallBack
��_ w
>
��w x
(
��x y
)
��y z
.
��z {
PlayersCallBack��{ �
(��� �
friends��� �
)��� �
;��� �
}
�� 	
public
�� 
void
��  
SendMathInvitation
�� &
(
��& '
string
��' -
invitingPlayer
��. <
,
��< =
string
��> D
invitedPlayer
��E R
)
��R S
{
�� 	
int
�� 
operationOK
�� 
=
�� 
$num
�� !
;
��! "
int
�� 
userNotFound
�� 
=
�� 
$num
�� "
;
��" #
ConnectedUser
�� 
userConnected
�� '
=
��( )
users
��* /
.
��/ 0
FirstOrDefault
��0 >
(
��> ?
user
��? C
=>
��D F
user
��G K
.
��K L
username
��L T
.
��T U
Equals
��U [
(
��[ \
invitedPlayer
��\ i
)
��i j
)
��j k
;
��k l
ConnectedUser
�� 
	matchHost
�� #
=
��$ %
users
��& +
.
��+ ,
FirstOrDefault
��, :
(
��: ;
user
��; ?
=>
��@ B
user
��C G
.
��G H
username
��H P
.
��P Q
Equals
��Q W
(
��W X
invitingPlayer
��X f
)
��f g
)
��g h
;
��h i
if
�� 
(
�� 
userConnected
�� 
!=
��  
null
��! %
)
��% &
{
�� 
if
�� 
(
�� 
FindPlayerInGroup
�� %
(
��% &
invitingPlayer
��& 4
)
��4 5
==
��6 8
userNotFound
��9 E
)
��E F
{
�� 
if
�� 
(
�� 
	matchHost
�� !
!=
��" $
null
��% )
)
��) *
{
�� 
	matchHost
�� !
.
��! "
	hostState
��" +
=
��, -
true
��. 2
;
��2 3
}
�� 
playersInGroup
�� "
.
��" #
Add
��# &
(
��& '
	matchHost
��' 0
)
��0 1
;
��1 2
}
�� 
if
�� 
(
�� 
userConnected
�� !
.
��! "
operationContext
��" 2
.
��2 3 
GetCallbackChannel
��3 E
<
��E F&
IPlayersServicesCallBack
��F ^
>
��^ _
(
��_ `
)
��` a
.
��a b#
NotifyMatchInvitation
��b w
(
��w x
invitingPlayer��x �
)��� �
==��� �
operationOK��� �
)��� �
{
�� 
playersInGroup
�� "
.
��" #
Add
��# &
(
��& '
userConnected
��' 4
)
��4 5
;
��5 6
}
�� 
}
�� 
}
�� 	
public
�� 
int
�� "
FindPlayerIsConected
�� '
(
��' (
string
��( .
usernamePlayer
��/ =
)
��= >
{
�� 	
int
�� 

isConected
�� 
=
�� 
$num
��  
;
��  !
int
�� 
userNotConected
�� 
=
��  !
$num
��" %
;
��% &
if
�� 
(
�� 
users
�� 
.
�� 
FirstOrDefault
�� $
(
��$ %
user
��% )
=>
��* ,
user
��- 1
.
��1 2
username
��2 :
.
��: ;
Equals
��; A
(
��A B
usernamePlayer
��B P
)
��P Q
)
��Q R
==
��S U
null
��V Z
)
��Z [
{
�� 

isConected
�� 
=
�� 
userNotConected
�� ,
;
��, -
}
�� 
return
�� 

isConected
�� 
;
�� 
}
�� 	
public
�� 
int
�� 
FindPlayerInGroup
�� $
(
��$ %
string
��% +
usernameToFind
��, :
)
��: ;
{
�� 	
int
�� 

statusUser
�� 
=
�� 
$num
��  
;
��  !
int
�� 
userNotFound
�� 
=
�� 
$num
�� "
;
��" #
if
�� 
(
�� 
playersInGroup
�� 
.
�� 
FirstOrDefault
�� -
(
��- .
user
��. 2
=>
��3 5
user
��6 :
.
��: ;
username
��; C
.
��C D
Equals
��D J
(
��J K
usernameToFind
��K Y
)
��Y Z
)
��Z [
==
��\ ^
null
��_ c
)
��c d
{
�� 

statusUser
�� 
=
�� 
userNotFound
�� )
;
��) *
}
�� 
return
�� 

statusUser
�� 
;
�� 
}
�� 	
public
�� 
int
�� 
GroupIsNotFull
�� !
(
��! "
)
��" #
{
�� 	
int
�� 

statusCode
�� 
=
�� 
$num
��  
;
��  !
if
�� 
(
�� 
playersInGroup
�� 
.
�� 
Count
�� $
<=
��% '
$num
��( )
)
��) *
{
�� 

statusCode
�� 
=
�� 
$num
��  
;
��  !
}
�� 
return
�� 

statusCode
�� 
;
�� 
}
�� 	
public
�� 
List
�� 
<
�� 
string
�� 
>
�� ,
GetListUsernamesPlayersInGroup
�� :
(
��: ;
)
��; <
{
�� 	
List
�� 
<
�� 
string
�� 
>
�� 
groupPlayers
�� %
=
��& '
new
��( +
List
��, 0
<
��0 1
string
��1 7
>
��7 8
(
��8 9
)
��9 :
;
��: ;
foreach
�� 
(
�� 
ConnectedUser
�� "
playerConnected
��# 2
in
��3 5
playersInGroup
��6 D
)
��D E
{
�� 
groupPlayers
�� 
.
�� 
Add
��  
(
��  !
playerConnected
��! 0
.
��0 1
username
��1 9
)
��9 :
;
��: ;
}
�� 
return
�� 
groupPlayers
�� 
;
��  
}
�� 	
public
�� 
void
�� 

StartMatch
�� 
(
�� 
string
�� %
username
��& .
)
��. /
{
�� 	
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
if
�� 
(
�� 
user
�� 
.
�� 
username
�� !
.
��! "
Equals
��" (
(
��( )
username
��) 1
)
��1 2
&&
��3 5
user
��6 :
.
��: ;
	hostState
��; D
)
��D E
{
�� 
foreach
�� 
(
�� 
ConnectedUser
�� *
connectedUser
��+ 8
in
��9 ;
playersInGroup
��< J
)
��J K
{
�� 
connectedUser
�� %
.
��% &
operationContext
��& 6
.
��6 7 
GetCallbackChannel
��7 I
<
��I J&
IPlayersServicesCallBack
��J b
>
��b c
(
��c d
)
��d e
.
��e f
OpenMatchWindow
��f u
(
��u v
)
��v w
;
��w x
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
public
�� 

partial
�� 
class
�� $
ImplementationServices
�� /
:
��0 1
IMatchManagement
��2 B
{
�� 
private
�� 
int
�� 

turnNumber
�� 
=
��  
$num
��! "
;
��" #
public
�� 
void
�� 
SelectTurnTime
�� "
(
��" #
)
��# $
{
�� 	
int
�� 
[
�� 
]
�� 
seconds
�� 
=
�� 
{
�� 
$num
��  
,
��  !
$num
��" $
,
��$ %
$num
��& (
,
��( )
$num
��* ,
}
��- .
;
��. /
Random
�� 
random
�� 
=
�� 
new
�� 
Random
��  &
(
��& '
)
��' (
;
��( )
int
�� 
time
�� 
=
�� 
seconds
�� 
[
�� 
random
�� %
.
��% &
Next
��& *
(
��* +
seconds
��+ 2
.
��2 3
Length
��3 9
)
��9 :
]
��: ;
;
��; <
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
user
�� 
.
�� 
matchContext
�� !
.
��! " 
GetCallbackChannel
��" 4
<
��4 5
IMatchCallback
��5 C
>
��C D
(
��D E
)
��E F
.
��F G 
DistributeTurnTime
��G Y
(
��Y Z
time
��Z ^
)
��^ _
;
��_ `
}
�� 
}
�� 	
public
�� 
void
�� 
SendCard
�� 
(
�� 
string
�� #
card
��$ (
)
��( )
{
�� 	
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
user
�� 
.
�� 
matchContext
�� !
.
��! " 
GetCallbackChannel
��" 4
<
��4 5
IMatchCallback
��5 C
>
��C D
(
��D E
)
��E F
.
��F G
DistributeCard
��G U
(
��U V
card
��V Z
)
��Z [
;
��[ \
}
�� 
}
�� 	
public
�� 
void
�� &
SetMatchOperationContext
�� ,
(
��, -
string
��- 3
username
��4 <
)
��< =
{
�� 	
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
if
�� 
(
�� 
user
�� 
.
�� 
username
�� !
.
��! "
Equals
��" (
(
��( )
username
��) 1
)
��1 2
)
��2 3
{
�� 
user
�� 
.
�� 
matchContext
�� %
=
��& '
OperationContext
��( 8
.
��8 9
Current
��9 @
;
��@ A
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
StartTurnSignal
�� #
(
��# $
string
��$ *
username
��+ 3
)
��3 4
{
�� 	
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
if
�� 
(
�� 
user
�� 
.
�� 
username
�� !
.
��! "
Equals
��" (
(
��( )
username
��) 1
)
��1 2
&&
��3 5
user
��6 :
.
��: ;
	hostState
��; D
)
��D E
{
�� 
foreach
�� 
(
�� 
ConnectedUser
�� *
	matchUser
��+ 4
in
��5 7
playersInGroup
��8 F
)
��F G
{
�� 

turnNumber
�� "
++
��" $
;
��$ %
	matchUser
�� !
.
��! "
matchContext
��" .
.
��. / 
GetCallbackChannel
��/ A
<
��A B
IMatchCallback
��B P
>
��P Q
(
��Q R
)
��R S
.
��S T#
ReturnStartTurnSignal
��T i
(
��i j

turnNumber
��j t
)
��t u
;
��u v
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
public
�� 

partial
�� 
class
�� $
ImplementationServices
�� /
:
��0 1
IChatServices
��2 ?
{
�� 
public
�� 
void
�� 
SendMessage
�� 
(
��  
string
��  &
senderUsername
��' 5
,
��5 6
string
��7 =
message
��> E
)
��E F
{
�� 	
	ChatLogic
�� 
	chatLogic
�� 
=
��  !
new
��" %
	ChatLogic
��& /
(
��/ 0
)
��0 1
;
��1 2
string
�� 
completeMessage
�� "
=
��# $
	chatLogic
��% .
.
��. /
BuildMessage
��/ ;
(
��; <
senderUsername
��< J
,
��J K
message
��L S
)
��S T
;
��T U
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
user
�� 
.
�� 
chatContext
��  
.
��  ! 
GetCallbackChannel
��! 3
<
��3 4"
IChatServiceCallback
��4 H
>
��H I
(
��I J
)
��J K
.
��K L
MessageSend
��L W
(
��W X
completeMessage
��X g
)
��g h
;
��h i
}
�� 
}
�� 	
public
�� 
void
�� %
SetChatOperationContext
�� +
(
��+ ,
string
��, 2
username
��3 ;
)
��; <
{
�� 	
foreach
�� 
(
�� 
ConnectedUser
�� "
user
��# '
in
��( *
playersInGroup
��+ 9
)
��9 :
{
�� 
if
�� 
(
�� 
user
�� 
.
�� 
username
�� !
.
��! "
Equals
��" (
(
��( )
username
��) 1
)
��1 2
)
��2 3
{
�� 
user
�� 
.
�� 
chatContext
�� $
=
��% &
OperationContext
��' 7
.
��7 8
Current
��8 ?
;
��? @
}
�� 
}
�� 
}
�� 	
}
�� 
public
�� 

partial
�� 
class
�� $
ImplementationServices
�� /
:
��0 1 
IDrawReviewService
��2 D
{
�� 
List
�� 
<
�� 
byte
�� 
[
�� 
]
�� 
>
�� 
playersDraws
�� !
=
��" #
new
��$ '
List
��( ,
<
��, -
byte
��- 1
[
��1 2
]
��2 3
>
��3 4
(
��4 5
)
��5 6
;
��6 7
public
�� 
void
�� 
	SendDraws
�� 
(
�� 
byte
�� "
[
��" #
]
��# $
draw
��% )
)
��) *
{
�� 	
playersDraws
�� 
.
�� 
Add
�� 
(
�� 
draw
�� !
)
��! "
;
��" #
if
�� 
(
�� 
playersDraws
�� 
.
�� 
Count
�� "
>
��# $
$num
��% &
)
��& '
{
�� 
foreach
�� 
(
�� 
ConnectedUser
�� &
user
��' +
in
��, .
playersInGroup
��/ =
)
��= >
{
�� 
user
�� 
.
�� 
drawContext
�� $
.
��$ % 
GetCallbackChannel
��% 7
<
��7 8!
IDrawReviewCallback
��8 K
>
��K L
(
��L M
)
��M N
.
��N O
DistributeDraws
��O ^
(
��^ _
playersDraws
��_ k
)
��k l
;
��l m
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
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