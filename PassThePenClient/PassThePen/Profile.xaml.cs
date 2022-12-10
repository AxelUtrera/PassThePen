using Microsoft.Win32;
using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());

        public Profile()
        {
            InitializeComponent();
            SetDataPlayer();
            ValidateGuestUser();
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
                    MessageBox.Show(messageResource.GetString("Profile_UpdatedProfile_Message"));
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("Profile_UpdateProfileError_Message"));
                }
            }
            client.Close();
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
                Image_ProfileImage.Source = ImageManager.ToImage(playerObtained.profileImage);
            }
            client.Close();
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



            if (!Validation.ValidateFormat(TextBox_Email.Text, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                InvalidFields_Label.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (TextBox_Email.Text.Length > 100 || TextBox_Name.Text.Length > 50 || TextBox_Lastname.Text.Length > 50)
            {
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
            openFileDialog.Title = messageResource.GetString("Profile_SelectImage_Message");
            openFileDialog.Filter = messageResource.GetString("Profile_ImageFile_Message");
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                Image_ProfileImage.Source = image;
            }
        }

        private void ValidateGuestUser()
        {
            if (MainMenu.username.Equals("Guest"))
            {
                Button_SelectProfileImage.IsEnabled = false;
                TextBox_Name.IsEnabled = false;
                TextBox_Lastname.IsEnabled = false;
                TextBox_Email.IsEnabled = false;
                Button_ChangePassword.IsEnabled = false;
                Button_SaveChanges.IsEnabled = false;
            }
        }

        public static byte[] ImageToByte(BitmapImage imageSource)
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
