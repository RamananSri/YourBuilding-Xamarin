using System;
using System.Collections.Generic;
using KundePortal.Models;
using Xamarin.Forms;

namespace KundePortal.UserPages
{
    public partial class ViewQuestion : ContentPage
    {
        public ViewQuestion(Question question)
        {
            InitializeComponent();

            Answer ans = new Answer { likeCounter = "10", answerDate = DateTime.Now.ToString(), userName = "Brian", description = "Hvordan bygger man et hus", userId = "1" };
            question.answers.Add(ans);
           
            var question2 = question; 
            questionStack.BindingContext = question;
            answerList.ItemsSource = question.answers;
        }
    }
}
