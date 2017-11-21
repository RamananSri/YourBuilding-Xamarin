using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KundePortal.Models;
using Xamarin.Forms;

namespace KundePortal.UserPages
{
    public partial class ViewQuestion : ContentPage
    {
        Question selectedQuestion;
        ObservableCollection<Answer> obsanswerList;

        public ViewQuestion(Question question)
        {
            InitializeComponent();

            selectedQuestion = question;
            obsanswerList = new ObservableCollection<Answer>();

            foreach (var answer in question.answers)
            {
                obsanswerList.Add(answer);
            }

            questionStack.BindingContext = selectedQuestion;
            answerList.ItemsSource = obsanswerList;
        }
    }
}
