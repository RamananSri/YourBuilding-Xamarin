using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KundePortal.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KundePortal.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUserPage : ContentPage
    {
        HttpClient client;
        string url;

        public CreateUserPage()
        {
            client = new HttpClient();
            url = ConnectionAPI.Instance.url + "create";
            InitializeComponent();
        }

        async Task createUserBtn_clickedAsync(object sender, System.EventArgs e)
        {
            var name = nameEntry.Text;
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
                User user = new User { name = name, address = address, phone = phone, email = email, password = password };
                var userSerial = JsonConvert.SerializeObject(user);
                await client.PostAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
                await Navigation.PopAsync();
            }
        }
    }
}