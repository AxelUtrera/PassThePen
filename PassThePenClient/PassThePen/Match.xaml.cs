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
        ResourceManager messageResource = new ResourceManager("PassThePen.Properties.Resources", Assembly.GetExecutingAssembly());
        DispatcherTimer timer = new DispatcherTimer();
        private int selectedTime;
        Dictionary<string, int> playerScore;
        string username = MainMenu.username;
        Boolean hostState;
        private LogClient log = new LogClient();

        public Match()
        {
            InitializeComponent();
            SetHostState(username);
            SetChatOperationContext(MainMenu.username);
            SetMatchOperationContext(MainMenu.username);
            SetPlayersScoreTable();
            Console.WriteLine(App.Current.Windows.Count);
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
            try
            {
                string card;
                InstanceContext instanceContext = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(instanceContext);

                var random = new Random();
                int numberCard = random.Next(1, 100);

                ResourceManager cardResource = new ResourceManager("PassThePen.Properties.Deck", Assembly.GetExecutingAssembly());
                card = cardResource.GetString("Card" + numberCard);

                if (card.Equals("Reto") || card.Equals("Challenge"))
                {
                    int challengeNumber = random.Next(1, 10);
                    ResourceManager challengeResource = new ResourceManager("PassThePen.Properties.Challenge", Assembly.GetExecutingAssembly());
                    card = challengeResource.GetString("Challenge" + challengeNumber);
                }

                client.SendCard(card);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }

        public void DistributeCard(string card)
        {
            Label_CurrentDraw.Text = card;
        }


        private void Button_SendMessage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.ChatServicesClient client = new ChatServicesClient(context);

                string usernameSend = MainMenu.username;
                string message = TextBox_Message.Text;
                if (message != "")
                {
                    TextBox_Message.Clear();
                    client.SendMessage(usernameSend, message);
                }
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }

        public void MessageSend(string message)
        {
            ListBox_ChatBox.Items.Add(message);
        }


        private void Button_StartTurn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hostState)
                {
                    InstanceContext instanceContext = new InstanceContext(this);
                    PassThePenService.MatchManagementClient client = new MatchManagementClient(instanceContext);
                    client.StartTurnSignal(MainMenu.username);
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("Match_NotHostTurn_Message"), "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
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
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new MatchManagementClient(context);
                client.SelectTurnTime();
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
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
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new MatchManagementClient(context);
                Byte[] playerDraw = GetCanvasDraw();
                client.SendDraws(MainMenu.username, playerDraw);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }



        public void SetChatOperationContext(string username)
        {
            try
            {
                InstanceContext instanceContext = new InstanceContext(this);
                PassThePenService.ChatServicesClient client = new PassThePenService.ChatServicesClient(instanceContext);
                client.SetChatOperationContext(username);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }


        public void SetMatchOperationContext(string username)
        {
            try
            {
                InstanceContext instanceContext = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(instanceContext);
                client.SetMatchOperationContext(username);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }


        public void DistributeDraws(Dictionary<string, byte[]> playersDraw)
        {
            playersDraw.Remove(username);
            DrawReview.playersDraw = playersDraw;
            DrawReview drawReview = new DrawReview();
            drawReview.ShowDialog();
        }


        public void SetPlayersScoreTable()
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);
                playerScore = client.GetPlayersScore();

                int score = playerScore.First(u => u.Key == username).Value;
                Label_Score.Content = score.ToString();
                playerScore.Remove(username);
                ListBox_PlayersInGame.ItemsSource = playerScore;
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }


        public void NotifyWinner(string winner)
        {
            MessageBox.Show(messageResource.GetString("Mach_MatchWinner_Message") + winner, "", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show(messageResource.GetString("Match_MatchOver_Message"), "", MessageBoxButton.OK, MessageBoxImage.Information);
            OpenMainMenu();
        }


        private void OpenMainMenu()
        {
            timer.Stop();
            
            foreach (Window window in App.Current.Windows)

            {
                if (!window.IsActive)
                {
                    window.Show();
                }
            }
            Close();
        }


        private void Button_Remove_Match_Player_Click(object sender, MouseButtonEventArgs e)
        {
            if (hostState)
            {
                var confirmationButton = MessageBox.Show(messageResource.GetString("Match_RemovePlayer_Message"), "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmationButton == MessageBoxResult.Yes)
                {
                    Image buttonRemovePlayer = (Image)sender;
                    StackPanel parent = (StackPanel)buttonRemovePlayer.Parent;
                    var playerToRemove = (KeyValuePair<string, int>)parent.DataContext;

                    InstanceContext context = new InstanceContext(this);
                    PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);
                    client.RemoveMatchPlayer(playerToRemove.Key);
                }
            }
            else
            {
                MessageBox.Show(messageResource.GetString("Match_NotHostRemove_Message"));
            }
            
        }

        private void SetHostState(string username)
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);
                hostState = client.GetHostState(username);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_ServerError_Message"));
                log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                log.Add(ex.ToString());
            }
        }

        private void Button_Leave_Match_Click(object sender, RoutedEventArgs e)
        {
            var confirmationButton = MessageBox.Show(messageResource.GetString("Match_LeaveMatch_Message"), "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(confirmationButton == MessageBoxResult.Yes)
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);

                client.LeaveMatch(username);
            }
        }

        public void UpdateMatchPlayers()
        {
            SetPlayersScoreTable();
        }

        public void CloseMatchWindow()
        {
            OpenMainMenu();
        }
    }
}