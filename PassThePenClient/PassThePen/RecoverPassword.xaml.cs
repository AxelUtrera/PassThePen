using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    
    public partial class RecoverPassword : Window
    {
        private int validationCode;
        private String email;
        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
            email = texBox_emailCode.Text;            
            if (ValidateEmail(email) && client.AutenticateEmail(email) == 200)
            {
                Random randomNumber = new Random();
                validationCode = randomNumber.Next(100000, 1000000);
                String affair = "Validation Code";
                try 
                {
                    if (client.CodeEmail(email, affair, validationCode) == 200)
                    {
                        MessageBox.Show("Código de validación enviado con exito");
                        label_Email.Visibility = Visibility.Hidden;
                        label_Code.Visibility = Visibility.Visible;
                        Button_Valid.Visibility = Visibility.Visible;
                        Button_Send.Visibility = Visibility.Hidden;
                        texBox_emailCode.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("No se pudo enviar el codigo");
                    }
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Tiempo de espera excedido, favor de intentar más tarde");
                }
            }
            else
            {
                MessageBox.Show("Email Invalido");
            }
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valid_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(texBox_emailCode.Text) == validationCode)
            {
                label_Email.Visibility = Visibility.Collapsed;
                label_Code.Visibility = Visibility.Collapsed;
                texBox_emailCode.Visibility = Visibility.Collapsed;
                panel_Email.Visibility = Visibility.Collapsed;
                label_NewPassword.Visibility = Visibility.Visible;
                label_repitPassword.Visibility = Visibility.Visible;
                passwordBox_newPassword.Visibility = Visibility.Visible;
                passwordBox_repitPassword.Visibility = Visibility.Visible;
                panel_Password.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Codigo incorrecto");
            }
        }

        public static Boolean ValidateEmail(String email)
        {
            Boolean result;
            String expresion;
            expresion = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        private void Button_change_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            if (ValidatePassword())
            {
                if (client.UpdatePassword(email, passwordBox_newPassword.Password) == 200)
                {
                    MessageBox.Show("La contraseña ha sido cambiada con exito");
                    Close();
                }
                else
                {
                    MessageBox.Show("La contraseña no ha podido cambiar");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales");
            }
        }

        public  Boolean ValidatePassword()
        {
            Boolean result = true;
            if (! passwordBox_newPassword.Password.Equals(passwordBox_repitPassword.Password))
            {
                result = false;
            }

            return result;
        }

        private void Button_cancel_password_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
