using PassThePen.PassThePenService;
using PassThePen.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MainMenu : Window
    {
        public static string username;

        public MainMenu()
        {
            InitializeComponent();
            RecoverListFriends();
        }

        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void Button_ExitGame_Click(object sender, RoutedEventArgs e)
        {
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
            
        }

        private void Button_ConfirmRequests_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_DeclineRequests_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateFriendRequestList()
        {
            PassThePenService.FriendRequestsClient client = new PassThePenService.FriendRequestsClient();
            ListBox_MainMenu.ItemsSource = client.GetFriendRequestsList(username);
            Console.WriteLine(client.GetFriendRequestsList(username));
            client.Close();
        }

        private void RecoverListFriends()
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            Friends[] friends = client.GetFriends(username);

            for(int index = 0; index < friends.Count(); index++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = friends[index].friendUsername;
                item.Foreground = Brushes.Black;
                ListBox_MainMenu.Items.Add(item);
            }
            client.Close();
        }
    }
}
