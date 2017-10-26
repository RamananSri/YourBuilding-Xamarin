using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KundePortal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KundePortal.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUserPage : ContentPage
    {

        HttpClient client;
        string url = "http://localhost:3000/users/";
        JsonResponse loggedIn;

        public ViewUserPage()
        {
            client = new HttpClient();
            InitializeComponent();

            loggedIn = LoginPage.loggedIn;

            nameEntry.Text = loggedIn.user.name;
            addressEntry.Text = loggedIn.user.address;
            phoneEntry.Text = loggedIn.user.phone;
            emailEntry.Text = loggedIn.user.email;
        }

        async Task updateUserBtn_clickedAsync(object sender, System.EventArgs e)
        {

            var name = nameEntry.Text ;
            var address = addressEntry.Text;
            var phone = phoneEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            if (!String.IsNullOrEmpty(name) &&
               !String.IsNullOrEmpty(address) &&
               !String.IsNullOrEmpty(phone) &&
                !String.IsNullOrEmpty(email) && 
                !String.IsNullOrEmpty(password))
            {

                User user = new User {name = name, address = address, phone = phone, email = email, password = password };
                var userSerial = JsonConvert.SerializeObject(user);
                var res = await client.PutAsync(url, new StringContent(userSerial));
            }
        }
    }
}