using System;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    public class ProMenuViewModel
    {
        string _username;

        public ICommand SubsViewCommand { get; set; }
        public ICommand CategoryViewCommand { get; set; }
        public ICommand AccountViewCommand { get; set; }

        public ProMenuViewModel()
        {
            _username = APIService.currentUser.name;
            SubsViewCommand = new Command(NavigateToSubs);
            CategoryViewCommand = new Command(NavigateToCategories);
            AccountViewCommand = new Command(NavigateToAccount);
        }

        async void NavigateToSubs()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ProMyCategoriesView());
        }

        async void NavigateToCategories()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new CategoryView());
        }

        async void NavigateToAccount()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ViewUserView());
        }
        #region Properties

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        #endregion
    }
}