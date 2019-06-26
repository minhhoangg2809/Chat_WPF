using ChattingInterfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;

namespace IChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static IChattingService Server;
        private static DuplexChannelFactory<IChattingService> _channelfactory;
        public MainWindow()
        {
            InitializeComponent();

            _channelfactory = new DuplexChannelFactory<IChattingService>(new ClientCallback(), "ChattingServiceEndPoint");

            Server = _channelfactory.CreateChannel();

            btn_Send.Click += btn_Send_Click;
            btn_Login.Click += btn_Login_Click;
            btn_Logout.Click += btn_Logout_Click;
            btn_Update.Click += btn_Update_Click;

            this.Closed += MainWindow_Closed;
            this.DataContext = this;

        }

        void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text != string.Empty)
            {
                list_User.Children.Clear();
                LoadUserList(Server.GetCurrrentUserList());
            }
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            Server.Logout();
        }

        void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Server.Logout();

            btn_Login.IsEnabled = true;
            tb_Name.IsEnabled = true;
            tb_Name.Clear();

            txbMessage.Clear();

            try
            {
                Chat_Box.Children.Clear();
                list_User.Children.Clear();
            }
            catch (Exception) { };

        }

        void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text != string.Empty)
            {
                int i = Server.Login(tb_Name.Text);

                if (i == 1)
                {
                    MessageBox.Show("You are already login !!!");
                }
                else if (i == 0)
                {
                    MessageBox.Show("Welcom !!!");
                    tb_Name.IsEnabled = false;
                    btn_Login.IsEnabled = false;

                    LoadUserList(Server.GetCurrrentUserList());
                }
            }

        }

        void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (txbMessage.Text != string.Empty)
            {
                Server.SendtoAll(txbMessage.Text, tb_Name.Text);
                TakeMessage_sent(txbMessage.Text, "You");

                txbMessage.Clear();
                sc_chatbox.ScrollToBottom();

                list_User.Children.Clear();
                LoadUserList(Server.GetCurrrentUserList());
            }
        }

        public void TakeMessage_receive(string message, string username)
        {
            Chat_Box.Children.Add(new User_Control.Received(message, "@" + username));
            sc_chatbox.ScrollToBottom();

            list_User.Children.Clear();
            LoadUserList(Server.GetCurrrentUserList());
        }

        public void TakeMessage_sent(string message, string username)
        {
            Chat_Box.Children.Add(new User_Control.Sent(message, username));
        }


        private void LoadUserList(List<string> Friend)
        {
            foreach (string item in Friend)
            {
                list_User.Children.Add(new User_Control.ListViewItem(item));
            }
        }
    }
}
