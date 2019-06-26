using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChattingInterfaces;
using System.Collections.Concurrent;

namespace ChattingServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChattingService : IChattingService
    {
        public ConcurrentDictionary<string, ConnectedClient> _connectedClients = new ConcurrentDictionary<string, ConnectedClient>();

        public int Login(string username)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() == username.ToLower())
                {
                    return 1;
                }
            }

            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            ConnectedClient newClient = new ConnectedClient();
            newClient.connection = establishedUserConnection;
            newClient.UserName = username;

            _connectedClients.TryAdd(username, newClient);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Client login !!!" + " UserName : " + newClient.UserName + " _" + DateTime.Now);
            Console.ResetColor();

            return 0;
        }

        public void Logout()
        {
            var client = getClient();

            if (client != null)
            {
                ConnectedClient removedClient;
                _connectedClients.TryRemove(client.UserName, out removedClient);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Client logout !!!" + " UserName : " + removedClient.UserName + " _" + DateTime.Now);
                Console.ResetColor();
            }
        }


        public ConnectedClient getClient()
        {
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            foreach (var client in _connectedClients)
            {
                if (client.Value.connection == establishedUserConnection)
                {
                    return client.Value;
                }
            }

            return null;
        }

        public void SendtoAll(string message, string username)
        {
            foreach (var client in _connectedClients)
            {
                if (client.Key.ToLower() != username.ToLower())
                {
                    client.Value.connection.GetMessage(message, username);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(username + " chat : /* " + message + " */ _" + DateTime.Now + "/**/");
            Console.ResetColor();
        }



        public List<string> GetCurrrentUserList()
        {
            List<string> list_User = new List<string>();

            foreach (var item in _connectedClients)
            {
                list_User.Add(item.Value.UserName);
            }

            return list_User;
        }
    }
}
