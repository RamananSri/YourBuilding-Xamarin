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
            Title = parentCategory;
        }
        // Jeg tror umiddelbart ikke at de behøver være observablecollections, da brugeren ikke skal slette eller tilføje nyt indhold
        List<string> PopulateListview(string parentCategory)
        {

            List<string> listItems = new List<string>();

            switch (parentCategory)
            {
                case "Main":
                    listItems = new List<string>{
                        "Vand",
                        "Varme",
                        "El",
                        "Afløb",
                        "Andet"
                     };
                    break;
                case "Vand":
                    listItems = new List<string>{
                        "Varmt",
                        "Koldt"
                    };
                    break;
            }
            return listItems;
        }

        async void listItemClicked(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem.ToString();

            if(selectedCategory == "Varmt" || selectedCategory == "Koldt"){
                await Navigation.PushAsync(new NewQuestionPage(selectedCategory));
            }
            else{
                await Navigation.PushAsync(new MainCategoryPage(selectedCategory));
            }
        }

        async void KontoItem_Activated(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ViewUserPage());
        }
    }
}
