using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrivialTrivia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class P_Welcome : MasterDetailPage
    {
        private P_WelcomeMaster MasterPage = App.welcomeMasterPage;

        public P_Welcome()
        {
            InitializeComponent();

            Master = MasterPage;

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MasterPage.ListView.SelectedItem = (from wmi in (MasterPage.ListView.ItemsSource as ObservableCollection<WelcomeMenuItem>) where wmi.id == 0 select wmi).FirstOrDefault();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WelcomeMenuItem;
            if (item == null)
                return;

            Page page;

            switch (item.targetType.Name)
            {
                case "P_Lobby":
                    page = App.lobbyPage;
                    break;
                case "P_SearchLobby":
                    page = App.searchLobbyPage;
                    break;
                case "P_WelcomeDetail":
                default:
                    page = App.welcomeDetailPage;
                    break;
            }

            page.Title = item.title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}