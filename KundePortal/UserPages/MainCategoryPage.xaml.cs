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
            tokenLbl.Text = LoginPage.loggedIn.token;
        }

        List<string> PopulateListview(string parentCategory)
        {

            List<string> listItems = new List<string>();

            switch (parentCategory)
            {
                case "Main":
                    NavigationPage.SetHasBackButton(this, false); // Fjerner tilbage-knappen på startsiden, så det ikke er muligt at tilbage til loginsiden.
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
