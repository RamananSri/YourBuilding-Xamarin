using Xamarin.Forms;
using KundePortal.UserPages;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using KundePortal.Models;

namespace KundePortal
{
	//test
    public partial class LoginPage : ContentPage
    {
        HttpClient client;
        string url;
        HttpResponseMessage apiMessage;

        public static JsonResponse loggedIn;

        public LoginPage()
        {
            InitializeComponent();
            url = ConnectionAPI.Instance.url + "login";
            client = new HttpClient();
        }

        async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm { password = passEntry.Text, email = emailEntry.Text };
            var content = JsonConvert.SerializeObject(login);
            StringContent st = new StringContent(content, Encoding.UTF8, "application/json");

            apiMessage = await client.PostAsync(url, st);

            var result = await apiMessage.Content.ReadAsStringAsync();

            loggedIn = JsonConvert.DeserializeObject<JsonResponse>(result);

            if(loggedIn.token != null){
                if(loggedIn.user.cvr != null)
                {
                    await Navigation.PushAsync(new GridPro());
                }
                else
                {
                    await Navigation.PushAsync(new MainCategoryPage("Main"));
                }
                
            }
            else{
                errorLbl.Text = "Forkert brugernavn eller kodeord.";
                errorLbl.TextColor = Color.Red;
            }

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
