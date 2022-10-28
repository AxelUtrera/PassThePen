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
    /// Lógica de interacción para Match.xaml
    /// </summary>
    public partial class Match : Window
    {
        

        public Match()
        {
            InitializeComponent();
        }

        private void Button_SetEraser_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 50;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 50;
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Button_SetColorGreen_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void Button_SetColorBlue_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void Button_SetColorRed_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void Button_SetColorBlack_Click(object sender, RoutedEventArgs e)
        {
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Color = Colors.Black;
        }
    }
}
