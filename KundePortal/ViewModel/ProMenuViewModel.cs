using System;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProMenuViewModel
    {
        public ICommand MessageViewCommand { get; set; }
        //public ICommand SearchViewCommand { get; set; }
        public ICommand GPSViewCommand { get; set; }
        public ICommand CategoriesViewCommand { get; set; }

        public ProMenuViewModel()
        {
            MessageViewCommand = new Command<string>(Navigate);
            //SearchViewCommand = new Command<string>(Navigate);
            GPSViewCommand = new Command<string>(Navigate);
            CategoriesViewCommand = new Command<string>(Navigate);
        }

        async void Navigate(string caller)
        {
            INavigation nav = Application.Current.MainPage.Navigation;

            switch (caller)
            {
                case "Beskeder":
                    await nav.PushAsync(new ProNotificationsView());
                    break;
                //case "Søg":
                    //await nav.PushAsync();
                    //break;
                case "I nærheden":
                    await nav.PushAsync(new ProGPSView());
                    break;
                case "Kategorier":
                    await nav.PushAsync(new ProMyCategoriesView());
                    break;

            }
        }
    }
}
