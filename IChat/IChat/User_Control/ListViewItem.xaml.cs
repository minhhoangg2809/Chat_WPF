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
    /// Interaction logic for ListViewItem.xaml
    /// </summary>
    public partial class ListViewItem : UserControl
    {
        private string _Friend;

        public string Friend
        {
            get { return _Friend; }
            set { _Friend = value; }
        }

        public ListViewItem()
        {
            InitializeComponent();
        }

        public ListViewItem(string Friend)
        {
            this.Friend = Friend;

            InitializeComponent();
            this.DataContext = this;
        }
    }
}
