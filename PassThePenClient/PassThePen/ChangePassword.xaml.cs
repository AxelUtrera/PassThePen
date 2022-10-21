using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            
            if (ValidateEmail(texBox_emailCodigo.Text))
            {
                PassThePenService.PlayerMgtClient client = new PassThePenService.PlayerMgtClient();
                if (client.AutenticateEmail(texBox_emailCodigo.Text) == 200)
                {
                    MessageBox.Show("Email encontrado y valido");
                }
                else
                {
                    MessageBox.Show("Email no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Email Invalido");
            }
        }

        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Valid_Click(object sender, RoutedEventArgs e)
        {

        }

        public static Boolean ValidateEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w +)*@\\w+([-.]\\w +)*\\.\\w+([-.]\\w +)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
