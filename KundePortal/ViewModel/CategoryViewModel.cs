using System;
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
        static string parentCategory;

        string _selectedCategory;
        QuestionService qs;
        ObservableCollection<string> _allCategories;

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
        }

        public CategoryViewModel(ObservableCollection<string> categories)
        {
            qs = new QuestionService();
            _allCategories = categories;
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


        public string MainCategory
        {
            get
            {
                return parentCategory;
            }
            set
            {
                parentCategory = value;
                Navigate();
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
    }
}


//public MainCategoryPage(string parentCategory)
//{
//    InitializeComponent();
//    listViewCategories.ItemsSource = PopulateListview(parentCategory);
//    Title = parentCategory;
//}

//List<string> PopulateListview(string parentCategory)
//{

//    List<string> listItems = new List<string>();

//    switch (parentCategory)
//    {
//        case "Main":
//            NavigationPage.SetHasBackButton(this, false); // Fjerner tilbage-knappen på startsiden, så det ikke er muligt at tilbage til loginsiden.
//            listItems = new List<string>{
//                        "Vand",
//                        "Varme",
//                        "El",
//                        "Afløb",
//                        "Andet"
//                     };
//            break;

//        case "Vand":
//            listItems = new List<string>{
//                        "Varmt",
//                        "Koldt"
//                    };
//            break;
//    }
//    return listItems;
//}

//async void listItemClicked(object sender, SelectedItemChangedEventArgs e)
//{
//    string selectedCategory = e.SelectedItem.ToString();

//    if (selectedCategory == "Varmt" || selectedCategory == "Koldt")
//    {
//        await Navigation.PushAsync(new QuestionPage(selectedCategory));
//    }
//    else
//    {
//        await Navigation.PushAsync(new MainCategoryPage(selectedCategory));
//    }
//}

//async void KontoItem_Activated(object sender, System.EventArgs e)
//{
//    await Navigation.PushAsync(new ViewUserPage());
//}