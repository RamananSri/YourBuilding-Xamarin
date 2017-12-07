using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Utility;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class MyQuestionsViewModel
    {
        ObservableCollection<QuestionModel> _myQuestions;
        public static QuestionModel _selectedItem;
        QuestionService qService;


        public MyQuestionsViewModel()
        {
            _myQuestions = new ObservableCollection<QuestionModel>();
            qService = new QuestionService();
            GetMyQuestions();
        }

        async void Navigate()
        {
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new QuestionView());
        }

        async void GetMyQuestions()
        {
            List<QuestionModel> myQuestions = await qService.GetByUserID(APIService.currentUser._id);
            if(myQuestions != null){
                foreach (var item in myQuestions)
                {
                    _myQuestions.Add(item);
                }
            }
        }

        public ObservableCollection<QuestionModel> MyQuestions 
        {
            get => _myQuestions;
            set{_myQuestions = value;} 
        }

        public QuestionModel SelectedCategory 
        {
            get =>  _selectedItem; 
            set
            {
                _selectedItem = value;
                if(_selectedItem != null){
                    Navigate();
                }
            }
        }
    }
}
