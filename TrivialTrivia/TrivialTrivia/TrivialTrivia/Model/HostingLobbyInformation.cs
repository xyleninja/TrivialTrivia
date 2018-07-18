using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TrivialTrivia
{
    public class HostingLobbyInformation
    {
        public string designation { get; set; }
        public string hostIp { get; set; }
        public int conntectedPlayers { get; set; }
        public int maximumPlayers { get; set; }
        public bool isHosting { get; set; }
    }
}
