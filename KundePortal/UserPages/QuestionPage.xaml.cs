using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using KundePortal.Models;
using System.Collections.ObjectModel;

namespace KundePortal.UserPages
{
    public partial class QuestionPage : ContentPage
    {
        string subCategory;
        string URL;
        HttpClient _client;
        ObservableCollection<Question> questions;

        public QuestionPage(string subCategory)
        {
            this.subCategory = subCategory;
            URL = ConnectionAPI.Instance.url + "API/question/" + subCategory;
            _client = new HttpClient();
            questions = new ObservableCollection<Question>();

            InitializeComponent();

            getQuestions();
            questionList.ItemsSource = questions;
        }

        async void getQuestions(){
            var content = await _client.GetStringAsync(URL);
            List<Question> questionList = JsonConvert.DeserializeObject<List<Question>>(content);
            questions = new ObservableCollection<Question>(questionList);
        }

        void CreateQuestion_clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void Question_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            
        }
    }
}
