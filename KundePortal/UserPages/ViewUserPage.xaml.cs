using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using KundePortal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http.Headers;
using System.Text;

namespace KundePortal.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUserPage : ContentPage
    {

        HttpClient client;
        string url;
        JsonResponse loggedIn;

        public ViewUserPage()
        {
            client = new HttpClient();
            InitializeComponent();

            url = ConnectionAPI.Instance.url + "api/users";
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", LoginPage.loggedIn.token);
                var res = await client.PutAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
            }
        }

        void logOutBtn_clicked(object sender, System.EventArgs e)
        {
            LoginPage.loggedIn = null;
            Navigation.PopToRootAsync();

        }
    }
}