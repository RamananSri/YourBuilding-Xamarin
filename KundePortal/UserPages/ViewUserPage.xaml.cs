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
            InitializeComponent();

            client = new HttpClient();
            url = ConnectionAPI.Instance.url + "api/users";

            loggedIn = LoginPage.loggedIn;

            nameEntry.Text = loggedIn.user.name;
            addressEntry.Text = loggedIn.user.address;
            phoneEntry.Text = loggedIn.user.phone;
            emailEntry.Text = loggedIn.user.email;
            tableSectionUser.Title = "Du er logget ind som " + loggedIn.user.name;
        }

        async void updateUserBtn_clickedAsync(object sender, System.EventArgs e)
        {

            var name = nameEntry.Text ;
            var address = addressEntry.Text;
            var phone = phoneEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            var newPassword = newPasswordEntryAgain.Text;

            if (!String.IsNullOrEmpty(name) &&
               !String.IsNullOrEmpty(address) &&
               !String.IsNullOrEmpty(phone) &&
                !String.IsNullOrEmpty(email) && 
                !String.IsNullOrEmpty(password)) 

            {
                User user = new User { name = name, address = address, phone = phone, email = email, password = password, newPassword = newPassword };
                if (userSwitch.On && !String.IsNullOrEmpty(newPasswordEntry.Text) && !String.IsNullOrEmpty(newPasswordEntryAgain.Text))
                {
                    user.newPassword = newPassword;
                }
                               
                var userSerial = JsonConvert.SerializeObject(loggedIn);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", LoginPage.loggedIn.token);
                var res = await client.PutAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
                var content = await res.Content.ReadAsStringAsync();
                JsonResponse response = JsonConvert.DeserializeObject<JsonResponse>(content);

                if(response.success == true)
                {
                    LoginPage.loggedIn = null;
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("Alert", "You have been alerted", "OK");
                }
                
            }
        }

        void logOutBtn_clicked(object sender, System.EventArgs e)
        {
            LoginPage.loggedIn = null;
            Navigation.PopToRootAsync();

        }
    }
}