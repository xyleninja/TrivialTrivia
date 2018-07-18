using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Threading;

namespace TrivialTrivia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class P_Lobby : CarouselPage
    {
        public bool isHosting { get; set; } = false;

        public P_Lobby()
        {
            InitializeComponent();

            BindingContext = new LobbyViewModel();

            startHosting();
        }

        public async void startHosting()
        {
            isHosting = true;
            UdpClient client = new UdpClient();
            client.EnableBroadcast = true;
            IPEndPoint targetIp = new IPEndPoint(IPAddress.Broadcast, 2504);

            do
            {

                string lobbyDesignation = (BindingContext as LobbyViewModel).lobbyName;
                string lobbyIp = "";
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || item.NetworkInterfaceType == NetworkInterfaceType.Ethernet && item.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                lobbyIp = ip.Address.ToString();
                            }
                        }
                    }
                }
                int lobbyConnectedPlayer = 0;
                foreach (Player player in (BindingContext as LobbyViewModel).lobbyPlayers)
                {
                    if (player.name != null)
                    {
                        lobbyConnectedPlayer++;
                    }
                }
                int lobbyMaximumPlayers = (BindingContext as LobbyViewModel).lobbyMaximumPlayers;

                var data = new HostingLobbyInformation
                {
                    designation = lobbyDesignation,
                    hostIp = lobbyIp,
                    conntectedPlayers = lobbyConnectedPlayer,
                    maximumPlayers = lobbyMaximumPlayers,
                    isHosting = isHosting,
                };

                byte[] bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data));
                client.Send(bytes, bytes.Length, targetIp);
                await Task.Run(() => { Thread.Sleep(10000); });

            }
            while (isHosting);

            client.Close();
        }
    }
}