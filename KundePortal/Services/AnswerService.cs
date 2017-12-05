using KundePortal.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundePortal.Utility;

namespace KundePortal.Services
{
    public class AnswerService
    {
        List<string> testList;
        APIService API;
        string baseRoute;

        public AnswerService(){
            baseRoute = "api/answers/";
            API = new APIService();
            testList = new List<string>();
        }

        public List<string> getSubCategories()
        {
            testList.Add("Koldt");
            testList.Add("Varmt");
            return testList;
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
