�:
]C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\ChangePassword.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
ChangePassword '
:( )
Window* 0
{ 
public 
ChangePassword 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
private 
void 
Button_Cancel_Click (
(( )
object) /
sender0 6
,6 7
RoutedEventArgs8 G
eH I
)I J
{ 	
Close 
( 
) 
; 
} 	
private!! 
void!! (
Button_Change_Password_Click!! 1
(!!1 2
object!!2 8
sender!!9 ?
,!!? @
RoutedEventArgs!!A P
e!!Q R
)!!R S
{"" 	"
PlayerManagementClient## "
client### )
=##* +
new##, /"
PlayerManagementClient##0 F
(##F G
)##G H
;##H I
string$$ 
currentPassword$$ "
=$$# $'
PasswordBox_CurrentPassword$$% @
.$$@ A
Password$$A I
;$$I J
if%% 
(%% 
AutenticatePassword%% #
(%%# $
MainMenu%%$ ,
.%%, -
username%%- 5
,%%5 6
currentPassword%%7 F
)%%F G
==%%H J
$num%%K N
)%%N O
{&& 
if'' 
('' 
ValidatePassword'' $
(''$ %
)''% &
)''& '
{(( 
string)) 
password)) #
=))$ %'
PasswordBox_ConfirmPassword))& A
.))A B
Password))B J
;))J K
if** 
(** 
client** 
.**  
UpdatePlayerPassword** 3
(**3 4
MainMenu**4 <
.**< =
username**= E
,**E F
password**G O
)**O P
==**Q S
$num**T W
)**W X
{++ 

MessageBox,, "
.,," #
Show,,# '
(,,' (
$str,,( J
,,,J K
$str,,L N
,,,N O
MessageBoxButton,,P `
.,,` a
OK,,a c
,,,c d
MessageBoxImage,,e t
.,,t u
Information	,,u �
)
,,� �
;
,,� �
}-- 
else.. 
{// 

MessageBox00 "
.00" #
Show00# '
(00' (
$str00( O
,00O P
$str00Q S
,00S T
MessageBoxButton00U e
.00e f
OK00f h
,00h i
MessageBoxImage00j y
.00y z
Error00z 
)	00 �
;
00� �
}11 
}22 
}33 
else44 
{55 

MessageBox66 
.66 
Show66 
(66  
$str66  D
,66D E
$str66F H
,66H I
MessageBoxButton66J Z
.66Z [
OK66[ ]
,66] ^
MessageBoxImage66_ n
.66n o
Error66o t
)66t u
;66u v
}77 
client88 
.88 
Close88 
(88 
)88 
;88 
}99 	
private;; 
Boolean;; 
ValidatePassword;; (
(;;( )
);;) *
{<< 	"
Label_InvalidPasswords== "
.==" #

Visibility==# -
===. /

Visibility==0 :
.==: ;
Hidden==; A
;==A B
Boolean>> 
isValid>> 
=>> 
true>> "
;>>" #
string?? 
currentPassword?? "
=??# $'
PasswordBox_CurrentPassword??% @
.??@ A
Password??A I
;??I J
string@@ 
newPassword@@ 
=@@  #
PasswordBox_NewPassword@@! 8
.@@8 9
Password@@9 A
;@@A B
stringAA 
confirmPasswordAA "
=AA# $'
PasswordBox_ConfirmPasswordAA% @
.AA@ A
PasswordAAA I
;AAI J
ifBB 
(BB 
!BB 
newPasswordBB 
.BB 
EqualsBB #
(BB# $
confirmPasswordBB$ 3
)BB3 4
)BB4 5
{CC "
Label_InvalidPasswordsDD &
.DD& '

VisibilityDD' 1
=DD2 3

VisibilityDD4 >
.DD> ?
VisibleDD? F
;DDF G
isValidEE 
=EE 
falseEE 
;EE  
}FF 
ifHH 
(HH 
stringHH 
.HH 
IsNullOrEmptyHH $
(HH$ %
newPasswordHH% 0
)HH0 1
)HH1 2
{II "
Label_InvalidPasswordsJJ &
.JJ& '

VisibilityJJ' 1
=JJ2 3

VisibilityJJ4 >
.JJ> ?
VisibleJJ? F
;JJF G
isValidKK 
=KK 
falseKK 
;KK  
}LL 
ifNN 
(NN 
stringNN 
.NN 
IsNullOrEmptyNN $
(NN$ %
confirmPasswordNN% 4
)NN4 5
)NN5 6
{OO "
Label_InvalidPasswordsPP &
.PP& '

VisibilityPP' 1
=PP2 3

VisibilityPP4 >
.PP> ?
VisiblePP? F
;PPF G
isValidQQ 
=QQ 
falseQQ 
;QQ  
}RR 
ifTT 
(TT 
stringTT 
.TT 
IsNullOrEmptyTT $
(TT$ %
currentPasswordTT% 4
)TT4 5
)TT5 6
{UU "
Label_InvalidPasswordsVV &
.VV& '

VisibilityVV' 1
=VV2 3

VisibilityVV4 >
.VV> ?
VisibleVV? F
;VVF G
isValidWW 
=WW 
falseWW 
;WW  
}XX 
ifYY 
(YY 
!YY 

ValidationYY 
.YY 
ValidateFormatYY *
(YY* +
newPasswordYY+ 6
,YY6 7
$str	YY8 �
)
YY� �
)
YY� �
{ZZ 
isValid[[ 
=[[ 
false[[ 
;[[  
}\\ 
return]] 
isValid]] 
;]] 
}^^ 	
private`` 
int`` 
AutenticatePassword`` '
(``' (
string``( .
username``/ 7
,``7 8
string``9 ?
password``@ H
)``H I
{aa 	
intbb 
resultbb 
;bb 
PassThePenServicecc 
.cc 
Playercc $
playercc% +
=cc, -
newcc. 1
Playercc2 8
{cc9 :
usernamecc; C
=ccD E
usernameccF N
,ccN O
passwordccP X
=ccY Z
passwordcc[ c
}ccd e
;cce f
PassThePenServicedd 
.dd 
AutenticationClientdd 1
clientdd2 8
=dd9 :
newdd; >
PassThePenServicedd? P
.ddP Q
AutenticationClientddQ d
(ddd e
)dde f
;ddf g
resultee 
=ee 
clientee 
.ee 
AutenticatePlayeree -
(ee- .
playeree. 4
)ee4 5
;ee5 6
clientff 
.ff 
Closeff 
(ff 
)ff 
;ff 
returngg 
resultgg 
;gg 
}hh 	
}ii 
}jj �
YC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\DrawReview.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 

DrawReview #
:$ %
Window& ,
{ 
public 
static 
byte 
[ 
] 
bytes "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 

DrawReview 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
Image_ReviewDraw 
. 
Source #
=$ %
ConvertByteToImage& 8
(8 9
bytes9 >
)> ?
;? @
} 	
public!! 
BitmapImage!! 
ConvertByteToImage!! -
(!!- .
byte!!. 2
[!!2 3
]!!3 4
array!!5 :
)!!: ;
{"" 	
using## 
(## 
var## 
ms## 
=## 
new## 
System##  &
.##& '
IO##' )
.##) *
MemoryStream##* 6
(##6 7
array##7 <
)##< =
)##= >
{$$ 
var%% 
image%% 
=%% 
new%% 
BitmapImage%%  +
(%%+ ,
)%%, -
;%%- .
image&& 
.&& 
	BeginInit&& 
(&&  
)&&  !
;&&! "
image'' 
.'' 
CacheOption'' !
=''" #
BitmapCacheOption''$ 5
.''5 6
OnLoad''6 <
;''< =
image(( 
.(( 
StreamSource(( "
=((# $
ms((% '
;((' (
image)) 
.)) 
EndInit)) 
()) 
))) 
;))  
return** 
image** 
;** 
}++ 
},, 	
private.. 
void.. #
Button_SendReview_Click.. ,
(.., -
object..- 3
sender..4 :
,..: ;
RoutedEventArgs..< K
e..L M
)..M N
{// 	
int00 
value00 
=00 
(00 
int00 
)00 
Rating_DrawReview00 .
.00. /
Value00/ 4
;004 5

MessageBox11 
.11 
Show11 
(11 
$str11 *
+11+ ,
value11- 2
)112 3
;113 4
}22 	
}33 
}44 �
VC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\ImageManager.cs
	namespace 	

PassThePen
 
