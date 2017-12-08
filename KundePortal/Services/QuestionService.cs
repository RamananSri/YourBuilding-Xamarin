using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundePortal.Model;
using KundePortal.Utility;

namespace KundePortal.Services
{
    public class QuestionService
    {
        APIService API;
        string baseRoute;

        public QuestionService()
        {
            baseRoute = "api/questions/";
            API = new APIService();
        }

        // Get questions by subcategory
        async public Task<List<QuestionModel>> GetByCategory(string category)
        {
            string url = baseRoute + category;
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(url);
            return questions;
        }

        // Get questions by userID
        async public Task<List<QuestionModel>> GetByUserID(string userID)
        {
            string url = baseRoute + "user/" + userID;
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(url);
            return questions;
        }

        // Get categories
        async public Task<List<string>> GetCategories(string category)
        {
            string url = baseRoute + category + "/categories";
            List<string> categories = await API.Get<List<string>>(url);
            return categories;
        }

        // Update question by id
        async public Task<ResponseAPI> Update(string id, QuestionModel question)
        {
            ResponseAPI response = await API.Put(baseRoute + id, question);
            return response;
        }

        // Get questions by user ID
        async public Task<List<QuestionModel>> GetByUserId(string id)
        {
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(baseRoute + id);
            return questions;
        }

        // Delete question by ID
        async public Task<ResponseAPI> Delete(string id)
        {
            ResponseAPI response = await API.Delete(baseRoute + id);
            return response;
        }

        // Create question
        async public Task<ResponseAPI> Create(QuestionModel question)
        {
            ResponseAPI response = await API.Post(baseRoute, question);
            return response;
        }
    }
}
