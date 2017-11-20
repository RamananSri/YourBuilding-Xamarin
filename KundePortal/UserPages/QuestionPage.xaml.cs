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
            URL = ConnectionAPI.Instance.url + "API/questions/" + subCategory;
            _client = new HttpClient();
            questions = new ObservableCollection<Question>();

            InitializeComponent();

            getQuestions();
        }

        async void getQuestions(){
            _client.DefaultRequestHeaders.Add("token", LoginPage.loggedIn.token);
            var content = await _client.GetStringAsync(URL);
            List<Question> quests = JsonConvert.DeserializeObject<List<Question>>(content);
            questions = new ObservableCollection<Question>(quests);
            questionList.ItemsSource = questions;
        }

        async void CreateQuestion_clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NewQuestionPage(subCategory));
        }

        async void Question_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var selected = (ListView)sender;

            await Navigation.PushAsync(new ViewQuestion((Question)selected.SelectedItem));
        }
    }
}
