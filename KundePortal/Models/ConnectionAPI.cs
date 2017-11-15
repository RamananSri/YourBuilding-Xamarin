using System;
using System.Net.Http;

namespace KundePortal.Models
{
    public class ConnectionAPI
    {
        private static ConnectionAPI instance;

        //string webUrl = "http://10.0.2.2:3000/"; //Til android bruger
        string webUrl = "http://localhost:3000/";  //Til mac bruger

        //HttpClient _client;

        public string url
        {
            get { return webUrl; }
        }

        private ConnectionAPI()
        {
            //_client = new HttpClient();
        }

        public static ConnectionAPI Instance{
            get{
                if(instance == null){
                    instance = new ConnectionAPI();
                }
                return instance;
            }
        }
    }
}
