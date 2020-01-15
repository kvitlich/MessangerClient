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
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace ClientMessanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string DestIpAddress = "192.168.8.109";
        private int DestPort = 8080;
        public MainWindow()
        {
            InitializeComponent();
            // "свойАйДи свойПорт егоАйди егоПорт своеИмя своеСообщение"
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            Message newMessage = new Message
            {
                Text = message.Text,
                Nickname = userName.Text,
                FromIp = "192.168.8.109",
                FromPort = "8080",
            };
            sendMessage.IsEnabled = false;
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var endPoint = new IPEndPoint(IPAddress.Parse(DestIpAddress), DestPort);
                //var endPoint = new IPEndPoint(IPAddress.Parse("10.1.4.46"), 3231);
                socket.Connect(endPoint);
                if (newMessage.Text != String.Empty)
                {

                    var buffer = System.Text.Encoding.UTF8.GetBytes($"{newMessage.Nickname}|{newMessage.Text}");
                    socket.Send(buffer);
                  //  socket.Shutdown(SocketShutdown.Both);
                }
            }

            sendMessage.IsEnabled = true;
        }
    }
}
