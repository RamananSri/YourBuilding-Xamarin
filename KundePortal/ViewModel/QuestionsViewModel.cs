using System;
namespace KundePortal.ViewModel
{
    public class QuestionsViewModel
    {
        public QuestionsViewModel()
        {
        }
    }
}

//string subCategory;
//string URL;
//HttpClient _client;
//ObservableCollection<Question> questions;

//public QuestionPage(string subCategory)
//{
//    this.subCategory = subCategory;
//    URL = ConnectionAPI.Instance.url + "API/questions/" + subCategory;
//    _client = new HttpClient();
//    questions = new ObservableCollection<Question>();

//    InitializeComponent();

//    getQuestions();
//}

//async void getQuestions()
//{
//    //_client.DefaultRequestHeaders.Add("token", LoginPage.loggedIn.token);
//    var content = await _client.GetStringAsync(URL);
//    List<Question> quests = JsonConvert.DeserializeObject<List<Question>>(content);
//    questions = new ObservableCollection<Question>(quests);
//    questionList.ItemsSource = questions;
//}

//async void CreateQuestion_clicked(object sender, EventArgs e)
//{
//    await Navigation.PushModalAsync(new NewQuestionPage(subCategory));
//}

//async void Question_selected(object sender, SelectedItemChangedEventArgs e)
//{
//    if (e.SelectedItem is Question)
//    {
//        Question question = (Question)e.SelectedItem;
//        await Navigation.PushAsync(new ViewQuestion((question)));
//    }
//    else
//    {
//        await DisplayAlert("ERROR", "Objekt er ikke et question", "OK");
//    }
//}
