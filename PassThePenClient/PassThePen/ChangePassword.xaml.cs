using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Change_Password_Click(object sender, RoutedEventArgs e)
        {
            PlayerManagementClient client = new PlayerManagementClient();
            string currentPassword = PasswordBox_CurrentPassword.Password;
            if (AutenticatePassword(MainMenu.username, currentPassword) == 200)
            {
                if (ValidatePassword())
                {
                    string password = PasswordBox_ConfirmPassword.Password;
                    if (client.UpdatePlayerPassword(MainMenu.username, password) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("ChangePassword_PasswordChanged_Message"), "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("ChangePassword_PasswordNotChanged_Message"), "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(messageResource.GetString("ChangePassword_CurrentPasswordError_Message"), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            client.Close();
        }

        private Boolean ValidatePassword()
        {
            Label_InvalidPasswords.Visibility = Visibility.Hidden;
            Boolean isValid = true;
            string currentPassword = PasswordBox_CurrentPassword.Password;
            string newPassword = PasswordBox_NewPassword.Password;
            string confirmPassword = PasswordBox_ConfirmPassword.Password;
            if (!newPassword.Equals(confirmPassword))
            {
                Label_InvalidPasswords.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                Label_InvalidPasswords.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                Label_InvalidPasswords.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (string.IsNullOrEmpty(currentPassword))
            {
                Label_InvalidPasswords.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (!Validation.ValidateFormat(newPassword, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                isValid = false;
            }
            return isValid;
        }

        private int AutenticatePassword(string username, string password)
        {
            int result;
            PassThePenService.Player player = new Player { username = username, password = password };
            PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
            result = client.AutenticatePlayer(player);
            client.Close();
            return result;
        }
    }
}
