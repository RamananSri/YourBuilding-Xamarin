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
        public static AnswerModel _selectedAnswer;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand openAnswerQuestionCommand { get; private set; }

        QuestionModel _question;

        ObservableCollection<AnswerModel> _answerList;

        public QuestionViewModel()
        {
            openAnswerQuestionCommand = new Command(answerQuestion);



            _question = AllQuestionsViewModel._selectedQuestion;
            _answerList = new ObservableCollection<AnswerModel>(_question.answers);

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
        


        #endregion


    }
}
