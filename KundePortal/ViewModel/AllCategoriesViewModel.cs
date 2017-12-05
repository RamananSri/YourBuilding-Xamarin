using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Model;

namespace KundePortal.ViewModel
{
    public class AllCategoriesViewModel
    {
        ObservableCollection<SelectWrapper> _allCategories;
        ObservableCollection<string> _selectedCategories;
        QuestionService _question;
        UserService _userService;

        public AllCategoriesViewModel()
        {
            _question = new QuestionService();
            _userService = new UserService();
            _allCategories = new ObservableCollection<SelectWrapper>();
            _selectedCategories = new ObservableCollection<string>();
            SaveSelectedCommand = new Command(SaveSelected);

            GetAllCategories();
        }

        // Get all main categories from API
        async void GetAllCategories()
        {
            List<String> test = await _question.GetMainCategories();

            // Check if any maincategory is already subscribed to
            foreach(var mainCategory in test)
            {
                if(APIService.currentUser.categories.Contains(mainCategory)){
                    _allCategories.Add(new SelectWrapper { IsSelected = true, Item = mainCategory });
                }
                else{
                    _allCategories.Add(new SelectWrapper { IsSelected = false, Item = mainCategory });
                }
            }
        }

        // Save selections
        async void SaveSelected(){

            List<string> allSubs = new List<string>();

            // Check if new subscription or remove subscription
            foreach (var item in _allCategories)
            {
                if(item.IsSelected){
                    allSubs.Add(item.Item);
                }
            }

            ResponseAPI res = await _userService.PutSub(allSubs);

            if(res.success){
                APIService.currentUser.categories = allSubs;

                await Application.Current.MainPage.Navigation.PopAsync(true);
            }
            else{
                await Application.Current.MainPage.DisplayAlert("Update", res.message, "OK");
            }
        }

        #region Properties

        public ObservableCollection<SelectWrapper> AllCategories 
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

        public ObservableCollection<string> SelectedCategories
        {
            get
            {
                return _selectedCategories;
            }
            set
            {
                _selectedCategories = value;
            }
        }

        public ICommand SaveSelectedCommand { get; private set; }


        #endregion
    }

    public class SelectWrapper
    {
        public bool IsSelected { get; set; }
        public string Item { get; set; }
    }
}
