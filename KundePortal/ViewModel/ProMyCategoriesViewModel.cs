using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KundePortal.Services;
using KundePortal.Utility;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProMyCategoriesViewModel
    {
        public static string _selectedCategory;
        UserService service;
        ObservableCollection<string> _myCategories;
        public ICommand AddCategoryCommand { get; private set; }

        // Constructor
        public ProMyCategoriesViewModel()
        {
            service = new UserService();
            _myCategories = new ObservableCollection<string>();
            AddCategoryCommand = new Command(AddCategory);

            GetCategories();
        }

        async void NavigateToQuestions()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ViewMainCategoriesView());
        }

        // Populate list with user subscriptions
        void GetCategories()
        {
            if (APIService.currentUser.categories != null)
            {
                foreach (var item in APIService.currentUser.categories)
                {
                    _myCategories.Add(item);
                }
            }
        }

        // Navigate to AllCategoriesView
        async void AddCategory()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new AllCategoriesView());
        }

        #region Properties

        public ObservableCollection<String> MyCategories
        {
            get
            {
                return _myCategories;
            }
            set
            {
                _myCategories = value;
            }
        }

        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory != null)
                {
                    NavigateToQuestions();
                }
            }
        }

        #endregion
    }
}
