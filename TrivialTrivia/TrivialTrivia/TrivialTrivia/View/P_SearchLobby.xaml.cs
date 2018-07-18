using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace TrivialTrivia
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class P_SearchLobby : ContentPage
	{
        private UdpClient udp;
        private SearchLobbyViewModel searchLobbyViewModel;
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, 2504);

        private const int SEARCH_INTERVAL = 10000;

		public P_SearchLobby ()
		{
			InitializeComponent ();

            BindingContext = searchLobbyViewModel = new SearchLobbyViewModel();
		}

        private async void startListening(DateTime dateTime)
        {
            if (searchLobbyViewModel.isBusy)
                return;

            searchLobbyViewModel.hostingLobbies.Clear();

            searchLobbyViewModel.isBusy = true;
            udp = new UdpClient(2504);
            udp.EnableBroadcast = true;
            IAsyncResult ar = udp.BeginReceive(OnReceive, dateTime);
            await Task.Run(()=> { Thread.Sleep(SEARCH_INTERVAL); });
            udp.Close();
            searchLobbyViewModel.isBusy = false;

            if (searchLobbyViewModel.hostingLobbies.Count == 0)
            {
                if(await DisplayAlert("No lobbies found.", "There are currently no available lobbies\nDo you like to host one?", "Yes", "No"))
                {
                    await Navigation.PushAsync(new P_Lobby());
                }
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            DateTime dateTime = (DateTime)ar.AsyncState;

            if (DateTime.Now.Subtract(dateTime).TotalMilliseconds > SEARCH_INTERVAL ||
                udp.Client == null)
            {
                return;
            }
            
            byte[] bytes = udp.EndReceive(ar, ref ip);
            HostingLobbyInformation hostingLobbyInformation = JsonConvert.DeserializeObject<HostingLobbyInformation>(Encoding.ASCII.GetString(bytes));

            if (hostingLobbyInformation.isHosting)
            {
                var hostingLobby = (from hl in searchLobbyViewModel.hostingLobbies where hl.hostIp == hostingLobbyInformation.hostIp select hl).FirstOrDefault();
                if (hostingLobby == null)
                {
                    searchLobbyViewModel.hostingLobbies.Add(hostingLobbyInformation);
                }
                else if (!hostingLobbyInformation.Equals(hostingLobby))
                {
                    searchLobbyViewModel.hostingLobbies.Remove(hostingLobby);
                    searchLobbyViewModel.hostingLobbies.Add(hostingLobbyInformation);
                }
            }
            else
            {
                var hostingLobby = (from hl in searchLobbyViewModel.hostingLobbies where hl.hostIp == hostingLobbyInformation.hostIp select hl).FirstOrDefault();
                if (hostingLobby != null)
                {
                    searchLobbyViewModel.hostingLobbies.Remove(hostingLobby);
                }
            }

            udp.BeginReceive(OnReceive, dateTime);
        }

        private void b_refresh_Clicked(object sender, EventArgs e)
        {
            startListening(DateTime.Now);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            startListening(DateTime.Now);
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            udp.Close();
        }
    }
}