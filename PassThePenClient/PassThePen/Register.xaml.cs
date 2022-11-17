using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
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
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerManagementClient client = new PassThePenService.PlayerManagementClient();

            string password = PasswordBox_Password.Password;
            string repeatedPassword = PasswordBox_RepeatPassword.Password;

            int statusCode = 500;
            int statusOK = 200; 

            if (password.Equals(repeatedPassword) && Validate_Fields(TexBox_Email.Text, password))
            {
                Player newPlayer = new Player()
                {
                    email = TexBox_Email.Text,
                    username = TextBox_Username.Text,
                    name = TextBox_Name.Text,
                    lastname = TextBox_LastName.Text,
                    password = PasswordBox_Password.Password
                };

                statusCode = client.AddPlayer(newPlayer);
            }
            else
            {
                MessageBox.Show("Campos invalidos favor de verificarlos");
            }
            
            if (statusCode == statusOK)
            {
                MessageBox.Show("Nuevo jugador registrado con éxito");
            }
            else
            {
                MessageBox.Show("Upss ocurrio un error, no se ha podido registrar al Jugador");
            }

            
        }

        private bool Validate_Fields(string email, string password)
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
            return result;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
