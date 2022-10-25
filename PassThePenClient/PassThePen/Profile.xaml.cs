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
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void SaveProfileChanges(object sender, RoutedEventArgs e)
        {
            PlayerMgtClient client = new PlayerMgtClient();
            if (ValidateInformation())
            {
                Byte[] image = ImageToByte(Image_ProfileImage.Source as BitmapImage);
                Console.WriteLine(image);
                Player player = new Player()
                {
                    username = Username_TextBox.Text,
                    name = Name_TextBox.Text,
                    lastname = Lastname_TextBox.Text,
                    email = Email_TextBox.Text,
                    profileImage = image
                };
                if (client.UpdateDataPlayer("dpax", player))
                {
                    MessageBox.Show("Perfil actualizado con exito");
                    Console.WriteLine(player.email);
                    Console.WriteLine(player.profileImage);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el perfil");
                }
            }
        }

        private void SetDataPlayer()
        {
            PassThePenService.PlayerMgtClient client = new PassThePenService.PlayerMgtClient();
            Player playerObtained = client.GetDataPlayer("dpax");

            if (playerObtained != null)
            {
                Console.WriteLine("NO esta vacio");
            }

        }

        private Boolean ValidateInformation()
        {
            InvalidFields_Label.Visibility = Visibility.Hidden;
            Boolean isValid = true;
            if (Email_TextBox.Text.Equals("") || Name_TextBox.Text.Equals("") || Lastname_TextBox.Text.Equals(""))
            {
                InvalidFields_Label.Visibility = Visibility.Visible;
                isValid = false;
            }
            return isValid;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasswordWindow = new ChangePassword();
            changePasswordWindow.Show();
        }

        private void Button_Select_Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a profile image";
            openFileDialog.Filter = "Image File (*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                Image_ProfileImage.Source = image;
            }
        }

        public static byte[] ImageToByte(BitmapImage imageSource)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));

            using (var ms = new MemoryStream())
            {
                encoder.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
