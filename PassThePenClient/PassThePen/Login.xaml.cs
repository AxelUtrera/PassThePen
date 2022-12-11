using PassThePen.PassThePenService;
using PassThePen.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.ServiceModel;
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
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        private LogClient log = new LogClient();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassThePenService.AutenticationClient clientAutentication = new PassThePenService.AutenticationClient();
                PassThePenService.Player player = new PassThePenService.Player()
                {
                    username = TextBox_Username.Text,
                    password = PasswordBox_PasswordUser.Password
                };
                if (ValidateInformation())
                {
                    int playerValid = 200;
                    int isNotConected = 404;
                    int resultAutenticatePlayer = clientAutentication.AutenticatePlayer(player);
                    if (resultAutenticatePlayer == playerValid && clientAutentication.FindPlayerIsConected(player.username) == isNotConected)
                    {
                        MainMenu.username = TextBox_Username.Text;
                        InvokeMainMenu();
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("Login_ErrorLogin_Message"));
                    }
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("Login_InvalidData_Message"));
                }
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }

        private bool ValidateInformation()
        {
            bool result = true;
            if (string.IsNullOrEmpty(TextBox_Username.Text) && string.IsNullOrEmpty(PasswordBox_PasswordUser.Password))
            {
                return false;
            }
            if (TextBox_Username.Text.Length > 50 && PasswordBox_PasswordUser.Password.Length > 16)
            {
                return false;
            }
            return result;
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }

        private void Button_Forgot_Password_Click(object sender, RoutedEventArgs e)
        {
            RecoverPassword recover = new RecoverPassword();
            recover.Show();
            this.Close();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void InvokeMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void Button_LoginAsGuest_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                PassThePenService.AutenticationClient clientAutentication = new PassThePenService.AutenticationClient();

                PassThePenService.Player guestPlayer = new PassThePenService.Player()
                {
                    username = "Guest",
                    password = "guest"
                };

                int autenticationValid = 200;
                int isNotConected = 404;
                int resultAutentication = client.AutenticatePlayer(guestPlayer);

                if (resultAutentication == autenticationValid && clientAutentication.FindPlayerIsConected(guestPlayer.username) == isNotConected)
                {
                    MainMenu.username = "Guest";
                    InvokeMainMenu();
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("Login_ErrorLogin_Message"));
                }
                client.Close();
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
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
