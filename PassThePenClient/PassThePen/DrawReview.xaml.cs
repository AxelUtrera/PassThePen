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
    /// Lógica de interacción para DrawReview.xaml
    /// </summary>
    public partial class DrawReview : Window
    {
        public static byte[] bytes { get; set; }


        public DrawReview()
        {
            InitializeComponent();
            Image_ReviewDraw.Source = ConvertByteToImage(bytes);
        }



        public BitmapImage ConvertByteToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void Button_SendReview_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)Rating_DrawReview.Value;
            MessageBox.Show("Puntuacion: " + value);
        }
    }
}
