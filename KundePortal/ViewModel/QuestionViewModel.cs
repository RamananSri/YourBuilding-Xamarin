using KundePortal.Model;
using KundePortal.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand openAnswerQuestionCommand { get; private set; }

        QuestionModel _question;

        ObservableCollection<AnswerModel> _answerList;

        public QuestionViewModel()
        {
            openAnswerQuestionCommand = new Command(answerQuestion);

            _question = new QuestionModel();
            _question.description = "Dette er spørgsmålet";
            _question.picture = "http://via.placeholder.com/350x150";
            AnswerList = new ObservableCollection<AnswerModel>();
            _answerList = new ObservableCollection<AnswerModel>();
            AnswerModel answer = new AnswerModel
            {
                answerDate = null,
                likeCounter = null,
                description = "Det virker",
                userId = "1",
                userName = "Daniel"
            };
            _answerList.Add(answer);
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

        


        #endregion


    }
}
