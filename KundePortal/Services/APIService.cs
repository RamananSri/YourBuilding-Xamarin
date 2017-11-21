using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace KundePortal.Services
{
    public class APIService
    {
        
        //string baseAddress = "http://10.0.2.2:3000/"; //Til android bruger
        string baseAddress = "http://localhost:3000/";  //Til mac bruger


        public static string token;
        HttpClient client;

        public APIService()
        {
            client = new HttpClient();

            // consume entity/close connection? 
        }

        public async void Post(string url, object obj){
            var address = baseAddress + url;
            var data = Serialize(obj);

            // post af lister? 
            var response = await client.PostAsync(address,data);

            // response handling? 
        }

        public async void Get(string url, object obj){
            var address = baseAddress + url;

            var response = await client.GetStringAsync(address); 

            // response handling?
        }

        public async void Put(string url, object obj){
            var address = baseAddress + url;
            var data = Serialize(obj);

            // vil vi komme ud for at put en liste? 
            var response = await client.PutAsync(address, data);

            // response handling? 
        }

        public async void Delete(string url, object obj){
            var address = baseAddress + url;

            // body??

            var response = await client.DeleteAsync(address);

            // response handling? 
        }


        StringContent Serialize(object obj){
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }




    }
}
