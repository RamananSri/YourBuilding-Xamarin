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
        public static string _childCategory;
        public static string _parentCategory;
        QuestionService qs;
        bool isSubCategory;
        ObservableCollection<string> _allCategories;

        public CategoryViewModel()
        {
            qs = new QuestionService();
            _allCategories = new ObservableCollection<string>();
            AccountCommand = new Command(NavigateAccount);
            determineCategoryType();
        }

        // Show main or sub logic
        void determineCategoryType(){
            if (_childCategory != null)
            {
                _parentCategory = _childCategory;
                isSubCategory = true;
                GetCategories(_childCategory);
            }
            else
            {
                isSubCategory = false;
                GetCategories("Main");
            }
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

        #region Properties

        public string SelectedCategory
        {
            get
            {   
                return _childCategory;
            }
            set
            {
                _childCategory = value;

                if (_childCategory != null)
                {
                    Navigate();
                    return;
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

        #endregion
    }
}