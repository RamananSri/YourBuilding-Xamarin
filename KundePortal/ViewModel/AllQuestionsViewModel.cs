using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.View;
using Xamarin.Forms;
using System.ComponentModel;

namespace KundePortal.ViewModel
{
    public class AllQuestionsViewModel
    {
        public static QuestionModel _selectedQuestion;
        ObservableCollection<QuestionModel> _questionsList;
        QuestionService qService;
       

        public AllQuestionsViewModel()
        {
            AddLike = new Command(addLike);
            _selectedQuestion = new QuestionModel();
            _questionsList = new ObservableCollection<QuestionModel>();
            qService = new QuestionService();
            getAllQuestions();
            CreateQuestionCommand = new Command(Navigate);

        }

        async void addLike(){
            _selectedQuestion.likeCounter++;
            ResponseAPI result = await qService.Update(_selectedQuestion._Id, _selectedQuestion);
            if (result.success)
            {
                await App.Current.MainPage.DisplayAlert("Likes", result.message, "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Likes", result.message, "OK");
            }
            _selectedQuestion.likeCounter = 5;
            PropertyChangedCheck("SelectedQuestion");
        }

        async void Navigate(){
            await Application.Current.MainPage.Navigation.PushAsync(new CreateQuestionView());
        }

        async void getAllQuestions()
        {
            List<QuestionModel> questions = await qService.GetBySubcategory(CategoryViewModel._childCategory);
            foreach (var item in questions)
            {
                _questionsList.Add(item);
            }
        }

        async void navigate(){
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new QuestionView());
        }

        //void PropertyChangedCheck(string prop)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //    }
        //}

        #region Properties

        public ObservableCollection<QuestionModel> QuestionsList 
        { 
            get
            {
                return _questionsList;
            } 
            set
            {
                _questionsList = value;
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
                if(_selectedQuestion != null){
                    navigate();
                }
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateQuestionCommand { get; private set; }
        public ICommand AddLike { get; private set; }

        #endregion
    }
}
