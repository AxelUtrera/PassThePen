using Microsoft.Win32;
using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (password.Equals(repeatedPassword))
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
            }
            
            if (statusCode == statusOK)
            {
                MessageBox.Show("Nuevo jugador registrado con éxito");
            }
            else
            {
                MessageBox.Show("Upss ocurrio un error");
            }

            
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public byte[] ImageToByte(BitmapImage imageSource)
        {
            if(imageSource != null)
            {
                Console.WriteLine("no estoy nullo");
            }
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
