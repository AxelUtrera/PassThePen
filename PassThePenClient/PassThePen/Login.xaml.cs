using PassThePen.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void Button_LoginAsGuest_Click(object sender, MouseButtonEventArgs e)
        {
            PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();

            PassThePenService.Player guestPlayer = new PassThePenService.Player()
            {
                username = "Guest",
                password = "guest"
            };

            int autenticationValid = 200;
            int resultAutentication = client.AutenticatePlayer(guestPlayer);

            if(resultAutentication == autenticationValid)
            {
                MainMenu.username = "Guest";
                InvokeMainMenu();
            }
        }

        private void Button_ChangeLanguageEN_Click(object sender, MouseButtonEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            MessageBox.Show("The language is now English, login to visualize the changes", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_ChangeLanguageES_Click(object sender, MouseButtonEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
            MessageBox.Show("El lenguaje ahora es Español, inicie sesión para ver los cambios", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
