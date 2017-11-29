using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KundePortal.Model;
using KundePortal.Services;

namespace KundePortal.ViewModel
{
    public class AllQuestionsViewModel
    {
        ObservableCollection<QuestionModel> _questionsList;
        QuestionModel _selectedQuestion;

        QuestionService qService;

        public AllQuestionsViewModel()
        {
            QuestionsList = new ObservableCollection<QuestionModel>();
            qService = new QuestionService();
            getAllQuestions();
        }

        async void getAllQuestions()
        {
            List<QuestionModel> questions = await qService.GetBySubcategory(CategoryViewModel.parentCategory);
            _questionsList = new ObservableCollection<QuestionModel>(questions);
        }

        #region Properties

        public ObservableCollection<QuestionModel> QuestionsList 
        { 
            get{
                return _questionsList;
            } 
            set{
                _questionsList = value;
            } 
        }

        public QuestionModel SelectedQuestion 
        { 
            get{
                return _selectedQuestion;
            } 
            set{
                _selectedQuestion = value;
            }
        }

        #endregion
    }
}
