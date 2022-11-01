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
            SetDataPlayer();
        }

        private void Button_SaveProfileChanges_Click(object sender, RoutedEventArgs e)
        {
            PlayerManagementClient client = new PlayerManagementClient();
            if (ValidateInformation())
            {
                Byte[] image = ImageToByte(Image_ProfileImage.Source as BitmapImage);
                Player player = new Player()
                {
                    username = TextBox_Username.Text,
                    name = TextBox_Name.Text,
                    lastname = TextBox_Lastname.Text,
                    email = TextBox_Email.Text,
                    profileImage = image
                };

                if (client.UpdateDataPlayer(MainMenu.username, player) == 200)
                {
                    MessageBox.Show("Perfil actualizado con exito");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el perfil");
                }
            }
        }


        private void SetDataPlayer()
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
            Player playerObtained = client.GetDataPlayer(MainMenu.username);
            if (playerObtained != null)
            {
                TextBox_Username.Text = playerObtained.username;
                TextBox_Name.Text = playerObtained.name;
                TextBox_Lastname.Text = playerObtained.lastname;
                TextBox_Email.Text = playerObtained.email;
<<<<<<< HEAD
                //Image_ProfileImage.Source = LoadBitmapFromBytes(playerObtained.profileImage);
=======
                Image_ProfileImage.Source = LoadBitmapFromBytes(playerObtained.profileImage);
>>>>>>> fb2eeef1be78f48c34c475643f0ada0a88502bbd
            }

        }


        private Boolean ValidateInformation()
        {
            InvalidFields_Label.Visibility = Visibility.Hidden;
            Boolean isValid = true;
            if (TextBox_Email.Text.Equals("") || TextBox_Name.Text.Equals("") || TextBox_Lastname.Text.Equals(""))
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


        public static BitmapImage LoadBitmapFromBytes(byte[] bytes)
        {
            var image = new BitmapImage();
            using (var stream = new MemoryStream(bytes))
            {
                stream.Seek(0, SeekOrigin.Begin);
                image.BeginInit();
                image.StreamSource = stream;
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.EndInit();
            }

            return image;
        }

    }
}
