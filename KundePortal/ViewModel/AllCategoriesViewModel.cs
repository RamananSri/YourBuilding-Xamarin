using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class AllCategoriesViewModel
    {
        ObservableCollection<SelectWrapper> _allCategories;
        ObservableCollection<string> _selectedCategories;
        QuestionService _question;

        public AllCategoriesViewModel()
        {
            _question = new QuestionService();
            _allCategories = new ObservableCollection<SelectWrapper>();
            _selectedCategories = new ObservableCollection<string>();
            SaveSelectedCommand = new Command(SaveSelected);

            GetAllCategories();
        }

        void GetAllCategories(){

            // Get properties from API 
            List<String> test = _question.GetMainCategories();
            foreach(var mainCategory in test)
            {
                _allCategories.Add(new SelectWrapper { IsSelected = false, Item = mainCategory });
            }
        }

        void SaveSelected(){

            foreach (var item in _allCategories)
            {
                if(item.IsSelected){
                    SelectedCategories.Add(item.Item);
                }
            }

            // Push list to API 
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
