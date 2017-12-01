using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class AllQuestionsViewModel
    {
        public static QuestionModel _selectedQuestion;

        ObservableCollection<QuestionModel> _questionsList;

        QuestionService qService;

        public AllQuestionsViewModel()
        {
            _selectedQuestion = null;
            _questionsList = new ObservableCollection<QuestionModel>();

            qService = new QuestionService();
            getAllQuestions();

            CreateQuestionCommand = new Command(Navigate);

        }

        async void Navigate(){
            await Application.Current.MainPage.Navigation.PushAsync(new CreateQuestionView());
        }

        async void getAllQuestions()
        {
            List<QuestionModel> questions = await qService.GetBySubcategory(CategoryViewModel.parentCategory);
            foreach (var item in questions)
            {
                _questionsList.Add(item);
            }
        }

        async void navigate(){
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new QuestionView());
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
                if(_selectedQuestion != null){
                    navigate();
                }
            }
        }

        public ICommand CreateQuestionCommand { get; private set; }

        #endregion
    }
}
