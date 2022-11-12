using PassThePen.PassThePenService;
using System;
using System.Collections.Generic;
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
        private Boolean hostState = true;

        public Match()
        {
            InitializeComponent();
            if (!hostState)
            {
                Button_StartTurn.IsEnabled = false;
            }
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
            MessageBox.Show(card);
            Label_CurrentDraw.Content = card;
        }


        private void Button_SendMessage_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            PassThePenService.ChatServicesClient client = new ChatServicesClient(context);

            string username = MainMenu.username;
            String message = TextBox_Message.Text;
            TextBox_Message.Clear();
            client.SendMessage(username, message);

        }

        public void MessageSend(string message)
        {
            ListBox_ChatBox.Items.Add(message);
        }


        private void Button_StartTurn_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            PassThePenService.MatchManagementClient client = new MatchManagementClient(instanceContext);
            client.StartTurnSignal();
        }

        private void StartTurn()
        {
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
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (selectedTime == 0)
            {
                timer.Stop();
            }
            Label_TimeRemaining.Content = selectedTime;
            selectedTime--;
        }

        public void ReturnStartTurnSignal()
        {
            StartTurn();
        }
    }
}