{		 
public

 

static

 
class

 
ImageManager

 $
{ 
public 
static 
BitmapImage !
ToImage" )
() *
byte* .
[. /
]/ 0
array1 6
)6 7
{ 	
using 
( 
var 
ms 
= 
new 
System  &
.& '
IO' )
.) *
MemoryStream* 6
(6 7
array7 <
)< =
)= >
{ 
var 
image 
= 
new 
BitmapImage  +
(+ ,
), -
;- .
image 
. 
	BeginInit 
(  
)  !
;! "
image 
. 
CacheOption !
=" #
BitmapCacheOption$ 5
.5 6
OnLoad6 <
;< =
image 
. 
StreamSource "
=# $
ms% '
;' (
image 
. 
EndInit 
( 
) 
;  
return 
image 
; 
} 
} 	
} 
} ��
WC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\MainMenu.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
MainMenu !
:" #
Window$ *
,* +
PassThePenService, =
.= >%
IPlayerConnectionCallback> W
{ 
public 
static 
string 
username %
{& '
set( +
;+ ,
get- 0
;0 1
}2 3
private 
List 
< 
string 
> 
listUsernameStrings 0
=1 2
new3 6
List7 ;
<; <
string< B
>B C
(C D
)D E
;E F
private   
List   
<   
Friends   
>   

friendList   (
=  ) *
new  + .
List  / 3
<  3 4
Friends  4 ;
>  ; <
(  < =
)  = >
;  > ?
private!! 
List!! 
<!! 
FriendRequest!! "
>!!" #
friendRequests!!$ 2
=!!3 4
new!!5 8
List!!9 =
<!!= >
FriendRequest!!> K
>!!K L
(!!L M
)!!M N
;!!N O
public## 
int## !
NotifyMatchInvitation## (
(##( )
string##) /
invitingPlayer##0 >
)##> ?
{$$ 	
int%% 
operationResult%% 
=%%  !
$num%%" %
;%%% &
var&& 
response&& 
=&& 

MessageBox&& %
.&&% &
Show&&& *
(&&* +
$str&&+ Y
,&&Y Z
invitingPlayer&&[ i
+&&j k
$str	&&l �
,
&&� �
MessageBoxButton
&&� �
.
&&� �
YesNo
&&� �
)
&&� �
;
&&� �
if'' 
('' 
response'' 
=='' 
MessageBoxResult'' ,
.'', -
Yes''- 0
)''0 1
{(( 

MessageBox)) 
.)) 
Show)) 
())  
$str))  7
)))7 8
;))8 9
operationResult** 
=**  !
$num**" %
;**% &
}++ 
return,, 
operationResult,, "
;,," #
}-- 	
public// 
MainMenu// 
(// 
)// 
{00 	
InitializeComponent11 
(11  
)11  !
;11! "
	Connected22 
(22 
)22 
;22 

GetFriends33 
(33 
)33 
;33 
listUsernameStrings44 
.44  
Clear44  %
(44% &
)44& '
;44' (
SetDataProfile55 
(55 
)55 
;55 
}66 	
private88 
void88  
Button_Profile_Click88 )
(88) *
object88* 0
sender881 7
,887 8
RoutedEventArgs889 H
e88I J
)88J K
{99 	
Profile:: 
profile:: 
=:: 
new:: !
Profile::" )
(::) *
)::* +
;::+ ,
profile;; 
.;; 
Show;; 
(;; 
);; 
;;; 
}== 	
private@@ 
void@@ $
Button_FindFriends_Click@@ -
(@@- .
object@@. 4
sender@@5 ;
,@@; <
RoutedEventArgs@@= L
e@@M N
)@@N O
{AA 	
listUsernameStringsBB 
.BB  
ClearBB  %
(BB% &
)BB& '
;BB' (
ifCC 
(CC 
TextBox_FindFriendCC "
.CC" #

VisibilityCC# -
==CC. 0

VisibilityCC1 ;
.CC; <
	CollapsedCC< E
&&CCF H
ListBox_FriendListCCI [
.CC[ \

VisibilityCC\ f
==CCg i

VisibilityCCj t
.CCt u
VisibleCCu |
)CC| }
{DD 
TextBox_FindFriendEE "
.EE" #

VisibilityEE# -
=EE. /

VisibilityEE0 :
.EE: ;
VisibleEE; B
;EEB C

friendListFF 
.FF 
ForEachFF "
(FF" #
friFF# &
=>FF' )
listUsernameStringsFF* =
.FF= >
AddFF> A
(FFA B
friFFB E
.FFE F
friendUsernameFFF T
)FFT U
)FFU V
;FFV W
}GG 
elseHH 
ifHH 
(HH 
TextBox_FindFriendHH '
.HH' (

VisibilityHH( 2
==HH3 5

VisibilityHH6 @
.HH@ A
	CollapsedHHA J
&&HHK M#
ListBox_FriendsRequestsHHN e
.HHe f

VisibilityHHf p
==HHq s

VisibilityHHt ~
.HH~ 
Visible	HH �
)
HH� �
{II 
TextBox_FindFriendJJ "
.JJ" #

VisibilityJJ# -
=JJ. /

VisibilityJJ0 :
.JJ: ;
VisibleJJ; B
;JJB C
friendRequestsKK 
.KK 
ForEachKK &
(KK& '
friKK' *
=>KK+ -
listUsernameStringsKK. A
.KKA B
AddKKB E
(KKE F
friKKF I
.KKI J
friendUsernameKKJ X
)KKX Y
)KKY Z
;KKZ [
}LL 
elseMM 
{NN 
TextBox_FindFriendOO "
.OO" #

VisibilityOO# -
=OO. /

VisibilityOO0 :
.OO: ;
	CollapsedOO; D
;OOD E
TextBox_FindFriendPP "
.PP" #
TextPP# '
=PP( )
$strPP* ,
;PP, -
}QQ 
}SS 	
privateUU 
voidUU !
Button_ExitGame_ClickUU *
(UU* +
objectUU+ 1
senderUU2 8
,UU8 9
RoutedEventArgsUU: I
eUUJ K
)UUK L
{VV 	
InstanceContextWW 
instanceContextWW +
=WW, -
newWW. 1
InstanceContextWW2 A
(WWA B
thisWWB F
)WWF G
;WWG H
PassThePenServiceXX 
.XX "
PlayerConnectionClientXX 4
clientXX5 ;
=XX< =
newXX> A"
PlayerConnectionClientXXB X
(XXX Y
instanceContextXXY h
)XXh i
;XXi j
clientYY 
.YY 

DisconnectYY 
(YY 
usernameYY &
)YY& '
;YY' (
LoginZZ 
loginZZ 
=ZZ 
newZZ 
LoginZZ #
(ZZ# $
)ZZ$ %
;ZZ% &
login[[ 
.[[ 
Show[[ 
([[ 
)[[ 
;[[ 
client\\ 
.\\ 
Close\\ 
(\\ 
)\\ 
;\\ 
this]] 
.]] 
Close]] 
(]] 
)]] 
;]] 
}^^ 	
privatebb 
voidbb '
Button_FriendRequests_Clickbb 0
(bb0 1
objectbb1 7
senderbb8 >
,bb> ?
RoutedEventArgsbb@ O
ebbP Q
)bbQ R
{cc 	
label_ListFriendsdd 
.dd 

Visibilitydd (
=dd) *

Visibilitydd+ 5
.dd5 6
	Collapseddd6 ?
;dd? @ 
label_FriendRequestsee  
.ee  !

Visibilityee! +
=ee, -

Visibilityee. 8
.ee8 9
Visibleee9 @
;ee@ A
TextBox_FindFriendff 
.ff 

Visibilityff )
=ff* +

Visibilityff, 6
.ff6 7
	Collapsedff7 @
;ff@ A
TextBox_FindFriendgg 
.gg 
Textgg #
=gg$ %
$strgg& (
;gg( )%
GenerateFriendRequestListhh %
(hh% &
)hh& '
;hh' (
}ii 	
privatemm 
voidmm  
Button_Friends_Clickmm )
(mm) *
objectmm* 0
sendermm1 7
,mm7 8
RoutedEventArgsmm9 H
emmI J
)mmJ K
{nn 	 
label_FriendRequestsoo  
.oo  !

Visibilityoo! +
=oo, -

Visibilityoo. 8
.oo8 9
	Collapsedoo9 B
;ooB C
label_ListFriendspp 
.pp 

Visibilitypp (
=pp) *

Visibilitypp+ 5
.pp5 6
Visiblepp6 =
;pp= >#
ListBox_FriendsRequestsqq #
.qq# $

Visibilityqq$ .
=qq/ 0

Visibilityqq1 ;
.qq; <
	Collapsedqq< E
;qqE F
ListBox_FriendListrr 
.rr 

Visibilityrr )
=rr* +

Visibilityrr, 6
.rr6 7
Visiblerr7 >
;rr> ?
TextBox_FindFriendss 
.ss 

Visibilityss )
=ss* +

Visibilityss, 6
.ss6 7
	Collapsedss7 @
