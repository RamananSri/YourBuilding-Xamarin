using System;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProMenuViewModel
    {
        public ICommand MessageViewCommand { get; set; }
        public ICommand QuestionsViewCommand { get; set; }
        public ICommand GPSViewCommand { get; set; }
        public ICommand CategoriesViewCommand { get; set; }
        public ICommand viewUserCommand { get; set; }

        public ProMenuViewModel()
        {
            MessageViewCommand = new Command(NavigateToMessages);
            QuestionsViewCommand = new Command(NavigateToQuestions);
            GPSViewCommand = new Command(NavigateToGPS);
            CategoriesViewCommand = new Command(NavigateToCategories);
            viewUserCommand = new Command(ViewUser);
        }

        async void ViewUser()
        {
                INavigation nav = Application.Current.MainPage.Navigation;
                await nav.PushAsync(new ViewUserView());
        }

        async void NavigateToMessages()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ProNotificationsView());
        }

        async void NavigateToQuestions()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new CategoryView());
        }

        async void NavigateToGPS()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ProGPSView());
        }

        async void NavigateToCategories()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ProMyCategoriesView());
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
