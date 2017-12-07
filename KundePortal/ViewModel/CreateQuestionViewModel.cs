using KundePortal.Model;
using KundePortal.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;
using System;
using System.Collections.Generic;

namespace KundePortal.ViewModel
{
    public class CreateQuestionViewModel
    {
        string _mainCategory;
        string _subCategory;
        QuestionModel _question;
        QuestionService questionService;

        public CreateQuestionViewModel()
        {
            createQuestionCommand = new Command(createQuestion);
            _question = new QuestionModel();
            questionService = new QuestionService();
            _mainCategory = CategoryViewModel._parentCategory;
            _subCategory = CategoryViewModel._childCategory;
        }

        async void createQuestion()
        {
            if(string.IsNullOrEmpty(_question.title) || string.IsNullOrEmpty(_question.description))
            {
                await Application.Current.MainPage.DisplayAlert("Opretning af spørgsmål", "udfyld venligst alle felter", "OK");
                return;
            }

            _question.category = _mainCategory;
            _question.subCategory = _subCategory;
            _question.userId = APIService.currentUser.name;
            _question.questionDate = DateTime.Now.ToString("dd/MM/yyyy");
            _question.answers = new List<AnswerModel>();



            ResponseAPI result = await questionService.Create(Question);
            if (result.success)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Opretning af spørgsmål", result.message, "OK");
            }
        }

        #region properties

        public QuestionModel Question
        {
            get => _question;

            set
            {
                _question = value;
            }
        }

        public string MainCategory 
        { 
            get
            {
                return _mainCategory;
            }
            private set
            {
                _mainCategory = value;    
            } 
        }

        public string SubCategory 
        { 
            get
            {
                return _subCategory;
            }
            private set
            {
                _subCategory = value;       
            }
        }

        public ICommand createQuestionCommand { get; private set; }

        #endregion

    }
}