;ss@ A
TextBox_FindFriendtt 
.tt 
Texttt #
=tt$ %
$strtt& (
;tt( )

GetFriendsuu 
(uu 
)uu 
;uu 
}vv 	
privatexx 
voidxx (
Button_ConfirmRequests_Clickxx 1
(xx1 2
objectxx2 8
senderxx9 ?
,xx? @
RoutedEventArgsxxA P
exxQ R
)xxR S
{yy 	
FriendRequestzz 
newFriendRequestszz +
=zz, -0
$GetFriendRequestOfListboxImageButtonzz. R
(zzR S
senderzzS Y
)zzY Z
;zzZ [ 
FriendRequestsClient{{  
clientFriendRequest{{! 4
={{5 6
new{{7 : 
FriendRequestsClient{{; O
({{O P
){{P Q
;{{Q R"
PlayerManagementClient|| "
clientFriends||# 0
=||1 2
new||3 6"
PlayerManagementClient||7 M
(||M N
)||N O
;||O P
clientFriendRequest}} 
.}}  
AcceptFriendRequest}}  3
(}}3 4
newFriendRequests}}4 E
)}}E F
;}}F G%
GenerateFriendRequestList~~ %
(~~% &
)~~& '
;~~' (
clientFriends 
. 

GetFriends $
($ %
username% -
)- .
;. /
}
�� 	
private
�� 
void
�� *
Button_DeclineRequests_Click
�� 1
(
��1 2
object
��2 8
sender
��9 ?
,
��? @
RoutedEventArgs
��A P
e
��Q R
)
��R S
{
�� 	
PassThePenService
�� 
.
�� "
FriendRequestsClient
�� 2
client
��3 9
=
��: ;
new
��< ?"
FriendRequestsClient
��@ T
(
��T U
)
��U V
;
��V W
FriendRequest
�� 
newFriendRequests
�� +
=
��, -2
$GetFriendRequestOfListboxImageButton
��. R
(
��R S
sender
��S Y
)
��Y Z
;
��Z [
client
�� 
.
�� #
DeclineFriendRequests
�� (
(
��( )
newFriendRequests
��) :
)
��: ;
;
��; <'
GenerateFriendRequestList
�� %
(
��% &
)
��& '
;
��' (
}
�� 	
private
�� 
FriendRequest
�� 2
$GetFriendRequestOfListboxImageButton
�� B
(
��B C
object
��C I
sender
��J P
)
��P Q
{
�� 	
Image
��  
buttonDeleteFriend
�� $
=
��% &
(
��' (
Image
��( -
)
��- .
sender
��. 4
;
��4 5

StackPanel
�� 
parent
�� 
=
�� 
(
��  !

StackPanel
��! +
)
��+ , 
buttonDeleteFriend
��, >
.
��> ?
Parent
��? E
;
��E F
FriendRequest
�� 
friendRequest
�� '
=
��( )
(
��* +
FriendRequest
��+ 8
)
��8 9
parent
��9 ?
.
��? @
DataContext
��@ K
;
��K L
return
�� 
friendRequest
��  
;
��  !
}
�� 	
private
�� 
void
�� '
GenerateFriendRequestList
�� .
(
��. /
)
��/ 0
{
�� 	 
ListBox_FriendList
�� 
.
�� 

Visibility
�� )
=
��* +

Visibility
��, 6
.
��6 7
	Collapsed
��7 @
;
��@ A%
ListBox_FriendsRequests
�� #
.
��# $

Visibility
��$ .
=
��/ 0

Visibility
��1 ;
.
��; <
Visible
��< C
;
��C D"
FriendRequestsClient
��  
client
��! '
=
��( )
new
��* -"
FriendRequestsClient
��. B
(
��B C
)
��C D
;
��D E
friendRequests
�� 
=
�� 
client
�� #
.
��# $#
GetFriendRequestsList
��$ 9
(
��9 :
username
��: B
)
��B C
.
��C D
ToList
��D J
(
��J K
)
��K L
;
��L M%
ListBox_FriendsRequests
�� #
.
��# $
ItemsSource
��$ /
=
��0 1
friendRequests
��2 @
;
��@ A
}
�� 	
private
�� 
void
�� 
	Connected
�� 
(
�� 
)
��  
{
�� 	
InstanceContext
�� 
instanceContext
�� +
=
��, -
new
��. 1
InstanceContext
��2 A
(
��A B
this
��B F
)
��F G
;
��G H
PassThePenService
�� 
.
�� $
PlayerConnectionClient
�� 4
client
��5 ;
=
��< =
new
��> A$
PlayerConnectionClient
��B X
(
��X Y
instanceContext
��Y h
)
��h i
;
��i j
client
�� 
.
�� 
Connect
�� 
(
�� 
username
�� #
)
��# $
;
��$ %
}
�� 	
private
�� 
void
�� 

GetFriends
�� 
(
��  
)
��  !
{
�� 	
InstanceContext
�� 
instanceContext
�� +
=
��, -
new
��. 1
InstanceContext
��2 A
(
��A B
this
��B F
)
��F G
;
��G H
PassThePenService
�� 
.
�� $
PlayerConnectionClient
�� 4
client
��5 ;
=
��< =
new
��> A$
PlayerConnectionClient
��B X
(
��X Y
instanceContext
��Y h
)
��h i
;
��i j
client
�� 
.
�� 
SendOnlinePlayers
�� $
(
��$ %
username
��% -
)
��- .
;
��. /
}
�� 	
public
�� 
void
�� 
PlayersCallBack
�� #
(
��# $
Friends
��$ +
[
��+ ,
]
��, -
friends
��. 5
)
��5 6
{
�� 	

friendList
�� 
=
�� 
friends
��  
.
��  !
ToList
��! '
(
��' (
)
��( )
;
��) * 
ListBox_FriendList
�� 
.
�� 
ItemsSource
�� *
=
��+ ,

friendList
��- 7
;
��7 8
}
�� 	
private
�� 
void
�� %
Button_StartMatch_Click
�� ,
(
��, -
object
��- 3
sender
��4 :
,
��: ;
RoutedEventArgs
��< K
e
��L M
)
��M N
{
�� 	
InstanceContext
�� 
instanceContext
�� +
=
��, -
new
��. 1
InstanceContext
��2 A
(
��A B
this
��B F
)
��F G
;
��G H
PassThePenService
�� 
.
�� $
PlayerConnectionClient
�� 4
client
��5 ;
=
��< =
new
��> A
PassThePenService
��B S
.
��S T$
PlayerConnectionClient
��T j
(
��j k
instanceContext
��k z
)
��z {
;
��{ |
client
�� 
.
�� 

StartMatch
�� 
(
�� 
username
�� &
)
��& '
;
��' (
}
�� 	
private
�� 
void
�� ,
TextBox_FindFriend_TextChanged
�� 3
(
��3 4
object
��4 :
sender
��; A
,
��A B"
TextChangedEventArgs
��C W
e
��X Y
)
��Y Z
{
�� 	
if
�� 
(
��  
ListBox_FriendList
�� "
.
��" #

Visibility
��# -
==
��. 0

Visibility
��1 ;
.
��; <
Visible
��< C
)
��C D
{
�� 
FilterFriendList
��  
(
��  !
)
��! "
;
��" #
}
�� 
else
�� 
if
�� 
(
�� %
ListBox_FriendsRequests
�� ,
.
��, -

Visibility
��- 7
==
��8 :

Visibility
��; E
.
��E F
Visible
��F M
)
��M N
{
�� #
FilterFriendsRequests
�� %
(
��% &
)
��& '
;
��' (
}
�� 
}
�� 	
private
�� 
void
�� #
FilterFriendsRequests
�� *
(
��* +
)
��+ ,
{
�� 	
if
�� 
(
�� 
!
�� 
String
�� 
.
�� 
IsNullOrEmpty
�� %
(
��% & 
TextBox_FindFriend
��& 8
.
��8 9
Text
��9 =
.
��= >
Trim
��> B
(
��B C
)
��C D
)
��D E
)
��E F
{
�� 
List
�� 
<
�� 
FriendRequest
�� "
>
��" #
friendsEquals
��$ 1
=
��2 3
new
��4 7
List
��8 <
<
��< =
FriendRequest
��= J
>
��J K
(
��K L
)
��L M
;
��M N
foreach
�� 
(
�� 
string
�� 
str
��  #
in
��$ &!
listUsernameStrings
��' :
)
��: ;
{
�� 
if
�� 
(
�� 
str
�� 
.
�� 

StartsWith
�� &
(
��& ' 
TextBox_FindFriend
��' 9
.
��9 :
Text
��: >
.
��> ?
Trim
��? C
(
��C D
)
��D E
)
��E F
)
��F G
{
�� 
friendsEquals
�� %
.
��% &
Add
��& )
(
��) *
friendRequests
��* 8
.
��8 9
Find
��9 =
(
��= >
fri
��> A
=>
��B D
fri
��E H
.
��H I
friendUsername
��I W
.
��W X
Contains
��X `
(
��` a
str
��a d
)
��d e
)
��e f
)
��f g
;
��g h
}
�� 
}
�� %
ListBox_FriendsRequests
�� '
.
��' (
ItemsSource
��( 3
=
��4 5
friendsEquals
��6 C
;
��C D
}
�� 
else
�� 
if
�� 
(
��  
TextBox_FindFriend
�� '
.
��' (
Text
��( ,
.
��, -
Trim
��- 1
(
��1 2
)
��2 3
==
��4 6
$str
��7 9
)
��9 :
{
�� %
ListBox_FriendsRequests
�� '
.
��' (
ItemsSource
��( 3
=
��4 5
friendRequests
��6 D
;
��D E
}
�� 
}
�� 	
private
�� 
void
�� 
FilterFriendList
�� %
(
��% &
)
��& '
{
�� 	
if
�� 
(
�� 
!
�� 
String
�� 
.
�� 
IsNullOrEmpty
�� %
(
��% & 
TextBox_FindFriend
��& 8
.
��8 9
Text
��9 =
.
��= >
Trim
��> B
(
��B C
)
��C D
)
��D E
)
��E F
{
�� 
List
�� 
<
�� 
Friends
�� 
>
�� 
friendsEquals
�� +
=
��, -
new
��. 1
List
��2 6
<
��6 7
Friends
��7 >
>
��> ?
(
��? @
)
��@ A
;
��A B
foreach
�� 
(
�� 
string
�� 
str
��  #
in
��$ &!
listUsernameStrings
��' :
)
��: ;
{
�� 
if
�� 
(
�� 
str
�� 
.
�� 

StartsWith
�� &
(
��& ' 
TextBox_FindFriend
��' 9
.
��9 :
Text
��: >
.
��> ?
Trim
��? C
(
��C D
)
��D E
)
��E F
)
��F G
{
�� 
friendsEquals
�� %
.
��% &
Add
��& )
(
��) *

friendList
��* 4
.
��4 5
Find
��5 9
(
��9 :
fri
��: =
=>
��> @
fri
��A D
.
��D E
friendUsername
��E S
.
��S T
Contains
��T \
(
��\ ]
str
��] `
)
��` a
)
��a b
)
��b c
;
��c d
}
�� 
}
��  
ListBox_FriendList
�� "
.
��" #
ItemsSource
��# .
=
��/ 0
friendsEquals
��1 >
;
��> ?
}
�� 
else
�� 
if
�� 
(
��  
TextBox_FindFriend
�� '
.
��' (
Text
��( ,
.
��, -
Trim
��- 1
(
��1 2
)
��2 3
==
��4 6
$str
��7 9
)
��9 :
{
��  
ListBox_FriendList
�� "
.
��" #
ItemsSource
��# .
=
��/ 0

friendList
��1 ;
;
��; <
}
�� 
}
�� 	
private
�� 
void
�� '
Button_DeleteFriend_Click
�� .
(
��. /
object
��/ 5
sender
��6 <
,
��< ="
MouseButtonEventArgs
��> R
e
��S T
)
��T U
{
�� 	
Image
��  
buttonDeleteFriend
�� $
=
��% &
(
��' (
Image
��( -
)
��- .
sender
��. 4
;
��4 5

StackPanel
�� 
parent
�� 
=
�� 
(
��  !

StackPanel
��! +
)
��+ , 
buttonDeleteFriend
��, >
.
��> ?
Parent
��? E
;
��E F
Friends
�� 
friend
�� 
=
�� 
(
�� 
Friends
�� %
)
��% &
parent
��& ,
.
��, -
DataContext
��- 8
;
��8 9
PassThePenService
�� 
.
�� $
PlayerManagementClient
�� 4
client
��5 ;
=
��< =
new
��> A
PassThePenService
��B S
.
��S T$
PlayerManagementClient
��T j
(
��j k
)
��k l
;
��l m
client
�� 
.
�� 
DeleteFriend
�� 
(
��  
friend
��  &
)
��& '
;
��' (

GetFriends
�� 
(
�� 
)
�� 
;
�� 
client
�� 
.
�� 
Close
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
private
�� 
void
�� $
Button_AddFriend_Click
�� +
(
��+ ,
object
��, 2
sender
��3 9
,
��9 :
RoutedEventArgs
��; J
e
��K L
)
��L M
{
�� 	$
PlayerManagementClient
�� "
playerClient
��# /
=
��0 1
new
��2 5$
PlayerManagementClient
��6 L
(
��L M
)
��M N
;
��N O
int
�� 
playerExist
�� 
=
�� 
$num
�� !
;
��! "
if
�� 
(
�� 
playerClient
�� 
.
�� 

FindPlayer
�� '
(
��' (
Textbox_AddFriend
��( 9
.
��9 :
Text
��: >
)
��> ?
==
��@ B
playerExist
��C N
)
��N O
{
�� 
PassThePenService
�� !
.
��! ""
FriendRequestsClient
��" 6
client
��7 =
=
��> ?
new
��@ C"
FriendRequestsClient
��D X
(
��X Y
)
��Y Z
;
��Z [
FriendRequest
�� 
friendRequest
�� +
=
��, -
new
��. 1
FriendRequest
��2 ?
(
��? @
)
��@ A
{
�� 
usernamePlayer
�� "
=
��# $
Textbox_AddFriend
��% 6
.
��6 7
Text
��7 ;
,
��; <
friendUsername
�� "
=
��# $
username
��% -
}
�� 
;
�� 
client
�� 
.
��  
SendFriendRequests
�� )
(
��) *
friendRequest
��* 7
)
��7 8
;
��8 9

MessageBox
�� 
.
�� 
Show
�� 
(
��  
$str
��  O
)
��O P
;
��P Q
}
�� 
else
�� 
{
�� 

MessageBox
�� 
.
�� 
Show
�� 
(
��  
$str
��  a
)
��a b
;
��b c
}
�� 
}
�� 	
private
�� 
void
�� '
Button_InviteFriend_Click
�� .
(
��. /
object
��/ 5
sender
��6 <
,
��< ="
MouseButtonEventArgs
��> R
e
��S T
)
��T U
{
�� 	
InstanceContext
�� 
context
�� #
=
��$ %
new
��& )
InstanceContext
��* 9
(
��9 :
this
��: >
)
��> ?
;
��? @
PassThePenService
�� 
.
�� $
PlayerConnectionClient
�� 4
client
��5 ;
=
��< =
new
��> A
PassThePenService
��B S
.
��S T$
PlayerConnectionClient
��T j
(
��j k
context
��k r
)
��r s
;
��s t
Image
��  
buttonInviteFriend
�� $
=
��% &
(
��' (
Image
��( -
)
��- .
sender
��. 4
;
��4 5

StackPanel
�� 
parent
�� 
=
�� 
(
��  !

StackPanel
��! +
)
��+ , 
buttonInviteFriend
��, >
.
��> ?
Parent
��? E
;
��E F
Friends
�� 
friend
�� 
=
�� 
(
�� 
Friends
�� %
)
��% &
parent
��& ,
.
��, -
DataContext
��- 8
;
��8 9
int
�� &
statusPlayerIsNotInGroup
�� (
=
��) *
$num
��+ .
;
��. /
int
�� 
playerIsConected
��  
=
��! "
$num
��# &
;
��& '
int
�� 
groupIsNotFull
�� 
=
��  
$num
��! $
;
��$ %
if
�� 
(
�� 
client
�� 
.
�� "
FindPlayerIsConected
�� +
(
��+ ,
friend
��, 2
.
��2 3
friendUsername
��3 A
)
��A B
==
��C E
playerIsConected
��F V
&&
��W Y
client
��Z `
.
��` a
GroupIsNotFull
��a o
(
��o p
)
��p q
==
��r t
groupIsNotFull��u �
)��� �
{
�� 
if
�� 
(
�� 
client
�� 
.
�� 
FindPlayerInGroup
�� ,
(
��, -
friend
��- 3
.
��3 4
friendUsername
��4 B
)
��B C
==
��D F&
statusPlayerIsNotInGroup
��G _
)
��_ `
{
�� 
client
�� 
.
��  
SendMathInvitation
�� -
(
��- .
username
��. 6
,
��6 7
friend
��8 >
.
��> ?
friendUsername
��? M
)
��M N
;
��N O
}
�� 
else
�� 
{
�� 

MessageBox
�� 
.
�� 
Show
�� #
(
��# $
$str
��$ [
)
��[ \
;
��\ ]
}
�� 
}
�� 
else
�� 
{
�� 

MessageBox
�� 
.
�� 
Show
�� 
(
��  
$str
��  F
)
��F G
;
��G H
}
�� 
if
�� 
(
�� 
client
�� 
.
�� 
GroupIsNotFull
�� %
(
��% &
)
��& '
!=
��( *
groupIsNotFull
��+ 9
)
��9 :
{
�� 

MessageBox
�� 
.
�� 
Show
�� 
(
��  
$str
��  =
)
��= >
;
��> ?
}
�� 
}
�� 	
private
�� 
void
�� 
SetDataProfile
�� #
(
��# $
)
��$ %
{
�� 	
PassThePenService
�� 
.
�� $
PlayerManagementClient
�� 4
client
��5 ;
=
��< =
new
��> A
PassThePenService
��B S
.
��S T$
PlayerManagementClient
��T j
(
��j k
)
��k l
;
��l m
Player
�� 
playerObtained
�� !
=
��" #
client
��$ *
.
��* +
GetDataPlayer
��+ 8
(
��8 9
username
��9 A
)
��A B
;
��B C 
Image_ProfileImage
�� 
.
�� 
Source
�� %
=
��& '
ImageManager
��( 4
.
��4 5
ToImage
��5 <
(
��< =
playerObtained
��= K
.
��K L
profileImage
��L X
)
��X Y
;
��Y Z#
Label_PrincipalPlayer
�� !
.
��! "
Content
��" )
=
��* +
username
��, 4
;
��4 5
}
�� 	
public
�� 
void
�� 
OpenMatchWindow
�� #
(
��# $
)
��$ %
{
�� 	
Match
�� 
match
�� 
=
�� 
new
�� 
Match
�� #
(
��# $
)
��$ %
;
��% &
match
�� 
.
�� 
Show
�� 
(
�� 
)
�� 
;
�� 
this
�� 
.
�� 
Close
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� ۡ
TC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Match.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
Match 
:  
Window! '
,' ($
IMatchManagementCallback) A
,A B!
IChatServicesCallbackC X
,X Y&
IDrawReviewServiceCallbackZ t
{ 
DispatcherTimer   
timer   
=   
new    #
DispatcherTimer  $ 3
(  3 4
)  4 5
;  5 6
private!! 
int!! 
selectedTime!!  
;!!  !
public## 
Match## 
(## 
)## 
{$$ 	
InitializeComponent%% 
(%%  
)%%  !
;%%! "#
SetChatOperationContext&& #
(&&# $
MainMenu&&$ ,
.&&, -
username&&- 5
)&&5 6
;&&6 7$
SetMatchOperationContext'' $
(''$ %
MainMenu''% -
.''- .
username''. 6
)''6 7
;''7 8
}(( 	
private** 
void** "
Button_SetEraser_Click** +
(**+ ,
object**, 2
sender**3 9
,**9 :
RoutedEventArgs**; J
e**K L
)**L M
{++ 	
InkCanvas_DrawTable,, 
.,,  $
DefaultDrawingAttributes,,  8
.,,8 9
Width,,9 >
=,,? @
$num,,A C
;,,C D
InkCanvas_DrawTable-- 
.--  $
DefaultDrawingAttributes--  8
.--8 9
Height--9 ?
=--@ A
$num--B D
;--D E
InkCanvas_DrawTable.. 
...  
EditingMode..  +
=.., - 
InkCanvasEditingMode... B
...B C
EraseByPoint..C O
;..O P
}// 	
private11 
void11 &
Button_SetColorGreen_Click11 /
(11/ 0
object110 6
sender117 =
,11= >
RoutedEventArgs11? N
e11O P
)11P Q
{22 	
InkCanvas_DrawTable33 
.33  
EditingMode33  +
=33, - 
InkCanvasEditingMode33. B
.33B C
Ink33C F
;33F G
InkCanvas_DrawTable44 
.44  $
DefaultDrawingAttributes44  8
.448 9
Width449 >
=44? @
$num44A B
;44B C
InkCanvas_DrawTable55 
.55  $
DefaultDrawingAttributes55  8
.558 9
Height559 ?
=55@ A
$num55B C
;55C D
InkCanvas_DrawTable66 
.66  $
DefaultDrawingAttributes66  8
.668 9
Color669 >
=66? @
Colors66A G
.66G H
Green66H M
;66M N
}77 	
private99 
void99 %
Button_SetColorBlue_Click99 .
(99. /
object99/ 5
sender996 <
,99< =
RoutedEventArgs99> M
e99N O
)99O P
{:: 	
InkCanvas_DrawTable;; 
.;;  
EditingMode;;  +
=;;, - 
InkCanvasEditingMode;;. B
.;;B C
Ink;;C F
;;;F G
InkCanvas_DrawTable<< 
.<<  $
DefaultDrawingAttributes<<  8
.<<8 9
Width<<9 >
=<<? @
$num<<A B
;<<B C
InkCanvas_DrawTable== 
.==  $
DefaultDrawingAttributes==  8
.==8 9
Height==9 ?
===@ A
$num==B C
;==C D
InkCanvas_DrawTable>> 
.>>  $
DefaultDrawingAttributes>>  8
.>>8 9
Color>>9 >
=>>? @
Colors>>A G
.>>G H
Blue>>H L
;>>L M
}?? 	
privateAA 
voidAA $
Button_SetColorRed_ClickAA -
(AA- .
objectAA. 4
senderAA5 ;
,AA; <
RoutedEventArgsAA= L
eAAM N
)AAN O
{BB 	
InkCanvas_DrawTableCC 
.CC  
EditingModeCC  +
=CC, - 
InkCanvasEditingModeCC. B
.CCB C
InkCCC F
;CCF G
InkCanvas_DrawTableDD 
.DD  $
DefaultDrawingAttributesDD  8
.DD8 9
WidthDD9 >
=DD? @
$numDDA B
;DDB C
InkCanvas_DrawTableEE 
.EE  $
DefaultDrawingAttributesEE  8
.EE8 9
HeightEE9 ?
=EE@ A
$numEEB C
;EEC D
InkCanvas_DrawTableFF 
.FF  $
DefaultDrawingAttributesFF  8
.FF8 9
ColorFF9 >
=FF? @
ColorsFFA G
.FFG H
RedFFH K
;FFK L
}GG 	
privateII 
voidII &
Button_SetColorBlack_ClickII /
(II/ 0
objectII0 6
senderII7 =
,II= >
RoutedEventArgsII? N
eIIO P
)IIP Q
{JJ 	
InkCanvas_DrawTableKK 
.KK  
EditingModeKK  +
=KK, - 
InkCanvasEditingModeKK. B
.KKB C
InkKKC F
;KKF G
InkCanvas_DrawTableLL 
.LL  $
DefaultDrawingAttributesLL  8
.LL8 9
WidthLL9 >
=LL? @
$numLLA B
;LLB C
InkCanvas_DrawTableMM 
.MM  $
DefaultDrawingAttributesMM  8
.MM8 9
HeightMM9 ?
=MM@ A
$numMMB C
;MMC D
InkCanvas_DrawTableNN 
.NN  $
DefaultDrawingAttributesNN  8
.NN8 9
ColorNN9 >
=NN? @
ColorsNNA G
.NNG H
BlackNNH M
;NNM N
}OO 	
privateQQ 
voidQQ 

ObtainCardQQ 
(QQ  
)QQ  !
{RR 	
InstanceContextSS 
instanceContextSS +
=SS, -
newSS. 1
InstanceContextSS2 A
(SSA B
thisSSB F
)SSF G
;SSG H
PassThePenServiceTT 
.TT !
MatchManagementClientTT 3
clientTT4 :
=TT; <
newTT= @
PassThePenServiceTTA R
.TTR S!
MatchManagementClientTTS h
(TTh i
instanceContextTTi x
)TTx y
;TTy z
varVV 
randomVV 
=VV 
newVV 
RandomVV #
(VV# $
)VV$ %
;VV% &
intWW 

numberCardWW 
=WW 
randomWW #
.WW# $
NextWW$ (
(WW( )
$numWW) *
,WW* +
$numWW, /
)WW/ 0
;WW0 1
ResourceManagerYY 
resourceYY $
=YY% &
newYY' *
ResourceManagerYY+ :
(YY: ;
$strYY; W
,YYW X
AssemblyYYY a
.YYa b 
GetExecutingAssemblyYYb v
(YYv w
)YYw x
)YYx y
;YYy z
stringZZ 
cardZZ 
=ZZ 
resourceZZ "
.ZZ" #
	GetStringZZ# ,
(ZZ, -
$strZZ- 3
+ZZ4 5

numberCardZZ6 @
)ZZ@ A
;ZZA B
client\\ 
.\\ 
SendCard\\ 
(\\ 
card\\  
)\\  !
;\\! "
}^^ 	
public`` 
void`` 
DistributeCard`` "
(``" #
string``# )
card``* .
)``. /
{aa 	
Label_CurrentDrawbb 
.bb 
Contentbb %
=bb& '
cardbb( ,
;bb, -
}cc 	
privateff 
voidff $
Button_SendMessage_Clickff -
(ff- .
objectff. 4
senderff5 ;
,ff; <
RoutedEventArgsff= L
effM N
)ffN O
{gg 	
InstanceContexthh 
contexthh #
=hh$ %
newhh& )
InstanceContexthh* 9
(hh9 :
thishh: >
)hh> ?
;hh? @
PassThePenServiceii 
.ii 
ChatServicesClientii 0
clientii1 7
=ii8 9
newii: =
ChatServicesClientii> P
(iiP Q
contextiiQ X
)iiX Y
;iiY Z
stringkk 
usernamekk 
=kk 
MainMenukk &
.kk& '
usernamekk' /
;kk/ 0
Stringll 
messagell 
=ll 
TextBox_Messagell ,
.ll, -
Textll- 1
;ll1 2
ifmm 
(mm 
messagemm 
!=mm 
$strmm 
)mm 
{nn 
TextBox_Messageoo 
.oo  
Clearoo  %
(oo% &
)oo& '
;oo' (
clientpp 
.pp 
SendMessagepp "
(pp" #
usernamepp# +
,pp+ ,
messagepp- 4
)pp4 5
;pp5 6
}qq 
}tt 	
publicvv 
voidvv 
MessageSendvv 
(vv  
stringvv  &
messagevv' .
)vv. /
{ww 	
ListBox_ChatBoxxx 
.xx 
Itemsxx !
.xx! "
Addxx" %
(xx% &
messagexx& -
)xx- .
;xx. /
}yy 	
private|| 
void|| "
Button_StartTurn_Click|| +
(||+ ,
object||, 2
sender||3 9
,||9 :
RoutedEventArgs||; J
e||K L
)||L M
{}} 	
InstanceContext~~ 
instanceContext~~ +
=~~, -
new~~. 1
InstanceContext~~2 A
(~~A B
this~~B F
)~~F G
;~~G H
PassThePenService 
. !
MatchManagementClient 3
client4 :
=; <
new= @!
MatchManagementClientA V
(V W
instanceContextW f
)f g
;g h
client
�� 
.
�� 
StartTurnSignal
�� "
(
��" #
MainMenu
��# +
.
��+ ,
username
��, 4
)
��4 5
;
��5 6
}
�� 	
private
�� 
void
�� 
	StartTurn
�� 
(
�� 
)
��  
{
�� 	

ObtainCard
�� 
(
�� 
)
�� 
;
�� 
ObtainTurnTime
�� 
(
�� 
)
�� 
;
�� 
StartTurnTimer
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
private
�� 
void
�� 
ObtainTurnTime
�� #
(
��# $
)
��$ %
{
�� 	
InstanceContext
�� 
context
�� #
=
��$ %
new
��& )
InstanceContext
��* 9
(
��9 :
this
��: >
)
��> ?
;
��? @
PassThePenService
�� 
.
�� #
MatchManagementClient
�� 3
client
��4 :
=
��; <
new
��= @#
MatchManagementClient
��A V
(
��V W
context
��W ^
)
��^ _
;
��_ `
client
�� 
.
�� 
SelectTurnTime
�� !
(
��! "
)
��" #
;
��# $
}
�� 	
public
�� 
void
��  
DistributeTurnTime
�� &
(
��& '
int
��' *
turnTime
��+ 3
)
��3 4
{
�� 	
selectedTime
�� 
=
�� 
turnTime
�� #
;
��# $
}
�� 	
private
�� 
void
�� 
StartTurnTimer
�� #
(
��# $
)
��$ %
{
�� 	
timer
�� 
.
�� 
Interval
�� 
=
�� 
TimeSpan
�� %
.
��% &
FromSeconds
��& 1
(
��1 2
$num
��2 3
)
��3 4
;
��4 5
timer
�� 
.
�� 
Tick
�� 
+=
�� 

Timer_Tick
�� $
;
��$ %
timer
�� 
.
�� 
Start
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
private
�� 
void
�� 

Timer_Tick
�� 
(
��  
object
��  &
sender
��' -
,
��- .
	EventArgs
��/ 8
e
��9 :
)
��: ;
{
�� 	
if
�� 
(
�� 
selectedTime
�� 
==
�� 
$num
��  !
)
��! "
{
�� 
timer
�� 
.
�� 
Stop
�� 
(
�� 
)
�� 
;
�� 
SendDraw
�� 
(
�� 
)
�� 
;
�� 
}
�� !
Label_TimeRemaining
�� 
.
��  
Content
��  '
=
��( )
selectedTime
��* 6
;
��6 7
selectedTime
�� 
--
�� 
;
�� 
}
�� 	
public
�� 
void
�� #
ReturnStartTurnSignal
�� )
(
��) *
int
��* -

turnNumber
��. 8
)
��8 9
{
�� 	
Label_TurnNumber
�� 
.
�� 
Content
�� $
=
��% &

turnNumber
��' 1
;
��1 2
	StartTurn
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
private
�� 
byte
�� 
[
�� 
]
�� 
GetCanvasDraw
�� $
(
��$ %
)
��% &
{
�� 	
int
�� 
margin
�� 
=
�� 
(
�� 
int
�� 
)
�� !
InkCanvas_DrawTable
�� 2
.
��2 3
Margin
��3 9
.
��9 :
Right
��: ?
;
��? @
int
�� 
width
�� 
=
�� 
(
�� 
int
�� 
)
�� !
InkCanvas_DrawTable
�� 1
.
��1 2
ActualWidth
��2 =
-
��> ?
margin
��@ F
;
��F G
int
�� 
height
�� 
=
�� 
(
�� 
int
�� 
)
�� !
InkCanvas_DrawTable
�� 2
.
��2 3
ActualHeight
��3 ?
-
��@ A
margin
��B H
;
��H I 
RenderTargetBitmap
�� 
rtb
�� "
=
��# $
new
��% ( 
RenderTargetBitmap
��) ;
(
��; <
width
��< A
,
��A B
height
��C I
,
��I J
$num
��K N
,
��N O
$num
��P S
,
��S T
PixelFormats
��U a
.
��a b
Default
��b i
)
��i j
;
��j k
rtb
�� 
.
�� 
Render
�� 
(
�� !
InkCanvas_DrawTable
�� *
)
��* +
;
��+ ,
BmpBitmapEncoder
�� 
encoder
�� $
=
��% &
new
��' *
BmpBitmapEncoder
��+ ;
(
��; <
)
��< =
;
��= >
encoder
�� 
.
�� 
Frames
�� 
.
�� 
Add
�� 
(
�� 
BitmapFrame
�� *
.
��* +
Create
��+ 1
(
��1 2
rtb
��2 5
)
��5 6
)
��6 7
;
��7 8
byte
�� 
[
�� 
]
�� 
bitmapBytes
�� 
;
�� 
using
�� 
(
�� 
MemoryStream
�� 
ms
��  "
=
��# $
new
��% (
MemoryStream
��) 5
(
��5 6
)
��6 7
)
��7 8
{
�� 
encoder
�� 
.
�� 
Save
�� 
(
�� 
ms
�� 
)
��  
;
��  !
ms
�� 
.
�� 
Position
�� 
=
�� 
$num
�� 
;
��  
bitmapBytes
�� 
=
�� 
ms
��  
.
��  !
ToArray
��! (
(
��( )
)
��) *
;
��* +
}
�� 
return
�� 
bitmapBytes
�� 
;
�� 
}
�� 	
public
�� 
BitmapImage
��  
ConvertByteToImage
�� -
(
��- .
byte
��. 2
[
��2 3
]
��3 4
array
��5 :
)
��: ;
{
�� 	
using
�� 
(
�� 
var
�� 
ms
�� 
=
�� 
new
�� 
System
��  &
.
��& '
IO
��' )
.
��) *
MemoryStream
��* 6
(
��6 7
array
��7 <
)
��< =
)
��= >
{
�� 
var
�� 
image
�� 
=
�� 
new
�� 
BitmapImage
��  +
(
��+ ,
)
��, -
;
��- .
image
�� 
.
�� 
	BeginInit
�� 
(
��  
)
��  !
;
��! "
image
�� 
.
�� 
CacheOption
�� !
=
��" #
BitmapCacheOption
��$ 5
.
��5 6
OnLoad
��6 <
;
��< =
image
�� 
.
�� 
StreamSource
�� "
=
��# $
ms
��% '
;
��' (
image
�� 
.
�� 
EndInit
�� 
(
�� 
)
�� 
;
��  
return
�� 
image
�� 
;
�� 
}
�� 
}
�� 	
private
�� 
void
�� 
SendDraw
�� 
(
�� 
)
�� 
{
�� 	
InstanceContext
�� 
context
�� #
=
��$ %
new
��& )
InstanceContext
��* 9
(
��9 :
this
��: >
)
��> ?
;
��? @
PassThePenService
�� 
.
�� %
DrawReviewServiceClient
�� 5
client
��6 <
=
��= >
new
��? B%
DrawReviewServiceClient
��C Z
(
��Z [
context
��[ b
)
��b c
;
��c d
Byte
�� 
[
�� 
]
�� 

playerDraw
�� 
=
�� 
GetCanvasDraw
��  -
(
��- .
)
��. /
;
��/ 0
client
�� 
.
�� 
	SendDraws
�� 
(
�� 

playerDraw
�� '
)
��' (
;
��( )
}
�� 	
public
�� 
void
�� 
DistributeDraws
�� #
(
��# $
byte
��$ (
[
��( )
]
��) *
draw
��+ /
)
��/ 0
{
�� 	

DrawReview
�� 
.
�� 
bytes
�� 
=
�� 
draw
�� #
;
��# $

DrawReview
�� 

drawReview
�� !
=
��" #
new
��$ '

DrawReview
��( 2
(
��2 3
)
��3 4
;
��4 5

drawReview
�� 
.
�� 
Show
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
public
�� 
void
�� %
SetChatOperationContext
�� +
(
��+ ,
string
��, 2
username
��3 ;
)
��; <
{
�� 	
InstanceContext
�� 
instanceContext
�� +
=
��, -
new
��. 1
InstanceContext
��2 A
(
��A B
this
��B F
)
��F G
;
��G H
PassThePenService
�� 
.
��  
ChatServicesClient
�� 0
client
��1 7
=
��8 9
new
��: =
PassThePenService
��> O
.
��O P 
ChatServicesClient
��P b
(
��b c
instanceContext
��c r
)
��r s
;
��s t
client
�� 
.
�� %
SetChatOperationContext
�� *
(
��* +
username
��+ 3
)
��3 4
;
��4 5
}
�� 	
public
�� 
void
�� &
SetMatchOperationContext
�� ,
(
��, -
string
��- 3
username
��4 <
)
��< =
{
�� 	
InstanceContext
�� 
instanceContext
�� +
=
��, -
new
��. 1
InstanceContext
��2 A
(
��A B
this
��B F
)
��F G
;
��G H
PassThePenService
�� 
.
�� #
MatchManagementClient
�� 3
client
��4 :
=
��; <
new
��= @
PassThePenService
��A R
.
��R S#
MatchManagementClient
��S h
(
��h i
instanceContext
��i x
)
��x y
;
��y z
client
�� 
.
�� &
SetMatchOperationContext
�� +
(
��+ ,
username
��, 4
)
��4 5
;
��5 6
}
�� 	
public
�� 
void
�� 
DistributeDraws
�� #
(
��# $
byte
��$ (
[
��( )
]
��) *
[
��* +
]
��+ ,
playersDraws
��- 9
)
��9 :
{
�� 	
throw
�� 
new
�� %
NotImplementedException
�� -
(
��- .
)
��. /
;
��/ 0
}
�� 	
}
�� 
}�� �X
VC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Profile.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
Profile  
:! "
Window# )
{ 
public 
Profile 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
SetDataPlayer 
( 
) 
; 
ValidateGuestUser 
( 
) 
;  
} 	
private   
void   +
Button_SaveProfileChanges_Click   4
(  4 5
object  5 ;
sender  < B
,  B C
RoutedEventArgs  D S
e  T U
)  U V
{!! 	"
PlayerManagementClient"" "
client""# )
=""* +
new"", /"
PlayerManagementClient""0 F
(""F G
)""G H
;""H I
if## 
(## 
ValidateInformation## #
(### $
)##$ %
)##% &
{$$ 
Byte%% 
[%% 
]%% 
image%% 
=%% 
ImageToByte%% *
(%%* +
Image_ProfileImage%%+ =
.%%= >
Source%%> D
as%%E G
BitmapImage%%H S
)%%S T
;%%T U
Player&& 
player&& 
=&& 
new&&  #
Player&&$ *
(&&* +
)&&+ ,
{'' 
username(( 
=(( 
TextBox_Username(( /
.((/ 0
Text((0 4
,((4 5
name)) 
=)) 
TextBox_Name)) '
.))' (
Text))( ,
,)), -
lastname** 
=** 
TextBox_Lastname** /
.**/ 0
Text**0 4
,**4 5
email++ 
=++ 
TextBox_Email++ )
.++) *
Text++* .
,++. /
profileImage,,  
=,,! "
image,,# (
}-- 
;-- 
if// 
(// 
client// 
.// 
UpdateDataPlayer// +
(//+ ,
MainMenu//, 4
.//4 5
username//5 =
,//= >
player//? E
)//E F
==//G I
$num//J M
)//M N
{00 

MessageBox11 
.11 
Show11 #
(11# $
$str11$ B
)11B C
;11C D
}22 
else33 
{44 

MessageBox55 
.55 
Show55 #
(55# $
$str55$ E
)55E F
;55F G
}66 
}77 
client88 
.88 
Close88 
(88 
)88 
;88 
}99 	
private<< 
void<< 
SetDataPlayer<< "
(<<" #
)<<# $
{== 	
PassThePenService>> 
.>> "
PlayerManagementClient>> 4
client>>5 ;
=>>< =
new>>> A
PassThePenService>>B S
.>>S T"
PlayerManagementClient>>T j
(>>j k
)>>k l
;>>l m
Player?? 
playerObtained?? !
=??" #
client??$ *
.??* +
GetDataPlayer??+ 8
(??8 9
MainMenu??9 A
.??A B
username??B J
)??J K
;??K L
if@@ 
(@@ 
playerObtained@@ 
!=@@ !
null@@" &
)@@& '
{AA 
TextBox_UsernameBB  
.BB  !
TextBB! %
=BB& '
playerObtainedBB( 6
.BB6 7
usernameBB7 ?
;BB? @
TextBox_NameCC 
.CC 
TextCC !
=CC" #
playerObtainedCC$ 2
.CC2 3
nameCC3 7
;CC7 8
TextBox_LastnameDD  
.DD  !
TextDD! %
=DD& '
playerObtainedDD( 6
.DD6 7
lastnameDD7 ?
;DD? @
TextBox_EmailEE 
.EE 
TextEE "
=EE# $
playerObtainedEE% 3
.EE3 4
emailEE4 9
;EE9 :
Image_ProfileImageFF "
.FF" #
SourceFF# )
=FF* +
ImageManagerFF, 8
.FF8 9
ToImageFF9 @
(FF@ A
playerObtainedFFA O
.FFO P
profileImageFFP \
)FF\ ]
;FF] ^
}GG 
clientHH 
.HH 
CloseHH 
(HH 
)HH 
;HH 
}II 	
privateLL 
BooleanLL 
ValidateInformationLL +
(LL+ ,
)LL, -
{MM 	
InvalidFields_LabelNN 
.NN  

VisibilityNN  *
=NN+ ,

VisibilityNN- 7
.NN7 8
HiddenNN8 >
;NN> ?
BooleanOO 
isValidOO 
=OO 
trueOO "
;OO" #
ifPP 
(PP 
TextBox_EmailPP 
.PP 
TextPP "
.PP" #
EqualsPP# )
(PP) *
$strPP* ,
)PP, -
||PP. 0
TextBox_NamePP1 =
.PP= >
TextPP> B
.PPB C
EqualsPPC I
(PPI J
$strPPJ L
)PPL M
||PPN P
TextBox_LastnamePPQ a
.PPa b
TextPPb f
.PPf g
EqualsPPg m
(PPm n
$strPPn p
)PPp q
)PPq r
{QQ 
InvalidFields_LabelRR #
.RR# $

VisibilityRR$ .
=RR/ 0

VisibilityRR1 ;
.RR; <
VisibleRR< C
;RRC D
isValidSS 
=SS 
falseSS 
;SS  
}TT 
ifXX 
(XX 
!XX 

ValidationXX 
.XX 
ValidateFormatXX *
(XX* +
TextBox_EmailXX+ 8
.XX8 9
TextXX9 =
,XX= >
$strXX? _
)XX_ `
)XX` a
{YY 
InvalidFields_LabelZZ #
.ZZ# $

VisibilityZZ$ .
=ZZ/ 0

VisibilityZZ1 ;
.ZZ; <
VisibleZZ< C
;ZZC D
isValid[[ 
=[[ 
false[[ 
;[[  
}\\ 
if^^ 
(^^ 
TextBox_Email^^ 
.^^ 
Text^^ "
.^^" #
Length^^# )
>^^* +
$num^^, /
||^^0 2
TextBox_Name^^3 ?
.^^? @
Text^^@ D
.^^D E
Length^^E K
>^^L M
$num^^N P
||^^Q S
TextBox_Lastname^^T d
.^^d e
Text^^e i
.^^i j
Length^^j p
>^^q r
$num^^s u
)^^u v
{__ 
isValid`` 
=`` 
false`` 
;``  
}aa 
returncc 
isValidcc 
;cc 
}dd 	
privategg 
voidgg 
Button_Cancel_Clickgg (
(gg( )
objectgg) /
sendergg0 6
,gg6 7
RoutedEventArgsgg8 G
eggH I
)ggI J
{hh 	
Closeii 
(ii 
)ii 
;ii 
}jj 	
privatemm 
voidmm '
Button_ChangePassword_Clickmm 0
(mm0 1
objectmm1 7
sendermm8 >
,mm> ?
RoutedEventArgsmm@ O
emmP Q
)mmQ R
{nn 	
ChangePasswordoo  
changePasswordWindowoo /
=oo0 1
newoo2 5
ChangePasswordoo6 D
(ooD E
)ooE F
;ooF G 
changePasswordWindowpp  
.pp  !
Showpp! %
(pp% &
)pp& '
;pp' (
}qq 	
privatett 
voidtt %
Button_Select_Image_Clicktt .
(tt. /
objecttt/ 5
sendertt6 <
,tt< =
RoutedEventArgstt> M
ettN O
)ttO P
{uu 	
OpenFileDialogvv 
openFileDialogvv )
=vv* +
newvv, /
OpenFileDialogvv0 >
(vv> ?
)vv? @
;vv@ A
openFileDialogww 
.ww 
Titleww  
=ww! "
$strww# ;
;ww; <
openFileDialogxx 
.xx 
Filterxx !
=xx" #
$strxx$ V
;xxV W
ifyy 
(yy 
openFileDialogyy 
.yy 

ShowDialogyy )
(yy) *
)yy* +
==yy, .
trueyy/ 3
)yy3 4
{zz 
BitmapImage{{ 
image{{ !
={{" #
new{{$ '
BitmapImage{{( 3
({{3 4
new{{4 7
Uri{{8 ;
({{; <
openFileDialog{{< J
.{{J K
FileName{{K S
){{S T
){{T U
;{{U V
Image_ProfileImage|| "
.||" #
Source||# )
=||* +
image||, 1
;||1 2
}}} 
}~~ 	
private
�� 
void
�� 
ValidateGuestUser
�� &
(
��& '
)
��' (
{
�� 	
if
�� 
(
�� 
MainMenu
�� 
.
�� 
username
�� !
.
��! "
Equals
��" (
(
��( )
$str
��) 0
)
��0 1
)
��1 2
{
�� '
Button_SelectProfileImage
�� )
.
��) *
	IsEnabled
��* 3
=
��4 5
false
��6 ;
;
��; <
TextBox_Name
�� 
.
�� 
	IsEnabled
�� &
=
��' (
false
��) .
;
��. /
TextBox_Lastname
��  
.
��  !
	IsEnabled
��! *
=
��+ ,
false
��- 2
;
��2 3
TextBox_Email
�� 
.
�� 
	IsEnabled
�� '
=
��( )
false
��* /
;
��/ 0#
Button_ChangePassword
�� %
.
��% &
	IsEnabled
��& /
=
��0 1
false
��2 7
;
��7 8 
Button_SaveChanges
�� "
.
��" #
	IsEnabled
��# ,
=
��- .
false
��/ 4
;
��4 5
}
�� 
}
�� 	
public
�� 
static
�� 
byte
�� 
[
�� 
]
�� 
ImageToByte
�� (
(
��( )
BitmapImage
��) 4
imageSource
��5 @
)
��@ A
{
�� 	
byte
�� 
[
�� 
]
�� 
data
�� 
;
�� 
JpegBitmapEncoder
�� 
encoder
�� %
=
��& '
new
��( +
JpegBitmapEncoder
��, =
(
��= >
)
��> ?
;
��? @
encoder
�� 
.
�� 
Frames
�� 
.
�� 
Add
�� 
(
�� 
BitmapFrame
�� *
.
��* +
Create
��+ 1
(
��1 2
imageSource
��2 =
)
��= >
)
��> ?
;
��? @
using
�� 
(
�� 
MemoryStream
�� 
ms
��  "
=
��# $
new
��% (
MemoryStream
��) 5
(
��5 6
)
��6 7
)
��7 8
{
�� 
encoder
�� 
.
�� 
Save
�� 
(
�� 
ms
�� 
)
��  
;
��  !
data
�� 
=
�� 
ms
�� 
.
�� 
ToArray
�� !
(
��! "
)
��" #
;
��# $
}
�� 
return
�� 
data
�� 
;
�� 
}
�� 	
}
�� 
}�� �V
^C:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\RecoverPassword.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
RecoverPassword (
:) *
Window+ 1
{ 
private 
int 
validationCode "
;" #
private 
String 
email 
; 
public 
RecoverPassword 
( 
)  
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
private 
void 
Button_Send_Click &
(& '
object' -
sender. 4
,4 5
RoutedEventArgs6 E
eF G
)G H
{ 	
PassThePenService 
. 
AutenticationClient 1
client2 8
=9 :
new; >
PassThePenService? P
.P Q
AutenticationClientQ d
(d e
)e f
;f g
email 
= 
TexBox_EmailCode $
.$ %
Text% )
;) *
if   
(   
ValidateFormat   
(   
email   $
,  $ %
$str  & F
)  F G
&&  I K
TexBox_EmailCode  L \
.  \ ]
Text  ] a
.  a b
Length  b h
<=  i k
$num  l o
&&  p r
client  s y
.  y z
AutenticateEmail	  z �
(
  � �
email
  � �
)
  � �
==
  � �
$num
  � �
)
  � �
{!! 
Random"" 
randomNumber"" #
=""$ %
new""& )
Random""* 0
(""0 1
)""1 2
;""2 3
validationCode## 
=##  
randomNumber##! -
.##- .
Next##. 2
(##2 3
$num##3 9
,##9 :
$num##; B
)##B C
;##C D
String$$ 
affair$$ 
=$$ 
$str$$  1
;$$1 2
try%% 
{&& 
if'' 
('' 
client'' 
.'' 
	CodeEmail'' (
(''( )
email'') .
,''. /
affair''0 6
,''6 7
validationCode''8 F
)''F G
==''H J
$num''K N
)''N O
{(( 

MessageBox)) "
.))" #
Show))# '
())' (
$str))( P
)))P Q
;))Q R
Label_Email** #
.**# $

Visibility**$ .
=**/ 0

Visibility**1 ;
.**; <
Hidden**< B
;**B C

Label_Code++ "
.++" #

Visibility++# -
=++. /

Visibility++0 :
.++: ;
Visible++; B
;++B C
Button_Valid,, $
.,,$ %

Visibility,,% /
=,,0 1

Visibility,,2 <
.,,< =
Visible,,= D
;,,D E
Button_Send-- #
.--# $

Visibility--$ .
=--/ 0

Visibility--1 ;
.--; <
Hidden--< B
;--B C
TexBox_EmailCode.. (
...( )
Text..) -
=... /
$str..0 2
;..2 3
}00 
else11 
{22 

MessageBox33 "
.33" #
Show33# '
(33' (
$str33( E
)33E F
;33F G
}44 
}55 
catch66 
(66 
TimeoutException66 '
)66' (
{77 

MessageBox88 
.88 
Show88 #
(88# $
$str88$ \
)88\ ]
;88] ^
}99 
}:: 
else;; 
{<< 

MessageBox== 
.== 
Show== 
(==  
$str==  0
)==0 1
;==1 2
}>> 
client?? 
.?? 
Close?? 
(?? 
)?? 
;?? 
}@@ 	
privateBB 
voidBB 
Button_Cancel_ClickBB (
(BB( )
objectBB) /
senderBB0 6
,BB6 7
RoutedEventArgsBB8 G
eBBH I
)BBI J
{CC 	
LoginDD 
loginDD 
=DD 
newDD 
LoginDD #
(DD# $
)DD$ %
;DD% &
loginEE 
.EE 
ShowEE 
(EE 
)EE 
;EE 
CloseFF 
(FF 
)FF 
;FF 
}GG 	
privateII 
voidII 
Button_Valid_ClickII '
(II' (
objectII( .
senderII/ 5
,II5 6
RoutedEventArgsII7 F
eIIG H
)IIH I
{JJ 	
ifKK 
(KK 
Int32KK 
.KK 
ParseKK 
(KK 
TexBox_EmailCodeKK ,
.KK, -
TextKK- 1
)KK1 2
==KK3 5
validationCodeKK6 D
)KKD E
{LL 
Label_EmailMM 
.MM 

VisibilityMM &
=MM' (

VisibilityMM) 3
.MM3 4
	CollapsedMM4 =
;MM= >

Label_CodeNN 
.NN 

VisibilityNN %
=NN& '

VisibilityNN( 2
.NN2 3
	CollapsedNN3 <
;NN< =
TexBox_EmailCodeOO  
.OO  !

VisibilityOO! +
=OO, -

VisibilityOO. 8
.OO8 9
	CollapsedOO9 B
;OOB C
Panel_EmailPP 
.PP 

VisibilityPP &
=PP' (

VisibilityPP) 3
.PP3 4
	CollapsedPP4 =
;PP= >
Label_NewPasswordQQ !
.QQ! "

VisibilityQQ" ,
=QQ- .

VisibilityQQ/ 9
.QQ9 :
VisibleQQ: A
;QQA B
Label_RepitPasswordRR #
.RR# $

VisibilityRR$ .
=RR/ 0

VisibilityRR1 ;
.RR; <
VisibleRR< C
;RRC D#
PasswordBox_NewPasswordSS '
.SS' (

VisibilitySS( 2
=SS3 4

VisibilitySS5 ?
.SS? @
VisibleSS@ G
;SSG H%
PasswordBox_RepitPasswordTT )
.TT) *

VisibilityTT* 4
=TT5 6

VisibilityTT7 A
.TTA B
VisibleTTB I
;TTI J
Panel_PasswordUU 
.UU 

VisibilityUU )
=UU* +

VisibilityUU, 6
.UU6 7
VisibleUU7 >
;UU> ?
}VV 
elseWW 
{XX 

MessageBoxYY 
.YY 
ShowYY 
(YY  
$strYY  3
)YY3 4
;YY4 5
}ZZ 
}[[ 	
public]] 
Boolean]] 
ValidateFormat]] %
(]]% &
String]]& ,
text]]- 1
,]]1 2
string]]3 9
	expresion]]: C
)]]C D
{^^ 	
Boolean__ 
result__ 
;__ 
if`` 
(`` 
Regex`` 
.`` 
IsMatch`` 
(`` 
text`` "
,``" #
	expresion``$ -
)``- .
)``. /
{aa 
ifbb 
(bb 
Regexbb 
.bb 
Replacebb !
(bb! "
textbb" &
,bb& '
	expresionbb( 1
,bb1 2
Stringbb3 9
.bb9 :
Emptybb: ?
)bb? @
.bb@ A
LengthbbA G
==bbH J
$numbbK L
)bbL M
{cc 
resultdd 
=dd 
truedd !
;dd! "
}ee 
elseff 
{gg 
resulthh 
=hh 
falsehh "
;hh" #
}ii 
}jj 
elsekk 
{ll 
resultmm 
=mm 
falsemm 
;mm 
}nn 
returnoo 
resultoo 
;oo 
}pp 	
privatett 
voidtt 
Button_change_Clicktt (
(tt( )
objecttt) /
sendertt0 6
,tt6 7
RoutedEventArgstt8 G
ettH I
)ttI J
{uu 	
PassThePenServicevv 
.vv "
PlayerManagementClientvv 4
clientvv5 ;
=vv< =
newvv> A
PassThePenServicevvB S
.vvS T"
PlayerManagementClientvvT j
(vvj k
)vvk l
;vvl m
ifww 
(ww 
ValidatePasswordww  
(ww  !
)ww! "
)ww" #
{xx 
ifyy 
(yy 
clientyy 
.yy 
UpdatePasswordyy )
(yy) *
emailyy* /
,yy/ 0#
PasswordBox_NewPasswordyy1 H
.yyH I
PasswordyyI Q
)yyQ R
==yyS U
$numyyV Y
)yyY Z
{zz 

MessageBox{{ 
.{{ 
Show{{ #
({{# $
$str{{$ N
){{N O
;{{O P
Close|| 
(|| 
)|| 
;|| 
}}} 
else~~ 
{ 

MessageBox
�� 
.
�� 
Show
�� #
(
��# $
$str
��$ H
)
��H I
;
��I J
}
�� 
}
�� 
else
�� 
{
�� 

MessageBox
�� 
.
�� 
Show
�� 
(
��  
$str
��  P
)
��P Q
;
��Q R
}
�� 
client
�� 
.
�� 
Close
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
private
�� 
Boolean
�� 
ValidatePassword
�� )
(
��) *
)
��* +
{
�� 	
Boolean
�� 
result
�� 
=
�� 
true
�� !
;
��! "
if
�� 
(
�� %
PasswordBox_NewPassword
�� '
.
��' (
Password
��( 0
.
��0 1
Equals
��1 7
(
��7 8
$str
��8 :
)
��: ;
||
��< >'
PasswordBox_RepitPassword
��? X
.
��X Y
Password
��Y a
.
��a b
Equals
��b h
(
��h i
$str
��i k
)
��k l
)
��l m
{
�� 
result
�� 
=
�� 
false
�� 
;
�� 
}
�� 
if
�� 
(
�� 
!
�� %
PasswordBox_NewPassword
�� )
.
��) *
Password
��* 2
.
��2 3
Equals
��3 9
(
��9 :'
PasswordBox_RepitPassword
��: S
.
��S T
Password
��T \
)
��\ ]
)
��] ^
{
�� 
result
�� 
=
�� 
false
�� 
;
�� 
}
�� 
if
�� 
(
�� 
!
�� 
ValidateFormat
��  
(
��  !%
PasswordBox_NewPassword
��! 8
.
��8 9
Password
��9 A
,
��A B
$str��C �
)��� �
)��� �
{
�� 
result
�� 
=
�� 
false
�� 
;
�� 
}
�� 
return
�� 
result
�� 
;
�� 
}
�� 	
}
�� 
}�� �H
WC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Register.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
Register !
:" #
Window$ *
{ 
public 
Register 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! " 
Image_RegisterPlayer  
.  !
Source! '
=( )
new* -
BitmapImage. 9
(9 :
new: =
Uri> A
(A B
$strB |
)| }
)} ~
;~ 
} 	
private   
void   !
Button_Register_Click   *
(  * +
object  + 1
sender  2 8
,  8 9
RoutedEventArgs  : I
e  J K
)  K L
{!! 	
PassThePenService"" 
."" "
PlayerManagementClient"" 4
client""5 ;
=""< =
new""> A
PassThePenService""B S
.""S T"
PlayerManagementClient""T j
(""j k
)""k l
;""l m
string$$ 
password$$ 
=$$  
PasswordBox_Password$$ 2
.$$2 3
Password$$3 ;
;$$; <
string%% 
repeatedPassword%% #
=%%$ %&
PasswordBox_RepeatPassword%%& @
.%%@ A
Password%%A I
;%%I J
byte&& 
[&& 
]&& 
defaultProfileImage&& &
=&&' (
ImageToByte&&) 4
(&&4 5 
Image_RegisterPlayer&&5 I
.&&I J
Source&&J P
as&&Q S
BitmapImage&&T _
)&&_ `
;&&` a
int(( 

statusCode(( 
;(( 
int)) 
statusOK)) 
=)) 
$num)) 
;)) 
if++ 
(++ 
password++ 
.++ 
Equals++ 
(++  
repeatedPassword++  0
)++0 1
&&++2 4
ValidateFields++5 C
(++C D
TexBox_Email++D P
.++P Q
Text++Q U
,++U V
password++W _
)++_ `
)++` a
{,, 
Player-- 
	newPlayer--  
=--! "
new--# &
Player--' -
(--- .
)--. /
{.. 
email// 
=// 
TexBox_Email// (
.//( )
Text//) -
,//- .
username00 
=00 
TextBox_Username00 /
.00/ 0
Text000 4
,004 5
name11 
=11 
TextBox_Name11 '
.11' (
Text11( ,
,11, -
lastname22 
=22 
TextBox_LastName22 /
.22/ 0
Text220 4
,224 5
password33 
=33  
PasswordBox_Password33 3
.333 4
Password334 <
,33< =
profileImage44  
=44! "
defaultProfileImage44# 6
}55 
;55 

statusCode77 
=77 
client77 #
.77# $
	AddPlayer77$ -
(77- .
	newPlayer77. 7
)777 8
;778 9
if88 
(88 

statusCode88 
==88 !
statusOK88" *
)88* +
{99 

MessageBox:: 
.:: 
Show:: #
(::# $
$str::$ H
)::H I
;::I J
Login;; 
login;; 
=;;  !
new;;" %
Login;;& +
(;;+ ,
);;, -
;;;- .
login<< 
.<< 
Show<< 
(<< 
)<<  
;<<  !
Close== 
(== 
)== 
;== 
}>> 
else?? 
{@@ 

MessageBoxAA 
.AA 
ShowAA #
(AA# $
$strAA$ a
)AAa b
;AAb c
}BB 
}CC 
elseDD 
{EE 

MessageBoxFF 
.FF 
ShowFF 
(FF  
$strFF  H
)FFH I
;FFI J
}GG 
clientHH 
.HH 
CloseHH 
(HH 
)HH 
;HH 
}II 	
privateKK 
boolKK 
ValidateFieldsKK #
(KK# $
stringKK$ *
emailKK+ 0
,KK0 1
stringKK2 8
passwordKK9 A
)KKA B
{LL 	
boolMM 
resultMM 
=MM 
trueMM 
;MM 
ifNN 
(NN 
stringNN 
.NN 
IsNullOrEmptyNN $
(NN$ %
TextBox_NameNN% 1
.NN1 2
TextNN2 6
)NN6 7
||NN8 :
stringNN; A
.NNA B
IsNullOrEmptyNNB O
(NNO P
TextBox_LastNameNNP `
.NN` a
TextNNa e
)NNe f
)NNf g
{OO 
resultPP 
=PP 
falsePP 
;PP 
}QQ 
ifRR 
(RR 
stringRR 
.RR 
IsNullOrEmptyRR $
(RR$ %
TextBox_UsernameRR% 5
.RR5 6
TextRR6 :
)RR: ;
||RR< >
stringRR? E
.RRE F
IsNullOrEmptyRRF S
(RRS T
TexBox_EmailRRT `
.RR` a
TextRRa e
)RRe f
)RRf g
{SS 
resultTT 
=TT 
falseTT 
;TT 
}UU 
ifVV 
(VV 
!VV 

ValidationVV 
.VV 
ValidateFormatVV *
(VV* +
emailVV+ 0
,VV0 1
$strVV2 R
)VVR S
)VVS T
{WW 
resultXX 
=XX 
falseXX 
;XX 
}YY 
ifZZ 
(ZZ 
!ZZ 

ValidationZZ 
.ZZ 
ValidateFormatZZ *
(ZZ* +
passwordZZ+ 3
,ZZ3 4
$str	ZZ5 �
)
ZZ� �
)
ZZ� �
{[[ 
result\\ 
=\\ 
false\\ 
;\\ 
}]] 
if^^ 
(^^ 
!^^ 
ValidateLength^^ 
(^^  
)^^  !
)^^! "
{__ 
result`` 
=`` 
false`` 
;`` 
}aa 
returnbb 
resultbb 
;bb 
}cc 	
privateee 
boolee 
ValidateLengthee #
(ee# $
)ee$ %
{ff 	
boolgg 
resultgg 
=gg 
truegg 
;gg 
ifhh 
(hh 
TextBox_Usernamehh  
.hh  !
Texthh! %
.hh% &
Lengthhh& ,
>hh- .
$numhh/ 1
||hh2 4
TextBox_Namehh5 A
.hhA B
TexthhB F
.hhF G
LengthhhG M
>hhN O
$numhhP R
)hhR S
{ii 
resultjj 
=jj 
falsejj 
;jj 
}kk 
ifll 
(ll 
TextBox_LastNamell  
.ll  !
Textll! %
.ll% &
Lengthll& ,
>ll- .
$numll/ 1
||ll2 4
TexBox_Emailll5 A
.llA B
TextllB F
.llF G
LengthllG M
>llN O
$numllP S
)llS T
{mm 
resultnn 
=nn 
falsenn 
;nn 
}oo 
returnpp 
resultpp 
;pp 
}qq 	
privatett 
voidtt 
Button_Exit_Clicktt &
(tt& '
objecttt' -
sendertt. 4
,tt4 5
RoutedEventArgstt6 E
ettF G
)ttG H
{uu 	
Loginvv 
loginvv 
=vv 
newvv 
Loginvv #
(vv# $
)vv$ %
;vv% &
loginww 
.ww 
Showww 
(ww 
)ww 
;ww 
Closexx 
(xx 
)xx 
;xx 
}yy 	
public{{ 
byte{{ 
[{{ 
]{{ 
ImageToByte{{ !
({{! "
BitmapImage{{" -
imageSource{{. 9
){{9 :
{|| 	
byte}} 
[}} 
]}} 
data}} 
;}} 
JpegBitmapEncoder~~ 
encoder~~ %
=~~& '
new~~( +
JpegBitmapEncoder~~, =
(~~= >
)~~> ?
;~~? @
encoder 
. 
Frames 
. 
Add 
( 
BitmapFrame *
.* +
Create+ 1
(1 2
imageSource2 =
)= >
)> ?
;? @
using
�� 
(
�� 
MemoryStream
�� 
ms
��  "
=
��# $
new
��% (
MemoryStream
��) 5
(
��5 6
)
��6 7
)
��7 8
{
�� 
encoder
�� 
.
�� 
Save
�� 
(
�� 
ms
�� 
)
��  
;
��  !
data
�� 
=
�� 
ms
�� 
.
�� 
ToArray
�� !
(
��! "
)
��" #
;
��# $
}
�� 
return
�� 
data
�� 
;
�� 
}
�� 	
}
�� 
}�� �
TC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Validation.cs
	namespace 	

PassThePen
 
{		 
public

 

static

 
class

 

Validation

 "
{ 
public 
static 
Boolean 
ValidateFormat ,
(, -
String- 3
text4 8
,8 9
string: @
	expresionA J
)J K
{ 	
Boolean 
result 
; 
if 
( 
Regex 
. 
IsMatch 
( 
text "
," #
	expresion$ -
)- .
). /
{ 
if 
( 
Regex 
. 
Replace !
(! "
text" &
,& '
	expresion( 1
,1 2
String3 9
.9 :
Empty: ?
)? @
.@ A
LengthA G
==H J
$numK L
)L M
{ 
result 
= 
true !
;! "
} 
else 
{ 
result 
= 
false "
;" #
} 
} 
else 
{ 
result 
= 
false 
; 
} 
return 
result 
; 
}   	
}!! 
}"" �
RC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\App.xaml.cs
	namespace		 	

PassThePen		
 
{

 
public 

partial 
class 
App 
: 
Application *
{ 
public 
App 
( 
) 
{ 	

Syncfusion 
. 
	Licensing  
.  !%
SyncfusionLicenseProvider! :
.: ;
RegisterLicense; J
(J K
$str	K �
)
� �
;
� �
} 	
} 
} �I
TC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Login.xaml.cs
	namespace 	

PassThePen
 
{ 
public 

partial 
class 
Login 
:  
Window! '
{ 
public 
Login 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
private 
void 
Button_login_Click '
(' (
object( .
sender/ 5
,5 6
RoutedEventArgs7 F
eG H
)H I
{   	
PassThePenService!! 
.!! 
AutenticationClient!! 1
client!!2 8
=!!9 :
new!!; >
PassThePenService!!? P
.!!P Q
AutenticationClient!!Q d
(!!d e
)!!e f
;!!f g
PassThePenService## 
.## 
Player## $
player##% +
=##, -
new##. 1
PassThePenService##2 C
.##C D
Player##D J
(##J K
)##K L
{$$ 
username%% 
=%% 
TextBox_Username%% +
.%%+ ,
Text%%, 0
,%%0 1
password&& 
=&& $
PasswordBox_PasswordUser&& 3
.&&3 4
Password&&4 <
}'' 
;'' 
if(( 
((( 
ValidateInformation(( #
(((# $
)(($ %
)((% &
{)) 
int** 
playerValid** 
=**  !
$num**" %
;**% &
int++ #
resultAutenticatePlayer++ +
=++, -
client++. 4
.++4 5
AutenticatePlayer++5 F
(++F G
player++G M
)++M N
;++N O
if-- 
(-- #
resultAutenticatePlayer-- +
==--, .
playerValid--/ :
)--: ;
{.. 
MainMenu// 
.// 
username// %
=//& '
TextBox_Username//( 8
.//8 9
Text//9 =
;//= >
InvokeMainMenu00 "
(00" #
)00# $
;00$ %
}22 
else33 
{44 

MessageBox55 
.55 
Show55 #
(55# $
$str55$ D
)55D E
;55E F
}66 
}77 
else88 
{99 

MessageBox:: 
.:: 
Show:: 
(::  
$str::  Z
)::Z [
;::[ \
};; 
}== 	
private?? 
bool?? 
ValidateInformation?? (
(??( )
)??) *
{@@ 	
boolAA 
resultAA 
=AA 
trueAA 
;AA 
ifBB 
(BB 
stringBB 
.BB 
IsNullOrEmptyBB $
(BB$ %
TextBox_UsernameBB% 5
.BB5 6
TextBB6 :
)BB: ;
&&BB< >
stringBB? E
.BBE F
IsNullOrEmptyBBF S
(BBS T$
PasswordBox_PasswordUserBBT l
.BBl m
PasswordBBm u
)BBu v
)BBv w
{CC 
returnDD 
falseDD 
;DD 
}EE 
ifFF 
(FF 
TextBox_UsernameFF  
.FF  !
TextFF! %
.FF% &
LengthFF& ,
>FF- .
$numFF/ 1
&&FF2 4$
PasswordBox_PasswordUserFF5 M
.FFM N
PasswordFFN V
.FFV W
LengthFFW ]
>FF^ _
$numFF` b
)FFb c
{GG 
returnHH 
falseHH 
;HH 
}II 
returnJJ 
resultJJ 
;JJ 
}KK 	
privateMM 
voidMM !
Button_Register_ClickMM *
(MM* +
objectMM+ 1
senderMM2 8
,MM8 9
RoutedEventArgsMM: I
eMMJ K
)MMK L
{NN 	
RegisterOO 
registerWindowOO #
=OO$ %
newOO& )
RegisterOO* 2
(OO2 3
)OO3 4
;OO4 5
registerWindowPP 
.PP 

ShowDialogPP %
(PP% &
)PP& '
;PP' (
CloseQQ 
(QQ 
)QQ 
;QQ 
}RR 	
privateTT 
voidTT (
Button_Forgot_Password_ClickTT 1
(TT1 2
objectTT2 8
senderTT9 ?
,TT? @
RoutedEventArgsTTA P
eTTQ R
)TTR S
{UU 	
RecoverPasswordVV 
recoverVV #
=VV$ %
newVV& )
RecoverPasswordVV* 9
(VV9 :
)VV: ;
;VV; <
recoverWW 
.WW 
ShowWW 
(WW 
)WW 
;WW 
CloseXX 
(XX 
)XX 
;XX 
}YY 	
private[[ 
void[[ 
Button_Exit_Click[[ &
([[& '
object[[' -
sender[[. 4
,[[4 5
RoutedEventArgs[[6 E
e[[F G
)[[G H
{\\ 	
Close]] 
(]] 
)]] 
;]] 
}^^ 	
private`` 
void`` 
InvokeMainMenu`` #
(``# $
)``$ %
{aa 	
MainMenubb 
mainMenubb 
=bb 
newbb  #
MainMenubb$ ,
(bb, -
)bb- .
;bb. /
mainMenucc 
.cc 
Showcc 
(cc 
)cc 
;cc 
Closedd 
(dd 
)dd 
;dd 
}ee 	
privategg 
voidgg %
Button_LoginAsGuest_Clickgg .
(gg. /
objectgg/ 5
sendergg6 <
,gg< = 
MouseButtonEventArgsgg> R
eggS T
)ggT U
{hh 	
PassThePenServiceii 
.ii 
AutenticationClientii 1
clientii2 8
=ii9 :
newii; >
PassThePenServiceii? P
.iiP Q
AutenticationClientiiQ d
(iid e
)iie f
;iif g
PassThePenServicekk 
.kk 
Playerkk $
guestPlayerkk% 0
=kk1 2
newkk3 6
PassThePenServicekk7 H
.kkH I
PlayerkkI O
(kkO P
)kkP Q
{ll 
usernamemm 
=mm 
$strmm "
,mm" #
passwordnn 
=nn 
$strnn "
}oo 
;oo 
intqq 
autenticationValidqq "
=qq# $
$numqq% (
;qq( )
intrr 
resultAutenticationrr #
=rr$ %
clientrr& ,
.rr, -
AutenticatePlayerrr- >
(rr> ?
guestPlayerrr? J
)rrJ K
;rrK L
iftt 
(tt 
resultAutenticationtt "
==tt# %
autenticationValidtt& 8
)tt8 9
{uu 
MainMenuvv 
.vv 
usernamevv !
=vv" #
$strvv$ +
;vv+ ,
InvokeMainMenuww 
(ww 
)ww  
;ww  !
}xx 
clientyy 
.yy 
Closeyy 
(yy 
)yy 
;yy 
}zz 	
private|| 
void|| )
Button_ChangeLanguageEN_Click|| 2
(||2 3
object||3 9
sender||: @
,||@ A 
MouseButtonEventArgs||B V
e||W X
)||X Y
{}} 	
Thread~~ 
.~~ 
CurrentThread~~  
.~~  !
CurrentCulture~~! /
=~~0 1
new~~2 5
CultureInfo~~6 A
(~~A B
$str~~B I
)~~I J
;~~J K
Thread 
. 
CurrentThread  
.  !
CurrentUICulture! 1
=2 3
new4 7
CultureInfo8 C
(C D
$strD K
)K L
;L M

MessageBox
�� 
.
�� 
Show
�� 
(
�� 
$str
�� Y
,
��Y Z
$str
��[ ]
,
��] ^
MessageBoxButton
��_ o
.
��o p
OK
��p r
,
��r s
MessageBoxImage��t �
.��� �
Information��� �
)��� �
;��� �
}
�� 	
private
�� 
void
�� +
Button_ChangeLanguageES_Click
�� 2
(
��2 3
object
��3 9
sender
��: @
,
��@ A"
MouseButtonEventArgs
��B V
e
��W X
)
��X Y
{
�� 	
Thread
�� 
.
�� 
CurrentThread
��  
.
��  !
CurrentCulture
��! /
=
��0 1
new
��2 5
CultureInfo
��6 A
(
��A B
$str
��B I
)
��I J
;
��J K
Thread
�� 
.
�� 
CurrentThread
��  
.
��  !
CurrentUICulture
��! 1
=
��2 3
new
��4 7
CultureInfo
��8 C
(
��C D
$str
��D K
)
��K L
;
��L M

MessageBox
�� 
.
�� 
Show
�� 
(
�� 
$str
�� ^
,
��^ _
$str
��` b
,
��b c
MessageBoxButton
��d t
.
��t u
OK
��u w
,
��w x
MessageBoxImage��y �
.��� �
Information��� �
)��� �
;��� �
}
�� 	
}
�� 
}�� �
aC:\Users\DELL\Documents\GitFlow\PassThePen\PassThePenClient\PassThePen\Properties\AssemblyInfo.cs
[

 
assembly

 	
:

	 

AssemblyTitle

 
(

 
$str

 %
)

% &
]

& '
[ 
assembly 	
:	 

AssemblyDescription 
( 
$str !
)! "
]" #
[ 
assembly 	
:	 
!
AssemblyConfiguration  
(  !
$str! #
)# $
]$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str '
)' (
]( )
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
["" 
assembly"" 	
:""	 

	ThemeInfo"" 
("" &
ResourceDictionaryLocation## 
.## 
None## #
,### $&
ResourceDictionaryLocation&& 
.&& 
SourceAssembly&& -
))) 
])) 
[66 
assembly66 	
:66	 

AssemblyVersion66 
(66 
$str66 $
)66$ %
]66% &
[77 
assembly77 	
:77	 

AssemblyFileVersion77 
(77 
$str77 (
)77( )
]77) *