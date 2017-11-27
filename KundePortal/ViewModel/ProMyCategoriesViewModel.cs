using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProMyCategoriesViewModel
    {
        ObservableCollection<string> _myCategories;
        public ICommand DeleteCategoryCommand { get; private set; }
        public ICommand AddCategoryCommand { get; private set; }

        public ProMyCategoriesViewModel(){
            DeleteCategoryCommand = new Command(DeleteCategory);
            AddCategoryCommand = new Command(AddCategory);

            GetCategories();
        }

        void GetCategories(){

            // Get my categories

            // TEST
            _myCategories = new ObservableCollection<string>();
            _myCategories.Add("Hej");
            _myCategories.Add("Hej Hej");
            // TEST  
        }

        async void AddCategory(){
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new AllCategoriesView());
        }

        void DeleteCategory(){
            _myCategories.Add("hej"); 
        }

        #region Properties


        public ObservableCollection<String> MyCategories
        { 
            get{
                return _myCategories;     
            }
            set{
                _myCategories = value;
            }
        }

        #endregion
    }
}
