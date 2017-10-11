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

        public ViewUserPage()
        {
            client = new HttpClient();
            InitializeComponent();
        }

        async Task updateUserBtn_clickedAsync(object sender, System.EventArgs e)
        {
            int id = Convert.ToInt32(idEntry.Text);
            var name = nameEntry.Text;
            var address = addressEntry.Text;
            var phone = phoneEntry.Text;
            var email = emailEntry.Text;

            if (!String.IsNullOrEmpty(name) &&
               !String.IsNullOrEmpty(address) &&
               !String.IsNullOrEmpty(phone) &&
                !String.IsNullOrEmpty(email))
            {

                User user = new User {Name = name, Address = address, Phone = phone, Email = email };
                var userSerial = JsonConvert.SerializeObject(user);
                var res = await client.PutAsync(url, new StringContent(userSerial));
            }
        }
    }
}