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
        const string url = "http://localhost:3000/users/";

        public CreateUserPage()
        {
            client = new HttpClient();
            InitializeComponent();
        }

        async Task createUserBtn_clickedAsync(object sender, System.EventArgs e)
        {
            var name = nameEntry.Text;
            var address = addressEntry.Text;
            var phone = phoneEntry.Text;
            var email = emailEntry.Text;

            if (!String.IsNullOrEmpty(name) &&
               !String.IsNullOrEmpty(address) &&
               !String.IsNullOrEmpty(phone) &&
               !String.IsNullOrEmpty(email))
            {
                User user = new User { Name = name, Address = address, Phone = phone, Email = email };
                var userSerial = JsonConvert.SerializeObject(user);
                await client.PostAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
            }
        }
    }
}