using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KundePortal.Services;
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

        public ProMyCategoriesViewModel(){
            service = new UserService();
            _myCategories = new ObservableCollection<string>();
            DeleteCategoryCommand = new Command(DeleteCategory);
            AddCategoryCommand = new Command(AddCategory);

            GetCategories();
        }

        void GetCategories(){

            if(APIService.currentUser.subscriptions != null){
                foreach (var item in APIService.currentUser.subscriptions)
                {
                    _myCategories.Add(item);
                }
            }
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
