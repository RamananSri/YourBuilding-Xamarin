using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KundePortal.Model;
using Newtonsoft.Json;

namespace KundePortal.Utility
{
    public class APIService
    {
        public static string token;
        public static UserModel currentUser;

        string baseAddress;
        HttpClient client;

        public APIService()
        {
            baseAddress = "http://localhost:3000/";
            //baseAddress = "http://165.227.137.112/";
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);
            // consume entity/close connection? 
        }

        // Post 
        public async Task<ResponseAPI> Post<T>(string url, T obj)
        {
            try
            {
                var address = baseAddress + url;
                var data = Serialize(obj);
                var response = await client.PostAsync(address, data);
                ResponseAPI result = await Deserialize<ResponseAPI>(response);
                return result;
            }
            catch (HttpRequestException)
            {
                return new ResponseAPI { success = false, message = "Ingen fobindelse" };
            }
            catch (JsonException)
            {
                return new ResponseAPI { success = false, message = "Data fejl - prøv igen" };
            }
        }

        // Get
        public async Task<T> Get<T>(string url)
        {
            try
            {
                var address = baseAddress + url;
                var response = await client.GetAsync(address);
                T result = await Deserialize<T>(response);
                return result;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        // Put
        public async Task<ResponseAPI> Put<T>(string url, T obj)
        {
            try
            {
                var address = baseAddress + url;
                var data = Serialize(obj);
                var response = await client.PutAsync(address, data);
                ResponseAPI result = await Deserialize<ResponseAPI>(response);
                return result;
            }
            catch (HttpRequestException)
            {
                return new ResponseAPI { success = false, message = "Ingen fobindelse" };
            }
            catch (JsonException)
            {
                return new ResponseAPI { success = false, message = "Data fejl - prøv igen" };
            }
        }

        // Delete
        public async Task<ResponseAPI> Delete(string url)
        {
            try
            {
                var address = baseAddress + url;
                var response = await client.DeleteAsync(address);
                ResponseAPI result = await Deserialize<ResponseAPI>(response);
                return result;
            }
            catch (HttpRequestException)
            {
                return new ResponseAPI { success = false, message = "Ingen fobindelse" };
            }
            catch (JsonException)
            {
                return new ResponseAPI { success = false, message = "Data fejl - prøv igen" };
            }
        }

        // JSON serialize generic
        StringContent Serialize<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        // JSON deserialize generic
        async Task<T> Deserialize<T>(object res){
            
            //if (res is string){
            //    return JsonConvert.DeserializeObject<T>((string)res);
            //}

            HttpResponseMessage mes = (HttpResponseMessage)res;
            var content = await mes.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
