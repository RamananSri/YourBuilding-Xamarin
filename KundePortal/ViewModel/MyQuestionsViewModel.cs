using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    public class MyQuestionsViewModel
    {
        ObservableCollection<QuestionModel> _myQuestions;
        QuestionService qService;


        public MyQuestionsViewModel()
        {
            qService = new QuestionService();
            GetMyQuestions();
        }

        async void GetMyQuestions(){
            List<QuestionModel> myQuestions = await qService.GetByUserID(APIService.currentUser._id); 
        }

        public object MyProperty { get; set; }

    }
}
