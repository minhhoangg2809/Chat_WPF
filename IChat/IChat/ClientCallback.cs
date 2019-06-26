using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChattingInterfaces;
using System.Windows;

namespace IChat
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallback : IClient
    {

        public void GetMessage(string message, string username)
        {
            ((MainWindow)Application.Current.MainWindow).TakeMessage_receive(message, username);
        }

    }
}
