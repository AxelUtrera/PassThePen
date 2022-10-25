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
            PassThePenService.PlayerMgtClient client = new PassThePenService.PlayerMgtClient();

            
            PassThePenService.Player player = new PassThePenService.Player()
            {
                email = TextBox_EmailUser.Text,
                password = PasswordBox_PasswordUser.Password
            };

            //200 = status code "OK"
            int playerValid = 200;
            int resultAutenticatePlayer = client.AutenticatePlayer(player);
           
            if (resultAutenticatePlayer == playerValid)
            {
                MainMenu.username = TextBox_EmailUser.Text;
                MessageBox.Show("La validacion fue exitosa");
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
            RecoverPassword recover = new RecoverPassword();
            recover.Show();
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
