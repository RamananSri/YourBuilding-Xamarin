using KundePortal.View;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    class MyUserViewModel
    {

        public ICommand QuestionsViewCommand { get; private set; }
        public ICommand CategoriesViewCommand { get; private set; }
        public ICommand AccountViewCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }

        INavigation nav; 

        public MyUserViewModel()
        {
            QuestionsViewCommand = new Command(NavigateToQuestions);
            CategoriesViewCommand = new Command(NavigateToCategories);
            AccountViewCommand = new Command(NavigateToAccount);
            LogOutCommand = new Command(LogOut);

            nav = Application.Current.MainPage.Navigation;
        }

        async void NavigateToQuestions()
        {
            await nav.PushAsync(new MyQuestionsView());
        }

        async void NavigateToCategories()
        {
            await nav.PushAsync(new CategoryView());
        }

        async void NavigateToAccount()
        {
            await nav.PushAsync(new ViewUserView());
        }

        async void LogOut()
        {
            APIService.currentUser = null;
            APIService.token = null;
            await nav.PopToRootAsync();       
        }
    }
}
