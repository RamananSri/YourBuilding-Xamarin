using System;
using System.ComponentModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.UserPages;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private LoginService loginService;
        private string _token;
        private string _username;
        private string _password;

        public string Token { 
            get { 
                return _token; 
            } 
            set{
                _token = value;
                PropertyChangedCheck("Token");
            } 
        }

        public string Username{
            get{
                return _username;
            }
            set{
                _username = value;
                PropertyChangedCheck("Username");
            }
        }

        public string Password{
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                PropertyChangedCheck("Password");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand changeLabelCommand { get; private set; }

        public LoginViewModel()
        {
            Token = "Not logged in";
            loginService = new LoginService();
            changeLabelCommand = new Command(Login);
        }

        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        async void Login(){

            //bool result = loginService.Login(_username,_password);

            //if(result){
                NavigationPage root = new NavigationPage();
            await Application.Current.MainPage.Navigation.PushAsync(new MainCategoryPage("Main"));
                //await this.PushAsync(new MainCategoryPage("Main"));

            //}
        }
    }
}
