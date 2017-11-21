using System;
using System.Net.Http;
using KundePortal.Model;
using KundePortal.Models;

namespace KundePortal.Services
{
    public class LoginService
    {
        public static string token;
        public static UserModel currentUser;

        HttpClient client;
        String url;

        public LoginService()
        {
            client = new HttpClient();
            url = ConnectionAPI.Instance.url + "login";
            
        }

        //public bool Login(string username, string password){
            
        //}

    }
}
