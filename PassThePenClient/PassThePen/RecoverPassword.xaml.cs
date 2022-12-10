using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        private int validationCode;
        private String email;
        private int resendNumber = 0;
        private String username;

        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            if (ValidateUsername())
            {
                Player player = client.GetDataPlayer(TextBox_Username_Code.Text.Trim());
                client.Close();
                PassThePenService.AutenticationClient clientEmail = new PassThePenService.AutenticationClient();
                Random randomNumber = new Random();
                validationCode = randomNumber.Next(100000, 1000000);
                String affair = messageResource.GetString("RecoverPassword_ValidationCodeTitle_Message");
                email = player.email;
                username = TextBox_Username_Code.Text.Trim();
                try 
                {
                    if (clientEmail.CodeEmail(email, affair, validationCode) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeSend_Message"));
                        Label_Email.Visibility = Visibility.Hidden;
                        Label_Code.Visibility = Visibility.Visible;
                        Button_Valid.Visibility = Visibility.Visible;
                        Button_Resend.Visibility = Visibility.Visible;
                        Button_Send.Visibility = Visibility.Hidden;
                        TextBox_Username_Code.Text = "";

                    }
                }
                catch (TimeoutException)
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_Timeout_Message"));
                }
            }
            else
            {
                MessageBox.Show(messageResource.GetString("RecoverPassword_InvalidEmail_Message"));
            }
            client.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Button_Valid_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCodeValidation())
            {
                MessageBox.Show("Codigo correcto");
                Label_Email.Visibility = Visibility.Collapsed;
                Label_Code.Visibility = Visibility.Collapsed;
                TextBox_Username_Code.Visibility = Visibility.Collapsed;
                Panel_Email.Visibility = Visibility.Collapsed;
                Label_NewPassword.Visibility = Visibility.Visible;
                Label_RepitPassword.Visibility = Visibility.Visible;
                PasswordBox_NewPassword.Visibility = Visibility.Visible;
                PasswordBox_RepitPassword.Visibility = Visibility.Visible;
                Panel_Password.Visibility = Visibility.Visible;
            }
        }

        private bool ValidateCodeValidation()
        {
            bool result = true;
            if (TextBox_Username_Code.Text.Length > 6)
            {
                result = false;
                MessageBox.Show("Longitud incorrecta, el código de validación no excede los 6 caracteres");
            }
            if (Validation.ValidateFormat(TextBox_Username_Code.Text, "^[0-9]+$"))
            {
                if (Int32.Parse(TextBox_Username_Code.Text) != validationCode)
                {
                    result = false;
                    MessageBox.Show("Codigo de validación incorrecto, favor de verificarlo");
                }                
            }
            else
            {
                result = false;
                MessageBox.Show("No se aceptan letras o campos vacios en el apartado codigo de validación");
            }    
            
            return result;
        }

        private bool ValidateUsername()
        {
            bool result = true;
            label_Error_Email.Visibility = Visibility.Hidden;
            if (string.IsNullOrEmpty(TextBox_Username_Code.Text))
            {
                MessageBox.Show("Campos vacios, favor de llenar todos los campos");
                result = false;
            }
            if (TextBox_Username_Code.Text.Length > 20)
            {
                label_Error_Email.Visibility = Visibility.Visible;
                result = false;
            }
            return result;
        }
        

        private void Button_change_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            if (ValidatePassword())
            {
                if (client.UpdatePlayerPassword(username, PasswordBox_NewPassword.Password) == 200)
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_PasswordUpdated_Message"));
                    Login login = new Login();
                    login.Show();

                    
                    Close();
                }
                else
                {
                    MessageBox.Show("La contraseña debe ser diferente a la anterior");
                }
            }
            else
            {
                MessageBox.Show(messageResource.GetString("RecoverPassword_UnmatchedPassword_Message"));
            }
            client.Close();
        }

        private  Boolean ValidatePassword()
        {
            Boolean result = true;
            label_Error_Repit_Password.Visibility = Visibility.Hidden;
            label_Error_Password.Visibility = Visibility.Hidden;
            if (PasswordBox_NewPassword.Password.Equals("") || PasswordBox_RepitPassword.Password.Equals(""))
            {
                MessageBox.Show("No se aceptan campos invalidos en el sistema");
                result = false;
            }
            if (! PasswordBox_NewPassword.Password.Equals(PasswordBox_RepitPassword.Password))
            {
                label_Error_Repit_Password.Visibility = Visibility.Visible;
                result = false;
            }
            if (! Validation.ValidateFormat(PasswordBox_NewPassword.Password, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                label_Error_Password.Visibility = Visibility.Visible;
                result = false;
            }
            return result;
        }

        private void Button_Resend_Click(object sender, RoutedEventArgs e)
        {
            if (resendNumber < 3)
            {
                PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                if (client.CodeEmail(email, "Validation Code", validationCode) == 200)
                {
                    MessageBox.Show("Código de validación enviado a su correo favor de revisarlo");
                    resendNumber++;
                }
                else
                {
                    MessageBox.Show("No se ha podido enviar el correo electronico, favor de verificar el correo ingresado");
                }
                client.Close();
            }
            else
            {
                MessageBox.Show("Numero de reeenvios superado");
            }
        }
    }
}
