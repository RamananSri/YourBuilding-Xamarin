using KundePortal.Model;
using System;
using System.Threading.Tasks;

namespace KundePortal.Services
{
    public class AnswerService
    {
        APIService API;
        string baseRoute;

        public AnswerService()
        {
            baseRoute = "api/answers/";
            API = new APIService();
        }

        // Create answer 
        async public Task<ResponseAPI> Create(AnswerModel answer){
            ResponseAPI res = await API.Post(baseRoute, answer);  
            return res;
        }

        // Update answer by question/answer id
        async public Task<ResponseAPI> Update(string qid, AnswerModel answer){
            ResponseAPI res = await API.Put(baseRoute + qid, answer);
            return res;
        }

        // Delete answer by question/answer id
        async public Task<ResponseAPI> Delete(string qid, string aid){
            ResponseAPI res = await API.Delete(baseRoute + qid + "/" + aid);
            return res;
        }
    }
}
