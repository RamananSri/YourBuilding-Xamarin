using KundePortal.Model;
using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    public class AnswerQuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand answerQuestionCommand { get; private set; }


        AnswerModel _answer;
        AnswerService answerService;
        QuestionModel _question;
        public static QuestionModel question;
        string questionId;

        public AnswerQuestionViewModel()
        {
            questionId = QuestionViewModel._question._Id;
            answerQuestionCommand = new Command(answerQuestion);

            this._question = question;            
            _answer = new AnswerModel();
            //_answer.description = "answer virker";
            answerService = new AnswerService();
        }

        async void answerQuestion()
        {
            _answer.qId = question._Id;
            _answer.likeCounter = "0";
            _answer.userId = APIService.currentUser._id;
            _answer.userName = APIService.currentUser.name;
            DateTime now = DateTime.Now.ToLocalTime().AddHours(1);
            _answer.answerDate = Convert.ToString(now);
            ResponseAPI result = await answerService.Create(Answer);
            if (result.success)
            {
                await App.Current.MainPage.DisplayAlert("Svar på spørgsmål", result.message, "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Svar på spørgsmål", result.message, "OK");
            }
        }

        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #region

        public AnswerModel Answer
        {
            get => _answer;

            set
            {
                _answer = value;
            }
        }

        public QuestionModel Question
        {
            get => _question;

            set
            {
                _question = value;
            }
        }

        #endregion

    }
}
