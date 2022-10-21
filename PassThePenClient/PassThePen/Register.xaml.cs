using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
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
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            PassThePenService.PlayerMgtClient client = new PassThePenService.PlayerMgtClient();

            string email = TexBox_Email.Text;
            string username = TextBox_Username.Text;
            string name = TextBox_Name.Text;
            string lastName = TextBox_LastName.Text;
            string password = PasswordBox_Password.Password;
            string repeatedPassword = PasswordBox_RepeatPassword.Password;

            int statusCode = 500;
            int statusOK = 200; 

            if (password.Equals(repeatedPassword))
            {
                Player newPlayer = new Player()
                {
                    email = email,
                    username = username,
                    name = name,
                    lastname = lastName,
                    password = password
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
    }
}
