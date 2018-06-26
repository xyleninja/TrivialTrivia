using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrivialTrivia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class P_WelcomeMaster : ContentPage
    {
        public ListView ListView;

        public P_WelcomeMaster()
        {
            InitializeComponent();

            BindingContext = new WelcomeMasterViewModel();
            ListView = MenuItemsListView;
        }
    }
}