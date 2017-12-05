using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundePortal.Model;

namespace KundePortal.Services
{
    public class UserService
    {
        APIService API;
        String baseRoute;

        public UserService()
        {
            baseRoute = "api/users/";
            API = new APIService();
        }

        // Create user
        async public Task<ResponseAPI> Create(UserModel user){
            ResponseAPI res = await API.Post("create", user);
            return res;
        }

        // Logout
        public void Logout(){
            APIService.token = null;
            APIService.currentUser = null;
        }

        // Login
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

        // Get user by ID
        async public Task<UserModel> GetById(string id){
            UserModel user = await API.Get<UserModel>(baseRoute + id);
            return user;
        }

        // Delete user by ID
        async public Task<ResponseAPI> Delete(string id){
            ResponseAPI res = await API.Delete(baseRoute + id);
            return res;
        }

        // Update user by ID
        async public Task<ResponseAPI> Update(string id, UserModel user){
            ResponseAPI res = await API.Put(baseRoute + id, user);
            return res;
        }
    }

    class LoginForm
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}