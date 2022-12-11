using PassThePen.PassThePenService;
using PassThePen.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Security.Policy;
using System.Reflection;
using System.Resources;

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window, PassThePenService.IPlayerConnectionCallback
    {
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        public static string username { set; get; }
        private List<string> listUsernameStrings = new List<string>();
        private List<Friends> friendList = new List<Friends>();
        private List<FriendRequest> friendRequests = new List<FriendRequest>();

        public int NotifyMatchInvitation(string invitingPlayer)
        {
            int operationResult = 500;
            var response = MessageBox.Show(messageResource.GetString("MainMenu_InvitationBody_Message"), invitingPlayer + messageResource.GetString("MainMenu_InvitationTitle_Message"), MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (response == MessageBoxResult.Yes)
            {
                MessageBox.Show(messageResource.GetString("MainMenu_InvitationConfirmation_Message"));
                operationResult = 200;
            }
            return operationResult;
        }


        public void VisualizeButtonLeaveGroup()
        {
            Button_ExitGame.Visibility = Visibility.Collapsed;
            Button_LeaveGroup.Visibility = Visibility.Visible;
        }


        public void GetDataPlayersInGoup()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PlayerConnectionClient(instanceContext);
            List<Player> listGroupPlayers = client.GetListPlayersInGroup().ToList();
            int minimumPlayersInGroup = 2;


            if (listGroupPlayers.Count >= minimumPlayersInGroup)
            {
                listGroupPlayers = RemoveOwnerPlayerOfListPlayersInGroup(listGroupPlayers);
            }

            if (listGroupPlayers.Count == 0)
            {
                Button_LeaveGroup.Visibility = Visibility.Collapsed;
                Button_ExitGame.Visibility = Visibility.Visible;
            }

            PlacePlayersInGroup(new List<Player>());
            PlacePlayersInGroup(listGroupPlayers);
        }


        public void OpenExitHostMessage()
        {
            GetDataPlayersInGoup();
            MessageBox.Show(username, messageResource.GetString("MainMenu_LeaveHost_Message"));
        }


        public MainMenu()
        {
            InitializeComponent();
            Connected();
            GetFriends();
            listUsernameStrings.Clear();
            SetDataProfile();
        }


        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();

        }


        private void Button_FindFriends_Click(object sender, RoutedEventArgs e)
        {
            listUsernameStrings.Clear();
            if (TextBox_FindFriend.Visibility == Visibility.Collapsed && ListBox_FriendList.Visibility == Visibility.Visible)
            {
                TextBox_FindFriend.Visibility = Visibility.Visible;
                friendList.ForEach(fri => listUsernameStrings.Add(fri.friendUsername));
            }
            else if (TextBox_FindFriend.Visibility == Visibility.Collapsed && ListBox_FriendsRequests.Visibility == Visibility.Visible)
            {
                TextBox_FindFriend.Visibility = Visibility.Visible;
                friendRequests.ForEach(fri => listUsernameStrings.Add(fri.friendUsername));
            }
            else
            {
                TextBox_FindFriend.Visibility = Visibility.Collapsed;
                TextBox_FindFriend.Text = "";
            }

        }


        private void Button_ExitGame_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PlayerConnectionClient(instanceContext);
            client.Disconnect(username);
            Login login = new Login();
            login.Show();
            client.Close();
            this.Close();

        }


        private void Button_FriendRequests_Click(object sender, RoutedEventArgs e)
        {
            label_ListFriends.Visibility = Visibility.Collapsed;
            label_FriendRequests.Visibility = Visibility.Visible;
            TextBox_FindFriend.Visibility = Visibility.Collapsed;
            TextBox_FindFriend.Text = "";
            GenerateFriendRequestList();
        }


        private void Button_Friends_Click(object sender, RoutedEventArgs e)
        {
            label_FriendRequests.Visibility = Visibility.Collapsed;
            label_ListFriends.Visibility = Visibility.Visible;
            ListBox_FriendsRequests.Visibility = Visibility.Collapsed;
            ListBox_FriendList.Visibility = Visibility.Visible;
            TextBox_FindFriend.Visibility = Visibility.Collapsed;
            TextBox_FindFriend.Text = "";
            GetFriends();
        }
    

        private void Button_ConfirmRequests_Click(object sender, RoutedEventArgs e)
        {
            FriendRequest newFriendRequests = GetFriendRequestOfListboxImageButton(sender);
            FriendRequestsClient clientFriendRequest = new FriendRequestsClient();
            PlayerManagementClient clientFriends = new PlayerManagementClient();
            clientFriendRequest.AcceptFriendRequest(newFriendRequests);
            GenerateFriendRequestList();
            ListBox_FriendList.ItemsSource = clientFriends.GetFriends(username);

        }


        private void Button_DeclineRequests_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.FriendRequestsClient client = new FriendRequestsClient();
            FriendRequest newFriendRequests = GetFriendRequestOfListboxImageButton(sender);
            client.DeclineFriendRequests(newFriendRequests);
            GenerateFriendRequestList();

        }


        private FriendRequest GetFriendRequestOfListboxImageButton(object sender)
        {
            Image buttonDeleteFriend = (Image)sender;
            StackPanel parent = (StackPanel)buttonDeleteFriend.Parent;
            FriendRequest friendRequest = (FriendRequest)parent.DataContext;
            return friendRequest;
        }


        private void GenerateFriendRequestList()
        {
            ListBox_FriendList.Visibility = Visibility.Collapsed;
            ListBox_FriendsRequests.Visibility = Visibility.Visible;
            FriendRequestsClient client = new FriendRequestsClient();
            friendRequests = client.GetFriendRequestsList(username).ToList();
            ListBox_FriendsRequests.ItemsSource = friendRequests;
        }

        private void Connected()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PlayerConnectionClient(instanceContext);
            client.Connect(username);
        }


        private void GetFriends()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PlayerConnectionClient(instanceContext);
            client.SendOnlinePlayers(username);
        }


        public void RechargeFriends(Friends[] friends)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PlayerConnectionClient(instanceContext);
            List<string> playersConected = client.GetNameOnlinePlayers().ToList();
            friendList = friends.ToList();
            ListBox_FriendList.ItemsSource = friendList;
        }
        

        private void Button_StartMatch_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PassThePenService.PlayerConnectionClient(context);
            client.StartMatch(username);
        }


        private void TextBox_FindFriend_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ListBox_FriendList.Visibility == Visibility.Visible)
            {
                FilterFriendList();
            }
            else if (ListBox_FriendsRequests.Visibility == Visibility.Visible)
            {
                FilterFriendsRequests();
            }
        }


        private void FilterFriendsRequests()
        {
            if (!String.IsNullOrEmpty(TextBox_FindFriend.Text.Trim()))
            {
                List<FriendRequest> friendsEquals = new List<FriendRequest>();
                foreach (string stringUsername in listUsernameStrings)
                {

                    if (stringUsername.StartsWith(TextBox_FindFriend.Text.Trim()))
                    {
                        friendsEquals.Add(friendRequests.Find(fri => fri.friendUsername.Contains(stringUsername)));
                    }
                }
                ListBox_FriendsRequests.ItemsSource = friendsEquals;
            }
            else if (TextBox_FindFriend.Text.Trim() == "")
            {
                ListBox_FriendsRequests.ItemsSource = friendRequests;
            }
        }


        private void FilterFriendList()
        {
            if (!String.IsNullOrEmpty(TextBox_FindFriend.Text.Trim()))
            {
                List<Friends> friendsEquals = new List<Friends>();
                foreach (string stringUsername in listUsernameStrings)
                {

                    if (stringUsername.StartsWith(TextBox_FindFriend.Text.Trim()))
                    {
                        friendsEquals.Add(friendList.Find(fri => fri.friendUsername.Contains(stringUsername)));
                    }
                }
                ListBox_FriendList.ItemsSource = friendsEquals;
            }
            else if (TextBox_FindFriend.Text.Trim() == "")
            {
                ListBox_FriendList.ItemsSource = friendList;
            }
        }


        private void Button_DeleteFriend_Click(object sender, MouseButtonEventArgs e)
        {
            Image buttonDeleteFriend = (Image)sender;
            StackPanel parent = (StackPanel)buttonDeleteFriend.Parent;
            Friends friend = (Friends)parent.DataContext;
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            client.DeleteFriend(friend);
            GetFriends();
            client.Close();
        }


        private void Button_AddFriend_Click(object sender, RoutedEventArgs e)
        {
            PlayerManagementClient playerClient = new PlayerManagementClient();
            int playerExist = 200;
            int errorFriendRequest = 500;
            if (playerClient.FindPlayer(Textbox_AddFriend.Text) == playerExist)
            {
                PassThePenService.FriendRequestsClient client = new FriendRequestsClient();
                FriendRequest friendRequest = new FriendRequest()
                {
                    usernamePlayer = Textbox_AddFriend.Text,
                    friendUsername = username
                };
                if (client.SendFriendRequests(friendRequest) == errorFriendRequest)
                {

                    MessageBox.Show(messageResource.GetString("MainMenu_FriendRequestSendError_Message"));

                }
                else
                {
                    Textbox_AddFriend.Clear();
                    MessageBox.Show(messageResource.GetString("MainMenu_FriendRequestSend_Message"));
                }
                
            }
            else
            {
                MessageBox.Show(messageResource.GetString("MainMenu_PlayerNotExist_Message"));
            }

        }


        private void Button_InviteFriend_Click(object sender, MouseButtonEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient clientPlayerConection = new PassThePenService.PlayerConnectionClient(context);
            PassThePenService.AutenticationClient clientAutenticate = new PassThePenService.AutenticationClient();

            Image buttonInviteFriend = (Image)sender;
            StackPanel parent = (StackPanel)buttonInviteFriend.Parent;
            Friends friend = (Friends)parent.DataContext;
            int statusPlayerIsNotInGroup = 404;
            int playerIsConected = 200;
            int groupIsNotFull = 200;


            //Refactorizar
            if (clientAutenticate.FindPlayerIsConected(friend.friendUsername) == playerIsConected && clientPlayerConection.GroupIsNotFull() == groupIsNotFull)
            {
                if (clientPlayerConection.FindPlayerInGroup(friend.friendUsername) == statusPlayerIsNotInGroup)
                {
                    clientPlayerConection.SendMathInvitation(username, friend.friendUsername);
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("MainMenu_PlayerInGroup_Message"));
                }
            }
            else
            {
                MessageBox.Show(messageResource.GetString("MainMenu_PlayerOffline_Message"));
            }

            if (clientPlayerConection.GroupIsNotFull() != groupIsNotFull)
            {
                MessageBox.Show(messageResource.GetString("MainMenu_FullGroup_Message"));
            }
        }


        private void SetDataProfile()
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            Player playerObtained = client.GetDataPlayer(username);
            Image_ProfileImage.Source = ImageManager.ToImage(playerObtained.profileImage);
            Label_PrincipalPlayer.Content = username;
        }


        public void OpenMatchWindow()
        {
            PlacePlayersInGroup(new List<Player>());
            Match match = new Match();
            match.Show();
            this.Visibility = Visibility.Hidden;
        }


        private void PlacePlayersInGroup(List<Player> listPlayers)
        {

            
            switch (listPlayers.Count)
            {
                case 0:
                    Image_InviteFiend1.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Icon_AddUser.png"));
                    Label_PlayerAdded1.Content = null;
                    Image_InviteFiend2.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Icon_AddUser.png"));
                    Label_PlayerAdded2.Content = null;
                    Image_InviteFiend3.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Icon_AddUser.png"));
                    Label_PlayerAdded3.Content = null;
                    Image_InviteFiend4.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Icon_AddUser.png"));
                    Label_PlayerAdded4.Content = null;
                    Image_InviteFiend5.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Icon_AddUser.png"));
                    Label_PlayerAdded5.Content = null;
                    break;

                case 1:
                    Image_InviteFiend1.Source = ImageManager.ToImage(listPlayers.ElementAt(0).profileImage);
                    Label_PlayerAdded1.Content = listPlayers.ElementAt(0).username;
                    break;

                case 2:
                    Image_InviteFiend1.Source = ImageManager.ToImage(listPlayers.ElementAt(0).profileImage);
                    Label_PlayerAdded1.Content = listPlayers.ElementAt(0).username;
                    Image_InviteFiend2.Source = ImageManager.ToImage(listPlayers.ElementAt(1).profileImage);
                    Label_PlayerAdded2.Content = listPlayers.ElementAt(1).username;
                    break;

                case 3:
                    Image_InviteFiend1.Source = ImageManager.ToImage(listPlayers.ElementAt(0).profileImage);
                    Label_PlayerAdded1.Content = listPlayers.ElementAt(0).username;
                    Image_InviteFiend2.Source = ImageManager.ToImage(listPlayers.ElementAt(1).profileImage);
                    Label_PlayerAdded2.Content = listPlayers.ElementAt(1).username;
                    Image_InviteFiend3.Source = ImageManager.ToImage(listPlayers.ElementAt(2).profileImage);
                    Label_PlayerAdded3.Content = listPlayers.ElementAt(2).username;
                    break;

                case 4:
                    PlaceFourPlayersInGroup(listPlayers);
                    break;

                case 5:
                    PlaceFourPlayersInGroup(listPlayers);
                    Image_InviteFiend5.Source = ImageManager.ToImage(listPlayers.ElementAt(4).profileImage);
                    Label_PlayerAdded5.Content = listPlayers.ElementAt(4).username;
                    break;

                
            }
        }

        private void PlaceFourPlayersInGroup(List<Player> listPlayers)
        {
            Image_InviteFiend1.Source = ImageManager.ToImage(listPlayers.ElementAt(0).profileImage);
            Label_PlayerAdded1.Content = listPlayers.ElementAt(0).username;
            Image_InviteFiend2.Source = ImageManager.ToImage(listPlayers.ElementAt(1).profileImage);
            Label_PlayerAdded2.Content = listPlayers.ElementAt(1).username;
            Image_InviteFiend3.Source = ImageManager.ToImage(listPlayers.ElementAt(2).profileImage);
            Label_PlayerAdded3.Content = listPlayers.ElementAt(2).username;
            Image_InviteFiend4.Source = ImageManager.ToImage(listPlayers.ElementAt(3).profileImage);
            Label_PlayerAdded4.Content = listPlayers.ElementAt(3).username;
        }  

        private List<Player> RemoveOwnerPlayerOfListPlayersInGroup(List<Player> playersInGroup)
        {
            Player playerFound = playersInGroup.FirstOrDefault(player => player.username.Equals(username));

            if (playerFound != null)
            {
                playersInGroup.Remove(playerFound);
            }

            return playersInGroup;
        }


        private void Button_ExitGroup_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.PlayerConnectionClient client = new PassThePenService.PlayerConnectionClient(context);
            var response = MessageBox.Show(messageResource.GetString("MainMenu_LeaveGroup_Message"), "",  MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == MessageBoxResult.Yes)
            {
                Button_LeaveGroup.Visibility = Visibility.Collapsed;
                Button_ExitGame.Visibility = Visibility.Visible;
                client.LeaveGroup(username);
                PlacePlayersInGroup(new List<Player>());
            }
            
        }
    }
}
