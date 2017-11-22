using KundePortal.Model;
using System;
using System.Threading.Tasks;

namespace KundePortal.Services
{
    public class AnswerService
    {
        APIService API;
        public AnswerService()
        {
            API = new APIService();
        }
        async public Task<ResponseAPI> post(string likes, string date, string username, string description, string userId)
        {
            AnswerModel answer = new AnswerModel { likeCounter = likes, answerDate = date, userName = username, description = description, userId = userId};
            ResponseAPI res = await API.Post("/api/answers/id/", answer); //hvor skal id komme fra? lave getSingle først?   
            if (res.token != null && res.user != null)
            {
                APIService.token = res.token;
                APIService.currentUser = res.user;
            }
            return res;
        }

        async public Task<ResponseAPI> put(string likes, string date, string username, string description, string userId)
        {
            AnswerModel answer = new AnswerModel { likeCounter = likes, answerDate = date, userName = username, description = description, userId = userId };
            ResponseAPI res = await API.Put("/api/answers/id/", answer); //hvor skal id komme fra? lave getSingle først?   
            if (res.token != null && res.user != null)
            {
                APIService.token = res.token;
                APIService.currentUser = res.user;
            }
            return res;
        }

    }
}
