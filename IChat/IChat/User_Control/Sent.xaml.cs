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

namespace IChat.User_Control
{
    /// <summary>
    /// Interaction logic for Sent.xaml
    /// </summary>
    public partial class Sent : UserControl
    {
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public Sent()
        {
            InitializeComponent();
        }

        public Sent(string Text, string Username)
        {
            this.Text = Text;
            this.Username = Username;

            InitializeComponent();
            this.DataContext = this;
        }
    }
}
