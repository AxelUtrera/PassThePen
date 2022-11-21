using Microsoft.Win32;
using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public Register()
        {
            InitializeComponent();
            Image_RegisterPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/Img/Image_DefaultProfileImage.png"));
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();

            string password = PasswordBox_Password.Password;
            string repeatedPassword = PasswordBox_RepeatPassword.Password;
            byte[] defaultProfileImage = ImageToByte(Image_RegisterPlayer.Source as BitmapImage);

            int statusCode = 500;
            int statusOK = 200; 

            if (password.Equals(repeatedPassword) && ValidateFields(TexBox_Email.Text, password))
            {
                Player newPlayer = new Player()
                {
                    email = TexBox_Email.Text,
                    username = TextBox_Username.Text,
                    name = TextBox_Name.Text,
                    lastname = TextBox_LastName.Text,
                    password = PasswordBox_Password.Password,
                    profileImage = defaultProfileImage
                };

                statusCode = client.AddPlayer(newPlayer);
                if (statusCode == statusOK)
                {
                    MessageBox.Show("Nuevo jugador registrado con éxito");
                    Login login = new Login();
                    login.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Upss ocurrio un error, no se ha podido registrar al Jugador");
                }
            }
            else
            {
                MessageBox.Show("Campos invalidos favor de verificarlos");
            }
            client.Close();
        }

        private bool ValidateFields(string email, string password)
        {
            RecoverPassword recoverPassword = new RecoverPassword();
            bool result = true;
            if ( string.IsNullOrEmpty(TextBox_Name.Text) || string.IsNullOrEmpty(TextBox_LastName.Text))
            {
                result = false;
            }
            if (string.IsNullOrEmpty(TextBox_Username.Text) || string.IsNullOrEmpty(TexBox_Email.Text))
            {
                result = false;
            }
            if (! recoverPassword.ValidateFormat(email, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                result = false;
            }
            if (! recoverPassword.ValidateFormat(password, "^(?=.*\\d)(?=.*[\\u0021-\\u002b\\u003c-\\u0040])(?=.*[A-Z])(?=.*[a-z])\\S{8,16}$"))
            {
                result = false;
            }
            if (!ValidateLength())
            {
                result = false;
            }
            return result;
        }

        private bool ValidateLength()
        {
            bool result = true;
            if (TextBox_Name.Text.Length > 20 || TextBox_Name.Text.Length > 50)
            {
                result = false;
            }
            if (TextBox_LastName.Text.Length > 50 || TexBox_Email.Text.Length > 100)
            {
                result = false;
            }
            return result;
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
    }
}
