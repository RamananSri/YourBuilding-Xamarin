using System;
using System.Windows.Input;
using KundePortal.Utility;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProMenuViewModel
    {
        public ICommand QuestionsViewCommand { get; set; }
        //public ICommand GPSViewCommand { get; set; }
        public ICommand CategoriesViewCommand { get; set; }
        public ICommand viewUserCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        INavigation nav;

        public ProMenuViewModel()
        {
            QuestionsViewCommand = new Command(NavigateToQuestions);
            CategoriesViewCommand = new Command(NavigateToCategories);
            viewUserCommand = new Command(ViewUser);
            LogOutCommand = new Command(LogOut);
            nav = Application.Current.MainPage.Navigation;
        }

        async void ViewUser()
        {
            await nav.PushAsync(new ViewUserView());
        }

        async void NavigateToQuestions()
        {
            await nav.PushAsync(new CategoryView());
        }

        async void NavigateToCategories()
        {
            await nav.PushAsync(new ProMyCategoriesView());
        }

        async void LogOut()
        {
            APIService.currentUser = null;
            APIService.token = null;
            await nav.PopToRootAsync();
        }

        //async void Navigate(string caller)
        //{
        //    INavigation nav = Application.Current.MainPage.Navigation;

        //    switch (caller)
        //    {
        //        case "Beskeder":
        //            await nav.PushAsync(new ProNotificationsView());
        //            break;
        //        case "Alle spørgsmål":
        //            await nav.PushAsync(new ProAllQuestionsView());
        //            break;
        //        case "I nærheden":
        //            await nav.PushAsync(new ProGPSView());
        //            break;
        //        case "Kategorier":
        //            await nav.PushAsync(new ProMyCategoriesView());
        //            break;

        //    }
        //}
    }
}
