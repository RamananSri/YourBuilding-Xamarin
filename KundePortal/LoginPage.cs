using Xamarin.Forms;
using KundePortal.UserPages;
using System;
using Newtonsoft.Json;
using System.Net.Http;

namespace KundePortal
{
    public partial class LoginPage : ContentPage
    {
        HttpClient client;
        string url = "http://localhost:3000/api/";
        HttpResponseMessage apiMessage;

        public LoginPage()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        async void LoginBtnClicked(object sender, EventArgs e)
        {
            var loginForm = new LoginForm { password = passEntry.Text, email = emailEntry.Text };

            var content = JsonConvert.SerializeObject(loginForm);
            apiMessage = await client.PostAsync(url, new StringContent(content));

            //LoginAsync(loginForm);

            if(true){
                apiMessage.Content.ToString();

                //Navigation.PushAsync(new MainCategoryPage("Main"));
            }


            // insert REST login login


            // Private user 


            // Business user
        }



        async void OpretItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateUserPage());
        }
    }

    public class LoginForm
    {
        public string password
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
    }
}
