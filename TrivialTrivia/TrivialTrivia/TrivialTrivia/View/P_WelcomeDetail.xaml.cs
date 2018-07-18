using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrivialTrivia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class P_WelcomeDetail : ContentPage
    {
        public P_WelcomeDetail()
        {
            InitializeComponent();
        }

        private void b_join_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(App.searchLobbyPage);
        }

        private void b_create_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(App.lobbyPage);
        }
    }
}