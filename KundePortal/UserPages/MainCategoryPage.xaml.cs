using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace KundePortal.UserPages
{
    public partial class MainCategoryPage : ContentPage
    {
        public MainCategoryPage()
        {
            InitializeComponent();
            PopulateListview();
        }

        void PopulateListview(){
            listViewCategories.ItemsSource = new ObservableCollection<string> { "Vand", "Varme","El","Afløb","Andet" };
        }
    }
}
