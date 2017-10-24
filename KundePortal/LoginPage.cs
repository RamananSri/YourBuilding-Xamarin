﻿using Xamarin.Forms;
using KundePortal.UserPages;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace KundePortal
{
    public partial class LoginPage : ContentPage
    {
        HttpClient client;
        string url = "http://10.31.142.171/login";
        HttpResponseMessage apiMessage;

        public LoginPage()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        void LoginBtnClicked(object sender, EventArgs e)
        {
            var loginForm = new LoginForm { password = passEntry.Text, email = emailEntry.Text };
            Login(loginForm);
            //LoginAsync(loginForm);

            Navigation.PushAsync(new MainCategoryPage("Main"));


            // insert REST login login


            // Private user 


            // Business user
        }

        async void Login(LoginForm lf)
        {
            var content = JsonConvert.SerializeObject(lf);
            apiMessage = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "text/json"));
            var apiMessage2 = await apiMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(apiMessage2);
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
