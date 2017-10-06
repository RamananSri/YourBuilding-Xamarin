using Xamarin.Forms;
using KundePortal.UserPages;
using System;

namespace KundePortal
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void LoginBtnClicked(object sender, EventArgs e)
        {
            // insert REST login login


            // Private user 
            Navigation.PushAsync(new MainCategoryPage("Main"));

            // Business user
        }
    }
}
