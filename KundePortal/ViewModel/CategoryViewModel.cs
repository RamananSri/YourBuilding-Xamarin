using System.Collections.ObjectModel;
using KundePortal.Services;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;
using System.Collections.Generic;

namespace KundePortal.ViewModel
{
    public class CategoryViewModel
    {
        public static string parentCategory;
        QuestionService qs;
        bool isSubCategory;
        ObservableCollection<string> _allCategories;

        public CategoryViewModel()
        {
            qs = new QuestionService();
            _allCategories = new ObservableCollection<string>();

            if (parentCategory != null)
            {
                isSubCategory = true;
                GetCategories(parentCategory);
            }
            else {
                isSubCategory = false;
                GetCategories("Main");
            }

            AccountCommand = new Command(NavigateAccount);
        }

        async void GetCategories(string category)
        {
            List<string> categories = await qs.GetCategories(category);
            foreach (var item in categories)
            {
                _allCategories.Add(item);
            }
        }

        async void Navigate()
        {
            if(isSubCategory){
                await Application.Current.MainPage.Navigation.PushAsync(new AllQuestionsView());
            }
            else{
                await Application.Current.MainPage.Navigation.PushAsync(new CategoryView());
            }
        }

        async void NavigateAccount(){
            await Application.Current.MainPage.Navigation.PushAsync(new ViewUserView());
        }

        public string MainCategory
        {
            get
            {   
                return parentCategory;
            }
            set
            {
                
                parentCategory = value;

                if(parentCategory != null){
                    Navigate();
                }
            }
        }

        public ObservableCollection<string> AllCategories
        {
            get
            {
                return _allCategories;
            }
            set
            {
                _allCategories = value;
            }
        }

        public bool IsSubCategory
        {
            get
            {
                return isSubCategory;
            }
            private set
            {
                isSubCategory = value;
            }
        }

        public ICommand AccountCommand { get; private set; }
    }
}