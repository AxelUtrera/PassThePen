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

        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
            email = TexBox_EmailCode.Text;            
            if (ValidateFormat(email, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$")  && TexBox_EmailCode.Text.Length <= 100 && client.AutenticateEmail(email) == 200)
            {
                Random randomNumber = new Random();
                validationCode = randomNumber.Next(100000, 1000000);
                String affair = messageResource.GetString("RecoverPassword_ValidationCodeTitle_Message");
                try 
                {
                    if (client.CodeEmail(email, affair, validationCode) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeSend_Message"));
                        Label_Email.Visibility = Visibility.Hidden;
                        Label_Code.Visibility = Visibility.Visible;
                        Button_Valid.Visibility = Visibility.Visible;
                        Button_Send.Visibility = Visibility.Hidden;
                        TexBox_EmailCode.Text = "";

                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeSendError_Message"));
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
            Close();
        }

        private void Button_Valid_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(TexBox_EmailCode.Text) == validationCode)
            {
                Label_Email.Visibility = Visibility.Collapsed;
                Label_Code.Visibility = Visibility.Collapsed;
                TexBox_EmailCode.Visibility = Visibility.Collapsed;
                Panel_Email.Visibility = Visibility.Collapsed;
                Label_NewPassword.Visibility = Visibility.Visible;
                Label_RepitPassword.Visibility = Visibility.Visible;
                PasswordBox_NewPassword.Visibility = Visibility.Visible;
                PasswordBox_RepitPassword.Visibility = Visibility.Visible;
                Panel_Password.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show(messageResource.GetString("RecoverPassword_IncorrectCode_Message"));
            }
        }

        public Boolean ValidateFormat(String text, string expresion)
        {
            Boolean result;
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, String.Empty).Length == 0)
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
                if (client.UpdatePassword(email, PasswordBox_NewPassword.Password) == 200)
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_PasswordUpdated_Message"));
                    Close();
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_PasswordNotUpdated_Message"));
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
            if (PasswordBox_NewPassword.Password.Equals("") || PasswordBox_RepitPassword.Password.Equals(""))
            {
                result = false;
            }
            if (! PasswordBox_NewPassword.Password.Equals(PasswordBox_RepitPassword.Password))
            {
                result = false;
            }
            if (! ValidateFormat(PasswordBox_NewPassword.Password, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                result = false;
            }
            return result;
        }

        

        
    }
}
