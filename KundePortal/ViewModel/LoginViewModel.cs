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
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand loginCommand { get; private set; }
        public ICommand createUserCommand { get; private set; }
        UserService userService; 

        string _username;
        string _password;

        public LoginViewModel()
        {
            userService = new UserService();
            loginCommand = new Command(Login);
            createUserCommand = new Command(CreateUserPush)
        }

        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        async void Login(){

            bool result = userService.Login(_username,_password);

            if(result){
                NavigationPage root = new NavigationPage();
            await Application.Current.MainPage.Navigation.PushAsync(new MainCategoryPage("Main"));
                //await this.PushAsync(new MainCategoryPage("Main"));

            //}
        }

        async void CreateUserPush(){
            
        }

        public string Password
        {
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

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                PropertyChangedCheck("Username");
            }
        }
    }
}
