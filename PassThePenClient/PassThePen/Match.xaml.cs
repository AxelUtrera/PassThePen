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
        private DispatcherTimer _timer = new DispatcherTimer();
        private int _selectedTime;
        private Dictionary<string, int> _playerScore;
        private string _username = MainMenu.username;
        private Boolean _hostState;
        private LogClient _log = new LogClient();

        public Match()
        {
            InitializeComponent();
            SetHostState(_username);
            SetChatOperationContext(_username);
            SetMatchOperationContext(_username);
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
            ChangePencilColor(Colors.Green);
        }


        private void Button_SetColorBlue_Click(object sender, RoutedEventArgs e)
        {
            ChangePencilColor(Colors.Blue);
        }


        private void Button_SetColorRed_Click(object sender, RoutedEventArgs e)
        {
            ChangePencilColor(Colors.Red);
        }


        private void Button_SetColorBlack_Click(object sender, RoutedEventArgs e)
        {
            ChangePencilColor(Colors.Black);
        }


        private void ChangePencilColor(Color color)
        {
            InkCanvas_DrawTable.EditingMode = InkCanvasEditingMode.Ink;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Width = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Height = 5;
            InkCanvas_DrawTable.DefaultDrawingAttributes.Color = color;
        }


        private void ObtainCard()
        {
            try
            {
                
                InstanceContext instanceContext = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(instanceContext);
                ResourceManager cardResource = new ResourceManager("PassThePen.Properties.Deck", Assembly.GetExecutingAssembly());
                var random = new Random();
                int numberCard = random.Next(1, 100);
                string card  = cardResource.GetString("Card" + numberCard);

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
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
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

                string usernameSend = _username;
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
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
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
                if (_hostState)
                {
                    InstanceContext instanceContext = new InstanceContext(this);
                    PassThePenService.MatchManagementClient client = new MatchManagementClient(instanceContext);
                    client.StartTurnSignal(_username);
                }
                else
                {
                    MessageBox.Show(messageResource.GetString("Match_NotHostTurn_Message"), "", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
            }
        }


        public void DistributeTurnTime(int turnTime)
        {
            _selectedTime = turnTime;
        }


        private void StartTurnTimer()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick -= Timer_Tick;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_selectedTime == 0)
            {
                _timer.Stop();
                SendDraw();
            }
            Label_TimeRemaining.Content = _selectedTime;
            _selectedTime--;
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


        private void SendDraw()
        {
            try
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new MatchManagementClient(context);
                Byte[] playerDraw = GetCanvasDraw();
                client.SendDraws(_username, playerDraw);
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
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
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
                _log.Add(ex.ToString());
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(messageResource.GetString("Global_Timeout_Message"));
                _log.Add(ex.ToString());
            }
        }


        public void DistributeDraws(Dictionary<string, byte[]> playersDraw)
        {
            playersDraw.Remove(_username);
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
                _playerScore = client.GetPlayersScore();

                int score = _playerScore.First(u => u.Key == _username).Value;
                Label_Score.Content = score.ToString();
                _playerScore.Remove(_username);
                ListBox_PlayersInGame.ItemsSource = _playerScore;
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


        public void NotifyWinner(string winner)
        {
            MessageBox.Show(messageResource.GetString("Mach_MatchWinner_Message") + winner, "", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show(messageResource.GetString("Match_MatchOver_Message"), "", MessageBoxButton.OK, MessageBoxImage.Information);
            OpenMainMenu();
        }


        private void OpenMainMenu()
        {
            _timer.Stop();
            
            foreach (Window window in App.Current.Windows)

            {
                if (!window.IsActive)
                {
                    window.Show();
                }
            }
            Close();
        }


        private void Button_RemoveMatchPlayer_Click(object sender, MouseButtonEventArgs e)
        {
            if (_hostState)
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
                _hostState = client.GetHostState(username);
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

        private void Button_LeaveMatch_Click(object sender, RoutedEventArgs e)
        {
            var confirmationButton = MessageBox.Show(messageResource.GetString("Match_LeaveMatch_Message"), "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(confirmationButton == MessageBoxResult.Yes)
            {
                InstanceContext context = new InstanceContext(this);
                PassThePenService.MatchManagementClient client = new PassThePenService.MatchManagementClient(context);

                client.LeaveMatch(_username);
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