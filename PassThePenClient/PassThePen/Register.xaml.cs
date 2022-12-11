using Microsoft.Win32;
using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());

        private Player player = new Player();
        private int validationCode;
        private int resendNumber = 0;
        private LogClient log = new LogClient();

        public Register()
        {
            InitializeComponent();
            string NewIconPlayer = ConfigurationManager.AppSettings.Get("NewIcon_Player");
            Image_RegisterPlayer.Source = new BitmapImage(new Uri(NewIconPlayer));
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                byte[] defaultProfileImage = ImageToByte(Image_RegisterPlayer.Source as BitmapImage);
                if (ValidateFields())
                {
                    player.email = TexBox_Email.Text;
                    player.username = TextBox_Username.Text;
                    player.name = TextBox_Name.Text;
                    player.lastname = TextBox_LastName.Text;
                    player.password = PasswordBox_Password.Password;
                    player.profileImage = defaultProfileImage;
                    Random randomNumber = new Random();
                    validationCode = randomNumber.Next(100000, 1000000);
                    if (client.CodeEmail(player.email, "Validation Code", validationCode) == 200)
                    {
                        MessageBox.Show(messageResource.GetString("Register_Successful_Message"));
                        HideComponetsRegister();
                        label_Code_Validation.Visibility = Visibility.Visible;
                        TexBox_Code_Validation.Visibility = Visibility.Visible;
                        Panel_Validation_Code.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("Global_EmailError_Message"));
                    }
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

        private bool ValidateFields()
        {
            bool result = true;
            HideErrorLabels();
            if(!PasswordBox_Password.Password.Equals(PasswordBox_RepeatPassword.Password))
            {
                label_Error_RepeatPassword.Visibility = Visibility.Visible;
                result = false;
            }
            if(!ValidateNullFields())
            {
                result = false;
            }
            if (!FormatValidate())
            {
                result = false;
            }
            if (!ValidateLength())
            {
                result = false;
            }
            return result;
        }

        private bool ValidateNullFields()
        {
            bool result = true;
            if (string.IsNullOrEmpty(TextBox_Name.Text))
            {
                result = false;
            }
            if (string.IsNullOrEmpty(TextBox_LastName.Text))
            {
                result = false;
            }
            if (string.IsNullOrEmpty(TextBox_Username.Text))
            {
                result = false;
            }
            if (string.IsNullOrEmpty(TexBox_Email.Text))
            {
                result = false;
            }
            if (!result)
            {
                MessageBox.Show("Campos incompletos favor de llenar todos los campos");
            }
            return result;
        }
        
        private bool FormatValidate()
        {
            bool result = true;
            if (!Validation.ValidateFormat(TexBox_Email.Text, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                label_Error_Email.Visibility = Visibility.Visible;
                result = false;
            }
            if (!Validation.ValidateFormat(PasswordBox_Password.Password, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                label_Error_Password.Visibility = Visibility.Visible;
                result = false;
            }
            if (!Validation.ValidateFormat(TextBox_Name.Text, @"^[A-Za-z\s@]*$") || !Validation.ValidateFormat(TextBox_LastName.Text, @"^[A-Za-z\s@]*$"))
            {
                result = false;
                MessageBox.Show("No se aceptan numeros o datos vacios en los apartados nombre y apellido");
            }
            return result;
        }

        private bool ValidateLength()
        {
            bool result = true;
            if (TextBox_Username.Text.Length > 20)
            {
                label_Error_Username.Visibility = Visibility.Visible;
                result = false;
            }
            if (TextBox_Name.Text.Length > 50)
            {
                label_Error_Name.Visibility = Visibility.Visible;
                result = false;
            }
            if (TextBox_LastName.Text.Length > 50)
            {
                label_Error_LastName.Visibility = Visibility.Visible;
                result = false;
            }
            if (TexBox_Email.Text.Length > 100)
            {
                label_Error_Email.Visibility = Visibility.Visible;
                result = false;
            }
            return result;
        }


        private void HideErrorLabels()
        {
            label_Error_Email.Visibility = Visibility.Hidden;
            label_Error_LastName.Visibility = Visibility.Hidden;
            label_Error_Name.Visibility = Visibility.Hidden;
            label_Error_Password.Visibility = Visibility.Hidden;
            label_Error_RepeatPassword.Visibility = Visibility.Hidden;
            label_Error_Username.Visibility = Visibility.Hidden;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        public byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateCodeValidation())
                {
                    PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
                    int statusCode;
                    int statusOK = 200;
                    statusCode = client.AddPlayer(player);
                    if (statusCode == statusOK)
                    {
                        client.AddGuestFriend(player.username);
                        MessageBox.Show(messageResource.GetString("Register_SuccessfulRegister_Message"));
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("Register_ErrorRegister_Message"));
                    }
                    client.Close();
                }
                else
                {
                    MessageBox.Show("Código de validación invalido, favor de volverlo a ingresar");
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

        private bool ValidateCodeValidation()
        {
            bool result = true;
            if (TexBox_Code_Validation.Text.Length > 6)
            {
                result = false;
                MessageBox.Show("Longitud incorrecta, el código de validación no excede los 6 caracteres");
            }
            if (Validation.ValidateFormat(TexBox_Code_Validation.Text, "^[0-9]+$"))
            {
                if (Int32.Parse(TexBox_Code_Validation.Text) != validationCode)
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

        private void Button_Resend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (resendNumber < 3)
                {
                    PassThePenService.AutenticationClient client = new PassThePenService.AutenticationClient();
                    if (client.CodeEmail(player.email, "Validation Code", validationCode) == 200)
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

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            resendNumber = 0;
            TexBox_Code_Validation.Text = "";
            ShowComponentsRegister();
        }

        private void ShowComponentsRegister()
        {
            label_Email.Visibility = Visibility.Visible;
            label_Confirm_Password.Visibility = Visibility.Visible;
            label_Lastname.Visibility = Visibility.Visible;
            label_Name.Visibility = Visibility.Visible;
            label_Nickname.Visibility = Visibility.Visible;
            label_Password.Visibility = Visibility.Visible;
            HideErrorLabels();
            TexBox_Email.Visibility = Visibility.Visible;
            TextBox_LastName.Visibility = Visibility.Visible;
            TextBox_Name.Visibility = Visibility.Visible;
            TextBox_Username.Visibility = Visibility.Visible;
            PasswordBox_Password.Visibility = Visibility.Visible;
            PasswordBox_RepeatPassword.Visibility = Visibility.Visible;
            Button_Register.Visibility = Visibility.Visible;
            Panel_Validation_Code.Visibility = Visibility.Collapsed;
            TexBox_Code_Validation.Visibility = Visibility.Collapsed;
            label_Code_Validation.Visibility = Visibility.Collapsed;
        }

        private void HideComponetsRegister()
        {
            label_Email.Visibility = Visibility.Collapsed;
            label_Confirm_Password.Visibility = Visibility.Collapsed;
            label_Lastname.Visibility = Visibility.Collapsed;
            label_Name.Visibility = Visibility.Collapsed;
            label_Nickname.Visibility = Visibility.Collapsed;
            label_Password.Visibility = Visibility.Collapsed;
            label_Error_Email.Visibility = Visibility.Collapsed;
            label_Error_LastName.Visibility = Visibility.Collapsed;
            label_Error_Name.Visibility = Visibility.Collapsed;
            label_Error_Password.Visibility = Visibility.Collapsed;
            label_Error_RepeatPassword.Visibility= Visibility.Collapsed;
            label_Error_Username.Visibility = Visibility.Collapsed;
            TexBox_Email.Visibility = Visibility.Collapsed;
            TextBox_LastName.Visibility = Visibility.Collapsed;
            TextBox_Name.Visibility = Visibility.Collapsed;
            TextBox_Username.Visibility =Visibility.Collapsed;
            PasswordBox_Password.Visibility = Visibility.Collapsed;
            PasswordBox_RepeatPassword.Visibility = Visibility.Collapsed;
            Button_Register.Visibility = Visibility.Collapsed;
        }
    }
}
