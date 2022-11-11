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
        List<string> listStrings = new List<string>();
        List<Friends> friendList = new List<Friends>();

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
            if (TextBox_FindFriend.Visibility == Visibility.Collapsed)
            {
                PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
                TextBox_FindFriend.Visibility = Visibility.Visible;
                string[] friendsName = getFriendsName();
                foreach (String str in friendsName)
                {
                    listStrings.Add(str);
                }
            }
            else
            {
                TextBox_FindFriend.Visibility = Visibility.Collapsed;
            }
            
        }

        private string[] getFriendsName()
        {
            string[] friendsName = new string[friendList.Count()];
            for(int index = 0; index < friendList.Count(); index++)
            {
                friendsName[index] = friendList[index].friendUsername;
            }
            return friendsName;
        }
       
        private void Button_ExitGame_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.PlayerConexionClient client = new PlayerConexionClient(instanceContext);
            client.Disconnect(username);
            this.Close();
        }

        private void Button_InviteFriendImage_Button(object sender, RoutedEventArgs e)
        { 
            //botones del centro para invitar a jugador.

            this.Close();
        }

        private void Button_FriendRequests_Click(object sender, RoutedEventArgs e)
        {
            label_ListFriends.Visibility = Visibility.Collapsed;
            label_FriendRequests.Visibility = Visibility.Visible;
            GenerateFriendRequestList();
        }



        private void Button_Friends_Click(object sender, RoutedEventArgs e)
        {
            label_FriendRequests.Visibility = Visibility.Collapsed;
            label_ListFriends.Visibility = Visibility.Visible;
            ListBox_FriendsRequests.Visibility = Visibility.Collapsed;
            ListBox_FriendList.Visibility = Visibility.Visible;
            GetFriends();
        }

        private void Button_ConfirmRequests_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_DeclineRequests_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateFriendRequestList()
        {
            ListBox_FriendList.Visibility = Visibility.Collapsed;
            ListBox_FriendsRequests.Visibility = Visibility.Visible;
            PassThePenService.FriendRequestsClient client = new PassThePenService.FriendRequestsClient();
            ListBox_FriendsRequests.ItemsSource = client.GetFriendRequestsList(username);
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
            client.RecoverOnlinePlayers(username);
        }

        public void PlayersCallBack(Friends[] friends)
        {
            friendList = friends.ToList();
            ListBox_FriendList.ItemsSource = friendList;
        }

        private void Button_StartMatch_Click(object sender, RoutedEventArgs e)
        {
            Match match = new Match();
            match.Show();
        }

        private void TextBox_FindFriend_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox_FindFriend.Text.Trim()) == false)
            {
                List<Friends> friendsEquals = new List<Friends>();
                friendsEquals.Clear();
                foreach (string str in listStrings)
                {
                    for(int index = 0; index < friendList.Count; index++)
                    {
                        if (str.StartsWith(TextBox_FindFriend.Text.Trim()) && str.Equals(friendList[index].friendUsername))
                        {
                            friendsEquals.Add(friendList[index]);
                        }
                    }
                }
                ListBox_FriendList.ItemsSource = friendsEquals;
            }
            else if (TextBox_FindFriend.Text.Trim() == "")
            {
                ListBox_FriendList.ItemsSource = friendList;
            }
        }
    }
}
