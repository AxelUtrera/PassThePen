using Microsoft.Win32;
using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
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
    /// Lógica de interacción para Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        private LogClient _log = new LogClient();

        public Profile()
        {
            InitializeComponent();
            SetDataPlayer();
            ValidateGuestUser();
        }

        private void Button_SaveProfileChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerManagementClient client = new PlayerManagementClient();
                const int validCode = 200;

                if (ValidateInformation())
                {
                    Byte[] image = ImageManager.ImageToByte(Image_ProfileImage.Source as BitmapImage);
                    Player player = new Player()
                    {
                        username = TextBox_Username.Text,
                        name = TextBox_Name.Text,
                        lastname = TextBox_Lastname.Text,
                        email = TextBox_Email.Text,
                        profileImage = image
                    };

                    if (client.UpdateDataPlayer(MainMenu.username, player) == validCode)
                    {
                        MessageBox.Show(messageResource.GetString("Profile_UpdatedProfile_Message"));
                    }
                    else
                    {
                        MessageBox.Show(messageResource.GetString("Profile_UpdateProfileError_Message"));
                    }
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


        private void SetDataPlayer()
        {
            try
            {
                PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();
                Player playerObtained = client.GetDataPlayer(MainMenu.username);

                if (playerObtained != null)
                {
                    TextBox_Username.Text = playerObtained.username;
                    TextBox_Name.Text = playerObtained.name;
                    TextBox_Lastname.Text = playerObtained.lastname;
                    TextBox_Email.Text = playerObtained.email;
                    Image_ProfileImage.Source = ImageManager.ByteToImage(playerObtained.profileImage);
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


        private Boolean ValidateInformation()
        {
            Label_InvalidFields.Visibility = Visibility.Hidden;
            Label_ErrorName.Visibility = Visibility.Hidden;
            Label_ErrorLastname.Visibility = Visibility.Hidden;
            Label_ErrorEmail.Visibility = Visibility.Hidden;
            Boolean isValid = true;

            if (!ValidateNullFields())
            {
                isValid = false;
            }
            if (!FormatValidate())
            {
                isValid = false;
            }
            if (!ValidateLengthFields())
            {
                isValid = false;
            }
            return isValid;
        }


        private bool FormatValidate()
        {
            bool isValid = true;
            if (!Validation.ValidateFormat(TextBox_Email.Text, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                Label_ErrorEmail.Visibility = Visibility.Visible;
                isValid = false;               
            }
            if (!Validation.ValidateFormat(TextBox_Name.Text, @"^[A-Za-z\s@]*$") || !Validation.ValidateFormat(TextBox_Lastname.Text, @"^[A-Za-z\s@]*$"))
            {
                isValid = false;
                MessageBox.Show(messageResource.GetString("Profile_EmptyFields_Message"));
            }
            return isValid;
        }


        private bool ValidateNullFields()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(TextBox_Name.Text))
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(TextBox_Lastname.Text))
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(TextBox_Email.Text))
            {
                isValid = false;
            }
            if (!isValid)
            {
                Label_InvalidFields.Visibility = Visibility.Visible;
            }
            return isValid;
        }


        private bool ValidateLengthFields()
        {
            bool isValid = true;

            if (TextBox_Name.Text.Length > 50)
            {
                Label_ErrorName.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (TextBox_Lastname.Text.Length > 50)
            {
                Label_ErrorLastname.Visibility = Visibility.Visible;
                isValid = false;
            }
            if (TextBox_Email.Text.Length > 100)
            {
                Label_ErrorEmail.Visibility = Visibility.Visible;
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


        private void Button_SelectImage_Click(object sender, RoutedEventArgs e)
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
    }
}
