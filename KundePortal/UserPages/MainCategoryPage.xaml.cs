using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace KundePortal.UserPages
{
    public partial class MainCategoryPage : ContentPage
    {
        public MainCategoryPage(string parentCategory)
        {
            InitializeComponent();
            listViewCategories.ItemsSource = PopulateListview(parentCategory);
        }
        // Jeg tror umiddelbart ikke at de behøver være observablecollections, da brugeren ikke skal slette eller tilføje nyt indhold
        ObservableCollection<string> PopulateListview(string parentCategory)
        {

            ObservableCollection<string> listItems = new ObservableCollection<string>();

            switch (parentCategory)
            {
                case "Main":
                    listItems = new ObservableCollection<string>{
                        "Vand",
                        "Varme",
                        "El",
                        "Afløb",
                        "Andet"
                     };
                    break;
                case "Vand":
                    listItems = new ObservableCollection<string>{
                        "Varmt",
                        "Koldt"
                    };
                    break;
            }
            return listItems;
        }



        async void listItemClicked(object sender, SelectedItemChangedEventArgs e)
        {
           await Navigation.PushAsync(new MainCategoryPage(Title = e.SelectedItem.ToString()));

        }
    }
}
