using KundePortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundePortal.ViewModel
{
    public class AnswerViewModel
    {
        QuestionViewModel qsView;
        AnswerModel selectedAnswer;

        public AnswerViewModel()
        {
            qsView = new QuestionViewModel();
            selectedAnswer = qsView.SelectedAnswer;
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
        #endregion
    }
}
