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
    public class CategoryViewModel : INotifyPropertyChanged
    {
        static string parentCategory;
        string _selectedCategory;
        QuestionService qs;
        ObservableCollection<string> _allCategories;

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoryViewModel()
        {
            qs = new QuestionService();

            if (CategoryViewModel.parentCategory != null)
            {
                GetSubCategories();
            }
            else {
                GetMainCategories();
            }

            AccountCommand = new Command(NavigateAccount);
        }

        public CategoryViewModel(ObservableCollection<string> categories)
        {
            qs = new QuestionService();
            _allCategories = categories;
            AccountCommand = new Command(NavigateAccount);
        }

        void GetMainCategories()
        {
            List<string> Categories = qs.GetMainCategories();
            _allCategories = new ObservableCollection<string>(Categories);
        }

        void GetSubCategories()
        {
            List<string> Categories = qs.GetSubCategories(parentCategory);
            _allCategories = new ObservableCollection<string>(Categories);
        }

        async void Navigate()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new CategoryView());
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
                //await Navigate();
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