using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.ServiceModel;
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
        private int _validationCode;
        private String _email;
        private int _resendNumber = 0;
        private String _username;
        private LogClient _log = new LogClient();

        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateUsername())
                {
                    PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
                    PassThePenService.AutenticationClient clientEmail = new PassThePenService.AutenticationClient();
                    Player player = client.GetDataPlayer(TextBox_UsernameCode.Text.Trim());

                    if (player != null)
                    {
                        Random randomNumber = new Random();
                        _validationCode = randomNumber.Next(100000, 1000000);
                        String affair = messageResource.GetString("RecoverPassword_ValidationCodeTitle_Message");
                        _email = player.email;
                        _username = TextBox_UsernameCode.Text.Trim();
                        
                        if (clientEmail.CodeEmail(_email, affair, _validationCode) == 200)
                        {
                            MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeSend_Message"));

                            Label_Email.Visibility = Visibility.Hidden;
                            Label_Code.Visibility = Visibility.Visible;
                            Button_Valid.Visibility = Visibility.Visible;
                            Button_Resend.Visibility = Visibility.Visible;
                            Button_Send.Visibility = Visibility.Hidden;
                            TextBox_UsernameCode.Text = "";
                        }
                        else
                        {
                            MessageBox.Show(messageResource.GetString("Global_EmailError_Message"));
                        }
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_UserNotExist_Message"));
                    }
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_InvalidEmail_Message"));
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
                TextBox_UsernameCode.Visibility = Visibility.Collapsed;
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
            if (TextBox_UsernameCode.Text.Length > 6)
            {
                result = false;
                MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeLengthError_Message"));
            }
            if (Validation.ValidateFormat(TextBox_UsernameCode.Text, "^[0-9]+$"))
            {
                if (Int32.Parse(TextBox_UsernameCode.Text) != _validationCode)
                {
                    result = false;
                    MessageBox.Show(messageResource.GetString("RecoverPassword_IncorrectCodeValidationCode_Message"));
                }                
            }
            else
            {
                result = false;
                MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeEmpty_Message"));
            }    
            
            return result;
        }

        private bool ValidateUsername()
        {
            bool result = true;
            Label_ErrorEmail.Visibility = Visibility.Hidden;
            if (string.IsNullOrEmpty(TextBox_UsernameCode.Text))
            {
                MessageBox.Show(messageResource.GetString("RecoverPassword_EmptyFields_Message"));
                result = false;
            }
            if (TextBox_UsernameCode.Text.Length > 20)
            {
                Label_ErrorEmail.Visibility = Visibility.Visible;
                result = false;
            }
            return result;
        }
        

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
                if (ValidatePassword())
                {
                    if (client.UpdatePlayerPassword(_username, PasswordBox_NewPassword.Password) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_PasswordUpdated_Message"));
                        client.Close();
                        Login login = new Login();
                        login.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_DifferentPassword_Message"));
                    }
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_UnmatchedPassword_Message"));
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

        private  Boolean ValidatePassword()
        {
            Boolean result = true;
            Label_ErrorRepitPassword.Visibility = Visibility.Hidden;
            Label_ErrorPassword.Visibility = Visibility.Hidden;
            if (PasswordBox_NewPassword.Password.Equals("") || PasswordBox_RepitPassword.Password.Equals(""))
            {
                MessageBox.Show(messageResource.GetString("RecoverPassword_InvalidFields_Message"));
                result = false;
            }
            if (! PasswordBox_NewPassword.Password.Equals(PasswordBox_RepitPassword.Password))
            {
                Label_ErrorRepitPassword.Visibility = Visibility.Visible;
                result = false;
            }
            if (! Validation.ValidateFormat(PasswordBox_NewPassword.Password, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                Label_ErrorPassword.Visibility = Visibility.Visible;
                result = false;
            }
            return result;
        }

        private void Button_Resend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_resendNumber < 3)
                {
                    PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                    if (client.CodeEmail(_email, "Validation Code", _validationCode) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeEmail_Message"));
                        _resendNumber++;
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("RecoverPassword_ValidationCodeEmailError_Mesage"));
                    }
                    client.Close();
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("RecoverPassword_ResendNumberExceed_Message"));
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
    }
}
