using System.Collections.ObjectModel;
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

		ObservableCollection<string> PopulateListview(string parentCategory){

            ObservableCollection<string> listItems = new ObservableCollection<string>();

            switch (parentCategory){
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


        void listItemClicked(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MainCategoryPage(e.SelectedItem.ToString()));
        }
    }
}
