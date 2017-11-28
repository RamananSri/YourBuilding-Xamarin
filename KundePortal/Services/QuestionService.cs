using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundePortal.Model;

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
        async public Task<List<QuestionModel>> GetBySubcategory(string subCat){
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(subCat);
            return questions;
        }

        public List<string> GetMainCategories()
        {
            List<string> MainCategories = new List<string>();
            MainCategories.Add("Vand");
            MainCategories.Add("Varme");
            return MainCategories;
        }

        public List<string> GetSubCategories(string mainCategory)
        {
            List<string> subCategories = new List<string>();
            switch (mainCategory)
            {
                case "Vand":
                    subCategories.Add("Koldt");
                    subCategories.Add("Varmt");
                    break;
                case "Varme":
                    subCategories.Add("Fjernvarme");
                    subCategories.Add("Pillefyr");
                    break;
                default:
                    break;
            }
            return subCategories;
        }

        // Update question by id
        async public Task<ResponseAPI> Update(string id, QuestionModel question){
            ResponseAPI response = await API.Put(baseRoute + id, question);
            return response;        
        }

        // Get questions by user ID
        async public Task<List<QuestionModel>> GetByUserId(string id){
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(baseRoute + id);
            return questions;       
        }

        // Delete question by ID
        async public Task<ResponseAPI> Delete(string id){
            ResponseAPI response = await API.Delete(baseRoute + id);
            return response;           
        }

        // Create question
        async public Task<ResponseAPI> Create(QuestionModel question){
            ResponseAPI response = await API.Put(baseRoute, question);
            return response;        
        }
    }
}
