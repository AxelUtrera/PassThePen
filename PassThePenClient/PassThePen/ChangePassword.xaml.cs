using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        private LogClient _log = new LogClient();

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerManagementClient client = new PlayerManagementClient();
                string currentPassword = PasswordBox_CurrentPassword.Password;
                const int validCode = 200;

                if (ValidatePassword())
                {
                    if (AutenticatePassword(MainMenu.username, currentPassword) == validCode)
                    {
                        string newPassword = PasswordBox_ConfirmPassword.Password;
                        if (client.UpdatePlayerPassword(MainMenu.username, newPassword) == validCode)
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
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
            }  
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
            if (!ValidateNullFields(currentPassword, confirmPassword, newPassword))
            {
                isValid = false;
            }
            if (PasswordBox_CurrentPassword.Password.Length < 8 || PasswordBox_CurrentPassword.Password.Length > 16)
            {
                MessageBox.Show("La contraseña actual debe ser mayor de 8 y menor de 16 caracteres");
                isValid = false;
            }
            if (!Validation.ValidateFormat(newPassword, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                isValid = false;
            }
            return isValid;
        }


        private bool ValidateNullFields(string currentPassword, string confirmPassword, string newPassword)
        {
            bool isValid = true;
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
            if (!isValid)
            {
                MessageBox.Show("No se aceptan campos vacios, favor de llenar todos los campos");
            }
            return isValid;
        }


        private int AutenticatePassword(string username, string password)
        {
            int result = 200;
            try
            {
                PassThePenService.Player player = new Player { username = username, password = password };
                PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                result = client.AutenticatePlayer(player);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                result = 500;
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                result = 500;
                _log.Add(ex.ToString());
            }
            return result;
        }
    }
}
