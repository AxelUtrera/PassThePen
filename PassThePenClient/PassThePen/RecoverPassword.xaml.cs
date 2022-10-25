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
    
    public partial class RecoverPassword : Window
    {
        public RecoverPassword()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            String emailCodigo = texBox_emailCodigo.Text;            
            if (ValidateEmail(texBox_emailCodigo.Text))
            {
                PassThePenService.PlayerMgtClient client = new PassThePenService.PlayerMgtClient();
                if (client.AutenticateEmail(emailCodigo) == 200)
                {
                    Random randomNumber = new Random();
                    int validationCode = randomNumber.Next(100000, 1000000);
                    String affair = "New Validation Code";
                    if(client.CodeEmail(emailCodigo, affair, validationCode) == 200)
                    {
                        MessageBox.Show("Corrreo Enviado");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo enviar el codigo");
                    }
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
