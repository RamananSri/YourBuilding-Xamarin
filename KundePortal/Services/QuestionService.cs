﻿using System;
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
        async public Task<List<QuestionModel>> GetBySubcategory(string subCat){
            string url = baseRoute + subCat;
            List<QuestionModel> questions = await API.Get<List<QuestionModel>>(url);
            return questions;
        }

        async public Task<List<string>> GetMainCategories()
        {
            string url = baseRoute + "1/categories";
            List<string> MainCategories = await API.Get<List<string>>(url);
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
