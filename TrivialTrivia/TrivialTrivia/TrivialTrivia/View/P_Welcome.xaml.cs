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
    public partial class P_Welcome : MasterDetailPage
    {
        public P_Welcome()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WelcomeMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.targetType);
            page.Title = item.title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}