using System;
using KundePortal.Model;
namespace KundePortal.Services
{
    public class AnswerService
    {
        APIService API;
        public AnswerService()
        {
            API = new APIService();
        }

        async public Task<ResponseAPI> postAnswer(AnswerModel answer)
        {
            answer = new AnswerModel();
            ResponseAPI res = API.post("api/answers/");
            if (res.token != null && res.user != null)
            {
                APIService.token = res.token;
                APIService.currentUser = res.user;
            }
            return res;
        }
    }

    }
}
