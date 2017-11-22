using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KundePortal.Model;
using Newtonsoft.Json;

namespace KundePortal.Services
{
    public class APIService
    {
        string baseAddress = "http://165.227.137.112/";
        public static string token;
        public static UserModel currentUser;
        HttpClient client;

        public APIService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            // consume entity/close connection? 
        }

        public async Task<ResponseAPI> Post(string url, object obj)
        {
            var address = baseAddress + url;
            var data = Serialize(obj);
            var response = await client.PostAsync(address, data);
            ResponseAPI result = await Deserialize(response, new ResponseAPI());
            return result;
        }

        public async Task<T> GetSingle<T>(string url, T obj)
        {
            var address = baseAddress + url;
            var response = await client.GetAsync(address);
            T result = await Deserialize(response, obj);
            return result;
        }

        //public async Task<List<T>> GetList<T>(string url, object obj)
        //{
        //    var address = baseAddress + url;

        //    var response = await client.GetStringAsync(address);


        //    // response handling?
        //}

        public async Task<ResponseAPI> Put(string url, object obj)
        {
            var address = baseAddress + url;
            var data = Serialize(obj);

            // vil vi komme ud for at put en liste? 
            var response = await client.PutAsync(address, data);
            ResponseAPI result = await Deserialize(response, new ResponseAPI());
            return result;
        }

        public async Task<ResponseAPI> Delete(string url, object obj)
        {
            var address = baseAddress + url;
            var data = Serialize(obj);
            
            var response = await client.DeleteAsync(address, data); //cancel token?
            ResponseAPI result = await Deserialize(response, new ResponseAPI());
            return result;
        }


        StringContent Serialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        async Task<T> Deserialize<T>(object res, T objType ){

            T response = objType;

            if(res is string){
                response = JsonConvert.DeserializeObject<T>((string)res);
            }
            if(res is HttpResponseMessage){
                HttpResponseMessage mes = (HttpResponseMessage)res;
                var content = await mes.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<T>(content);
            }

            return response;
        }




    }
}
