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
        UserService service;
        ObservableCollection<string> _myCategories;
        public ICommand DeleteCategoryCommand { get; private set; }
        public ICommand AddCategoryCommand { get; private set; }

        // Constructor
        public ProMyCategoriesViewModel()
        {
            service = new UserService();
            _myCategories = new ObservableCollection<string>();
            DeleteCategoryCommand = new Command(DeleteCategory);
            AddCategoryCommand = new Command(AddCategory);

            GetCategories();
        }

        // Populate list with user subscriptions
        void GetCategories()
        {
            if(APIService.currentUser.categories != null){
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

        void DeleteCategory()
        {
            _myCategories.Add("hej"); 
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

        #endregion
    }
}
