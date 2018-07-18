using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TrivialTrivia
{
    public class WelcomeMasterViewModel : BaseViewModel
    {
        public ObservableCollection<WelcomeMenuItem> menuItems { get; set; }

        public WelcomeMasterViewModel()
        {
            //Check also switch case in P_Welcome.xaml.cs if it containts the cases for each targetType.
            menuItems = new ObservableCollection<WelcomeMenuItem>(new[]
            {
                    new WelcomeMenuItem { id = 0, title = "Welcome", targetType=typeof(P_WelcomeDetail) },
                });
        }
    }
}
