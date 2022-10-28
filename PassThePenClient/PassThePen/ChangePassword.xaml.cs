using PassThePen.PassThePenService;
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

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
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
            if (ValidatePassword())
            {
                string password = PasswordBox_ConfirmPassword.Password;
                if (client.UpdatePlayerPassword(MainMenu.username, password) == 200)
                {
                    MessageBox.Show("Contraseña actualizada con exito", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("La contraseña no pudo ser actualizada", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Boolean ValidatePassword()
        {
            Label_InvalidPasswords.Visibility = Visibility.Hidden;
            Boolean isValid = true;
            string newPassword = PasswordBox_NewPassword.Password;
            string confirmPassword = PasswordBox_ConfirmPassword.Password;
            if (!newPassword.Equals(confirmPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                Label_InvalidPasswords.Visibility = Visibility.Visible;
                isValid = false;
            }
            return isValid;
        }
    }
}
