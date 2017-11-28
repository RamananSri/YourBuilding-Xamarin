﻿using KundePortal.Model;
using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class AnswerQuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand answerQuestionCommand { get; private set; }


        AnswerModel _answer;
        AnswerService answerService;
        string _alert;
        QuestionModel _question;
        public static QuestionModel question;

        public AnswerQuestionViewModel()
        {   
            answerQuestionCommand = new Command(answerQuestion);

            this._question = question;            
            _answer = new AnswerModel();
            //_answer.description = "answer virker";
            answerService = new AnswerService();
        }

        async void answerQuestion()
        {
            DateTime now = DateTime.Now.ToLocalTime().AddHours(1);
            _answer.answerDate = Convert.ToString(now);
            ResponseAPI result = await answerService.Create(Answer);
            if (result.success)
            {
                Alert = result.message;
            }
            else
            {
                Alert = result.message;
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

        public string Alert
        {
            get
            {
                return _alert;
            }
            set
            {
                _alert = value;
                PropertyChangedCheck("Alert");
            }
        }

        #endregion

    }
}
