using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para Match.xaml
    /// </summary>
    public partial class Match : Window, IMatchManagementCallback, IChatServicesCallback
    {

        DispatcherTimer timer = new DispatcherTimer();
        private int selectedTime;
        Dictionary<string, int> playerScore;


        public Match()
        {
            InitializeComponent();
            SetChatOperationContext(MainMenu.username);
            SetMatchOperationContext(MainMenu.username);
            SetPlayersScoreTable();
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

        private void ObtainCard()
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(instanceContext);

            var random = new Random();
            int numberCard = random.Next(1, 100);

            ResourceManager resource = new ResourceManager("PassThePen.Properties.Deck", Assembly.GetExecutingAssembly());
            string card = resource.GetString("Card" + numberCard);

            client.SendCard(card);

        }

        public void DistributeCard(string card)
        {
            Label_CurrentDraw.Content = card;
        }


        private void Button_SendMessage_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.ChatServicesClient client = new ChatServicesClient(context);

            string username = MainMenu.username;
            String message = TextBox_Message.Text;
            if(message != "")
            {
                TextBox_Message.Clear();
                client.SendMessage(username, message);
            }


        }

        public void MessageSend(string message)
        {
            ListBox_ChatBox.Items.Add(message);
        }


        private void Button_StartTurn_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new MatchManagementClient(instanceContext);
            client.StartTurnSignal(MainMenu.username);
        }

        private void StartTurn()
        {
            SetPlayersScoreTable();
            InkCanvas_DrawTable.Strokes.Clear();
            ObtainCard();
            ObtainTurnTime();
            StartTurnTimer();
        }

        private void ObtainTurnTime()
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new MatchManagementClient(context);
            client.SelectTurnTime();
        }

        public void DistributeTurnTime(int turnTime)
        {
            selectedTime = turnTime;
        }

        private void StartTurnTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (selectedTime == 0)
            {
                timer.Stop();
                SendDraw();
                
            }
            Label_TimeRemaining.Content = selectedTime;
            selectedTime--;
        }


        public void ReturnStartTurnSignal(int turnNumber)
        {
            Label_TurnNumber.Content = turnNumber;
            StartTurn();
        }


        private byte[] GetCanvasDraw()
        {
            //get the dimensions of the ink control
            int margin = (int) InkCanvas_DrawTable.Margin.Right;
            int width = (int) InkCanvas_DrawTable.ActualWidth - margin;
            int height = (int) InkCanvas_DrawTable.ActualHeight - margin;

            //render ink to bitmap
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
            rtb.Render(InkCanvas_DrawTable);

            //save the ink to a memory stream
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            byte[] bitmapBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);

                //get the bitmap bytes from the memory stream
                ms.Position = 0;
                bitmapBytes = ms.ToArray();
            }

            return bitmapBytes;
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

        private void SendDraw()
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new MatchManagementClient(context);

            Byte[] playerDraw = GetCanvasDraw();

            client.SendDraws(MainMenu.username, playerDraw);
        }


        public void SetChatOperationContext(string username)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.ChatServicesClient client = new PassThePenService.ChatServicesClient(instanceContext);
            client.SetChatOperationContext(username);
        }

        public void SetMatchOperationContext(string username)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(instanceContext);
            client.SetMatchOperationContext(username);
        }

        public void DistributeDraws(Dictionary<string, byte[]> playersDraw)
        {
            DrawReview.playersDraw = playersDraw;
            DrawReview drawReview = new DrawReview();
            drawReview.Show();
        }

        public void SetPlayersScoreTable()
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);
            playerScore = client.GetPlayersScore();

            ListBox_PlayersInGame.Items.Clear();
            foreach(KeyValuePair<string, int> player in playerScore)
            {
                if (player.Key.Equals(MainMenu.username))
                {
                    Label_Score.Content = player.Value;
                }
                else
                {
                    ListBox_PlayersInGame.Items.Add(player.Key + "  Score: " + player.Value);
                }
            }
        }

        public void NotifyWinner(string winner)
        {
            MessageBox.Show("El ganador de la partida es: " + winner, "", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("La partida ha terminado, regresando al menu principal", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
