using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KundePortal.Model;
using Newtonsoft.Json;

namespace KundePortal.Services
{
    public class APIService
    {
        public static string token;
        public static UserModel currentUser;

        string baseAddress;
        HttpClient client;

        public APIService()
        {
            baseAddress = "http://165.227.137.112/";
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("token", token);

            // consume entity/close connection? 
        }

        // Post 
        public async Task<ResponseAPI> Post<T>(string url, T obj)
        {
            var address = baseAddress + url;
            var data = Serialize(obj);
            var response = await client.PostAsync(address, data);
            ResponseAPI result = await Deserialize<ResponseAPI>(response);
            return result;
        }

        // Get
        public async Task<T> Get<T>(string url)
        {
            var address = baseAddress + url;
            var response = await client.GetAsync(address);
            T result = await Deserialize<T>(response);
            return result;
        }

        // Put
        public async Task<ResponseAPI> Put<T>(string url, T obj)
        {
            var address = baseAddress + url;
            var data = Serialize(obj);
            var response = await client.PutAsync(address, data);
            ResponseAPI result = await Deserialize<ResponseAPI>(response);
            return result;
        }

        // Delete
        public async Task<ResponseAPI> Delete(string url)
        {
            var address = baseAddress + url;
            
            var response = await client.DeleteAsync(address);
            ResponseAPI result = await Deserialize<ResponseAPI>(response);
            return result;
        }

        // JSON serialize
        StringContent Serialize<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            StringContent stringify = new StringContent(json, Encoding.UTF8, "application/json");
            return stringify;
        }

        // JSON deserialize
        async Task<T> Deserialize<T>(object res){
            
            if (res is string){
                return JsonConvert.DeserializeObject<T>((string)res);
            }

            HttpResponseMessage mes = (HttpResponseMessage)res;
            var content = await mes.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
