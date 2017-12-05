using System;
using System.Collections.ObjectModel;
using KundePortal.Services;
using System.Windows.Input;
using KundePortal.View;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace KundePortal.ViewModel
{
    public class CategoryViewModel
    {
        public static string parentCategory;
        string _selectedCategory;
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
                GetSubCategories();
            }
            else {
                isSubCategory = false;
                GetMainCategories();
            }

            AccountCommand = new Command(NavigateAccount);
        }

        async void GetMainCategories()
        {
            List<string> categories = await qs.GetMainCategories();
            foreach (var item in categories)
            {
                _allCategories.Add(item);
            }
        }

        void GetSubCategories()
        {
            List<string> Categories = qs.GetSubCategories(parentCategory);
            _allCategories = new ObservableCollection<string>(Categories);
        }

        async void Navigate()
        {
            INavigation nav = Application.Current.MainPage.Navigation;

            if(isSubCategory){
                await nav.PushAsync(new AllQuestionsView());
            }
            else{
                await nav.PushAsync(new CategoryView());
            }
        }

        async void NavigateAccount(){
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new ViewUserView());
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

        public ICommand AccountCommand { get; private set; }
    }
}