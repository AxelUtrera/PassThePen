using PassThePen.PassThePenService;
using PassThePen.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window, PassThePenService.IPlayerConexionCallback
    {
        public static string username;

        public MainMenu()
        {
            InitializeComponent();
            Connected();
            GetFriends();
        }

        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            
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
            PassThePenService.PlayerManagementClient client = new PlayerManagementClient();
            client.GetFriends(username);
            
        }

        public void PlayersCallBack(Friends[] friends)
        {
            
            List<Friends> friendList = new List<Friends>();
            for (int index = 0; index < friends.Count(); index++)
            {
                ListBoxItem item = new ListBoxItem();
                if (friends[index].status)
                {
                    item.Content = friends[index].friendUsername;
                    item.Foreground = Brushes.Green;
                }
                else
                {
                    item.Content = friends[index].friendUsername;
                    item.Foreground = Brushes.Red;
                }
                friendList.Add(friends[index]);
                
            }
            ListBox_FriendList.ItemsSource = friendList;
        }

        private void Button_StartMatch_Click(object sender, RoutedEventArgs e)
        {
            Match match = new Match();
            match.Show();
        }

        private void Button_DeleteFriend_Click(object sender, MouseButtonEventArgs e)
        {

            Image buttonDeleteFriend = (Image)sender;
            StackPanel parent = (StackPanel)buttonDeleteFriend.Parent;
            Friends friend = (Friends)parent.DataContext;
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            client.DeleteFriend(friend);
            client.GetFriends(username);
            
        }
    }
}
