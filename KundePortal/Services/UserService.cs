using System;
using System.Threading.Tasks;
using KundePortal.Model;

namespace KundePortal.Services
{
    public class UserService
    {
        APIService API;
        public static UserModel currentUser;

        public UserService()
        {
            API = new APIService();
        }

        async public Task<ResponseAPI> Login(string uname, string pword)
        {
            LoginForm form = new LoginForm { email = uname, password = pword };
            ResponseAPI res = await API.Post("login/", form);
            if(res.token != null && res.user != null){
                APIService.token = res.token;
                APIService.currentUser = res.user;
            }
            return res;
        }

        async public Task<UserModel> GetById(string id){
            
            UserModel user = await API.GetSingle("api/users/"+id,new UserModel());
            return user;
        } 

    }


    class LoginForm
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}