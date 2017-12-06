using KundePortal.Model;
using KundePortal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    public class CreateQuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand createQuestionCommand { get; private set; }

        ObservableCollection<string> _categoryList;
        ObservableCollection<string> _subCategoryList;

        QuestionModel _question;
        QuestionService questionService;

        string _categoryPicker;
        string _subCategoryPicker;

        public CreateQuestionViewModel()
        {
            createQuestionCommand = new Command(createQuestion);

            _categoryList = new ObservableCollection<string>();
            _subCategoryList = new ObservableCollection<string>();
            _question = new QuestionModel();
            questionService = new QuestionService();
            _categoryList.Add("hej");
            _subCategoryList.Add("hejhej");
        }

        async void createQuestion()
        {
            if(string.IsNullOrEmpty(_question.title)&&
               string.IsNullOrEmpty(_question.description)&&
               string.IsNullOrEmpty(_categoryPicker)&&
               string.IsNullOrEmpty(_subCategoryPicker))
            {
                await Application.Current.MainPage.DisplayAlert("Opretning af spørgsmål", "udfyld venligst alle felter", "OK");
                return;
            }
            ResponseAPI result = await questionService.Create(Question);
            if (result.success)
            {
                await Application.Current.MainPage.DisplayAlert("Opretning af spørgsmål", result.message, "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Opretning af spørgsmål", result.message, "OK");
            }
        }



        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
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

        public ObservableCollection<string> CategoryList
        {
            get => _categoryList;

            set
            {
                _categoryList = value;
            }
        }

        public ObservableCollection<string> SubCategoryList
        {
            get => _subCategoryList;

            set
            {
                _subCategoryList = value;
            }
        }

        public string CategoryPicker
        {
            get => _categoryPicker;
            set
            {
                _categoryPicker = value;
                Question.category = value;
                PropertyChangedCheck("CategoryPicker");
            }
        }

        public string SubCategoryPicker
        {
            get => _subCategoryPicker;
            set
            {
                _subCategoryPicker = value;
                Question.subCategory = value;
                PropertyChangedCheck("SubCategoryPicker");
            }
        }
        #endregion

    }
}
