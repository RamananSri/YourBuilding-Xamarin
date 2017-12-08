using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KundePortal.ViewModel
{
    public class ViewMainCategoriesViewModel
    {

        ObservableCollection<QuestionModel> _questionList;
        public static QuestionModel _selectedQuestion;
        QuestionService qs;

        public ViewMainCategoriesViewModel()
        {
            _questionList = new ObservableCollection<QuestionModel>();
            qs = new QuestionService();
            getQuestions();
        }

        async void getQuestions()
        {
            List<QuestionModel> questions = await qs.GetByCategory(ProMyCategoriesViewModel._selectedCategory);
            foreach (var item in questions)
            {
                _questionList.Add(item);
            }
        }

        #region

        public ObservableCollection<QuestionModel> QuestionList
        {
            get
            {
                return _questionList;
            }
            set
            {
                _questionList = value;
            }
        }

        public QuestionModel SelectedQuestion
        {
            get
            {
                return _selectedQuestion;
            }
            set
            {
                _selectedQuestion = value;
            }
        }

        #endregion

    }
}
