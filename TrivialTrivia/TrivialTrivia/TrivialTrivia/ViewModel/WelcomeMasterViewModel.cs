using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TrivialTrivia
{
    class WelcomeMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WelcomeMenuItem> menuItems { get; set; }

        public WelcomeMasterViewModel()
        {
            menuItems = new ObservableCollection<WelcomeMenuItem>(new[]
            {
                    new WelcomeMenuItem { id = 0, title = "Welcome", targetType=typeof(P_WelcomeDetail) },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
