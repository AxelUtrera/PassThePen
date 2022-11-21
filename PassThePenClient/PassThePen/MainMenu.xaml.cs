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

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window, PassThePenService.IPlayerConexionCallback
    {
        public static string username;
        private List<string> listStrings = new List<string>();
        private List<Friends> friendList = new List<Friends>();
        private List<FriendRequest> friendRequests = new List<FriendRequest>();

        public MainMenu()
        {
            InitializeComponent();
            Connected();
            GetFriends();
            listStrings.Clear();
        }

        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            
        }


        private void Button_FindFriends_Click(object sender, RoutedEventArgs e)
        {
            listStrings.Clear();
            if (TextBox_FindFriend.Visibility == Visibility.Collapsed && ListBox_FriendList.Visibility == Visibility.Visible) 
            {
                TextBox_FindFriend.Visibility = Visibility.Visible;
                friendList.ForEach(fri => listStrings.Add(fri.friendUsername));
            }
            else if (TextBox_FindFriend.Visibility == Visibility.Collapsed && ListBox_FriendsRequests.Visibility == Visibility.Visible)
            {
                TextBox_FindFriend.Visibility = Visibility.Visible;
                friendRequests.ForEach(fri => listStrings.Add(fri.friendUsername));
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
            PassThePenService.PlayerConexionClient client = new PlayerConexionClient(instanceContext);
            client.Disconnect(username);
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
            FriendRequest friendRequests = GetFriendRequestOfListboxImageButton(sender);
            FriendRequestsClient clientFriendRequest = new FriendRequestsClient();
            PlayerManagementClient clientFriends = new PlayerManagementClient();
            clientFriendRequest.AcceptFriendRequest(friendRequests);
            GenerateFriendRequestList();
            clientFriends.GetFriends(username);
            clientFriendRequest.Close();
            clientFriends.Close();
        }

        private void Button_DeclineRequests_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.FriendRequestsClient client = new FriendRequestsClient();
            FriendRequest friendRequests = GetFriendRequestOfListboxImageButton(sender);
            client.DeclineFriendRequests(friendRequests);
            GenerateFriendRequestList();
            client.Close();
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
            client.Close();
        }

        private void Connected()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConexionClient client = new PlayerConexionClient(instanceContext);
            client.Connect(username);

        }

        private void GetFriends()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConexionClient client = new PlayerConexionClient(instanceContext);
            client.SendOnlinePlayers(username);            
        }

        public void PlayersCallBack(Friends[] friends)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConexionClient client = new PlayerConexionClient(instanceContext);
            List<string> playersConected = client.GetNameOnlinePlayers().ToList();
            friendList = friends.ToList();
            ListBox_FriendList.ItemsSource = friendList;

            /*
            foreach (string playerConected in playersConected)
            {
                foreach (Friends listboxFriend in ListBox_FriendList.Items)
                {
                    if(listboxFriend.friendUsername.Equals(playerConected))
                    {
                       
                    }
                }
            }
            */
        }

        private void Button_StartMatch_Click(object sender, RoutedEventArgs e)
        {
            Match match = new Match();
            match.Show();
        }

        private void TextBox_FindFriend_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ListBox_FriendList.Visibility == Visibility.Visible)
            {
                Filter_Friend_List();
            }
            else if (ListBox_FriendsRequests.Visibility == Visibility.Visible)
            {
                Filter_Friends_Requests();  
            }
        }


        private void Filter_Friends_Requests()
        {
            if (String.IsNullOrEmpty(TextBox_FindFriend.Text.Trim()) == false)
            {
                List<FriendRequest> friendsEquals = new List<FriendRequest>();
                friendsEquals.Clear();
                foreach (string str in listStrings)
                {

                    if (str.StartsWith(TextBox_FindFriend.Text.Trim()))
                    {
                        friendsEquals.Add(friendRequests.Find(fri => fri.friendUsername.Contains(str)));
                    }
                }
                ListBox_FriendsRequests.ItemsSource = friendsEquals;
            }
            else if (TextBox_FindFriend.Text.Trim() == "")
            {
                ListBox_FriendsRequests.ItemsSource = friendRequests;
            }
        }

        private void Filter_Friend_List()
        {
            if (String.IsNullOrEmpty(TextBox_FindFriend.Text.Trim()) == false)
            {
                List<Friends> friendsEquals = new List<Friends>();
                friendsEquals.Clear();
                foreach (string str in listStrings)
                {

                    if (str.StartsWith(TextBox_FindFriend.Text.Trim()))
                    {
                        friendsEquals.Add(friendList.Find(fri => fri.friendUsername.Contains(str)));
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
        }

        private void Button_AddFriend_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.FriendRequestsClient client = new FriendRequestsClient();
            FriendRequest friendRequest = new FriendRequest() {
                usernamePlayer = Texbox_AddFriend.Text,
                friendUsername = username
            };
            client.SendFriendRequests(friendRequest);
        }

        private void Button_InviteFriend_Click(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
