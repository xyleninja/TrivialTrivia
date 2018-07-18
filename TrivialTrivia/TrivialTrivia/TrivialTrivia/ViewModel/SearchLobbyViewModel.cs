using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TrivialTrivia
{
    public class SearchLobbyViewModel : BaseViewModel
    {
        private bool p_isBusy;

        public ObservableCollection<HostingLobbyInformation> hostingLobbies { get; set; } = new ObservableCollection<HostingLobbyInformation>();
        public bool isBusy
        {
            get { return p_isBusy; }
            set
            {
                p_isBusy = value;
                OnPropertyChanged("isBusy");
            }
        }
    }
}
