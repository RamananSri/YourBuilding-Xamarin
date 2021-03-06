﻿using KundePortal.Model;
using KundePortal.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;
using KundePortal.Services;

namespace KundePortal.ViewModel
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        QuestionService qService;
        public bool _cvrOrNot;
        public bool _canDelete;
        public static AnswerModel _selectedAnswer;
        public event PropertyChangedEventHandler PropertyChanged;

        public static QuestionModel _question;
        ObservableCollection<AnswerModel> _answerList;

        public QuestionViewModel()
        {
            qService = new QuestionService();
            _cvrOrNot = false;
            cvrCheck();
            openAnswerQuestionCommand = new Command(answerQuestion);
            DeleteQuestionCommand = new Command(deleteQuestion);


            if(AllQuestionsViewModel._selectedQuestion != null){
                _question = AllQuestionsViewModel._selectedQuestion;
            }
            else{
                _question = MyQuestionsViewModel._selectedItem;
            }
            _answerList = new ObservableCollection<AnswerModel>(_question.answers);
        }

        async void deleteQuestion()
        {
            ResponseAPI res = await qService.Delete(_question._Id); 
            if(res.success){
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else{
                await Application.Current.MainPage.DisplayAlert("Delete question", res.message, "Ok");
            }
        }

        void cvrCheck()
        {
            if(APIService.currentUser.cvr != null)
            {
                _cvrOrNot = true;
            }
        }

        async void answerQuestion()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            AnswerQuestionViewModel.question = _question;
            await nav.PushAsync(new AnswerQuestionView());
        }

        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        async void goToAnswer()
        {

            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new AnswerView());
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

        public ObservableCollection<AnswerModel> AnswerList
        {
            get => _answerList;

            set
            {
                _answerList = value;
                PropertyChangedCheck("AnswerList");
            }
        }

        public AnswerModel SelectedAnswer
        {
            get
            {
                return _selectedAnswer;
            }
            set
            {
                _selectedAnswer = value;
                if(_selectedAnswer != null)
                {
                    goToAnswer();
                }
            }
        }

        public bool CvrOrNot
        {

            get
            {
                return _cvrOrNot;
            }

            set
            {
                _cvrOrNot = value;
                PropertyChangedCheck("CvrOrNot");
            }
        }

        public bool CanDelete 
        { 
            get
            {
                return _canDelete;
            }
            set
            {
                _canDelete = value;
            } 
        }

        public ICommand openAnswerQuestionCommand { get; private set; }
        public ICommand DeleteQuestionCommand { get; private set; }


        #endregion


    }
}
