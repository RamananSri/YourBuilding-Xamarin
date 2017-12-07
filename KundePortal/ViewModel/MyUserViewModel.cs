using KundePortal.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    class MyUserViewModel
    {

        public ICommand QuestionsViewCommand { get; set; }
        public ICommand CategoriesViewCommand { get; set; }
        public ICommand AccountViewCommand { get; set; }

        public MyUserViewModel()
        {
            QuestionsViewCommand = new Command(NavigateToQuestions);
            CategoriesViewCommand = new Command(NavigateToCategories);
            AccountViewCommand = new Command(NavigateToAccount);
        }

        async void NavigateToQuestions()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new MyQuestionsView());
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

    }
}
