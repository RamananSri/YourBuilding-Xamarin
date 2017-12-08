using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class AnswerViewModel
    {
        QuestionViewModel qsView;
        AnswerModel selectedAnswer;
        QuestionService questionService;
        AnswerService answerService;
        bool _showDeleteButton = false;

        public AnswerViewModel()
        {
            questionService = new QuestionService();
            qsView = new QuestionViewModel();
            selectedAnswer = qsView.SelectedAnswer;
            //qsView.SelectedAnswer = null;
            deleteCommand = new Command(Delete);
            answerService = new AnswerService();

            checkUser();

        }

        public void checkUser()
        {
            if (selectedAnswer.userId.Equals(APIService.currentUser._id))
            {
                _showDeleteButton = true;
            }
        }

        async void Delete()
        {
            var page = await Application.Current.MainPage.DisplayAlert("Slet svar", "Ønsker du at slette dit svar?", "Nej", "ja");

            if (!page)
            {
                ResponseAPI result = await answerService.Delete(QuestionViewModel._question._Id ,selectedAnswer._id);
                if (!result.success)
                {
                    await Application.Current.MainPage.DisplayAlert("Fejl", result.message, "OK");
                    return;
                }


                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        #region properties

        public AnswerModel SelectedAnswer
        {
            get
            {
                return selectedAnswer;
            }
            set
            {
                selectedAnswer = value;
            }
        }

        public bool ShowDeleteButton
        {
            get
            {
                return _showDeleteButton;
            }
            set
            {
                _showDeleteButton = value;
            }
        }

        //public AnswerModel Answer
        //{
        //    get
        //    {
        //       return _answer;
        //    }
        //    set
        //    {
        //        _answer = value;
        //    }
        //}
        public ICommand deleteCommand { get; private set; }
        #endregion
    }
}
