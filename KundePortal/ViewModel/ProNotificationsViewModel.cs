using KundePortal.Model;
using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class ProNotificationsViewModel
    {
        ObservableCollection<string> _categoryList;
        ObservableCollection<QuestionModel> _questionList;
        APIService API;
        string baseRoute;
        QuestionService questionService;
        AnswerService answerService;
        string _pickerValue;

        public ProNotificationsViewModel()
        {
            baseRoute = "api/questions/";
            API = new APIService();
            _categoryList = new ObservableCollection<string>();
            _questionList = new ObservableCollection<QuestionModel>();
            questionService = new QuestionService();
            answerService = new AnswerService();
            getSub();
        }

        public void getSub()
        {
            var subList = answerService.getSubCategories();
            CategoryList = new ObservableCollection<string>(subList);
        }

        public string pickerValue
        {
            get => _pickerValue;
            set
            {
                _pickerValue = value;
                getQuestionsBySub();
            }
        }

        async void getQuestionsBySub()
        {
            List<QuestionModel> questions = await questionService.GetBySubcategory(pickerValue);
            QuestionList = new ObservableCollection<QuestionModel>(questions);
        }

        public ObservableCollection<string> CategoryList
        {
            get => _categoryList;

            set {
                _categoryList = value;
            }
        }

        public ObservableCollection<QuestionModel> QuestionList
        {
            get => _questionList;

            set
            {
                _questionList = value;
            }
        }

    }
}
