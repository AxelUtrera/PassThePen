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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
            
            PassThePenService.Player player = new PassThePenService.Player()
            {
                username = TextBox_Username.Text,
                password = PasswordBox_PasswordUser.Password
            };

            int playerValid = 200;
            int resultAutenticatePlayer = client.AutenticatePlayer(player);
           
            if (resultAutenticatePlayer == playerValid)
            {
                MainMenu.username = TextBox_Username.Text;
                InvokeMainMenu();
            }
            else
            {
                MessageBox.Show("Hubo un error en la validacion");
            }
            
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.ShowDialog();                 
        }

        private void Button_Forgot_Password_Click(object sender, RoutedEventArgs e)
        {
            //RecoverPassword recover = new RecoverPassword();
            //recover.Show();
            //MainMenu menu = new MainMenu();
            //menu.Show();
            Match match = new Match();
            match.Show();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void InvokeMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
