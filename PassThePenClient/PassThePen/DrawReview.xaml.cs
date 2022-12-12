using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para DrawReview.xaml
    /// </summary>
    public partial class DrawReview : Window
    {
        public static Dictionary<string, byte[]> playersDraw { get; set; }
        private Dictionary<string, int> _playersScore = new Dictionary<string, int>();
        private int _drawCount = 0;
        private LogClient _log = new LogClient();
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());


        public DrawReview()
        {
            InitializeComponent();
            SetPlayersDraw();
            SetDrawReviewContext(MainMenu.username);
        }


        private void Button_SendReview_Click(object sender, RoutedEventArgs e)
        {
            string username = Label_PlayerReview.Content.ToString();
            int score = (int)Rating_DrawReview.Value;
            _playersScore.Add(username, score);
            if(_drawCount < playersDraw.Count - 1)
            {
                _drawCount++;
                SetPlayersDraw();
            }
            else
            {
                AddPlayerScore(_playersScore);
                this.Close();
            }
        }


        private void SetPlayersDraw()
        {
            Label_PlayerReview.Content = playersDraw.ElementAt(_drawCount).Key;
            Image_ReviewDraw.Source = ImageManager.ByteToImage(playersDraw.ElementAt(_drawCount).Value);
            Rating_DrawReview.Value = 0;
        }


        private void SetDrawReviewContext(String username)
        {
            try
            {
                PassThePenService.DrawReviewServiceClient client = new PassThePenService.DrawReviewServiceClient();
                client.SetDrawReviewContext(username);
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

        public void AddPlayerScore(Dictionary<string, int> playerScore)
        {
            try
            {
                PassThePenService.DrawReviewServiceClient client = new PassThePenService.DrawReviewServiceClient();
                client.AddPlayerScore(playerScore);
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
    }
}
