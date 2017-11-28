using System;
using System.ComponentModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Extensions;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        UserModel _user;        
        string _repeatPass;
        string _error;
        UserService userService; 

        public CreateUserViewModel()
        {
            //bool check = user.NullEmptyCheck(); 
            User = new UserModel();
            userService = new UserService();
            CreateUserCommand = new Command(CreateUser);
            Error = "";
        }

        // Create user - API call
        async void CreateUser(){

            // check if password matches
            if(User.password != RepeatPass){
                Error = "Kodeord matcher ikke";
                return;
            }

            // Get response from API
            ResponseAPI res = await userService.Create(User);

            // If success pop back to login
            if(res.success){
                INavigation nav = Application.Current.MainPage.Navigation;
                await nav.PopAsync();

            }
            // Else print error message from API response
            else{
                Error = res.message;
            }
        } 

        // Property changed null check
        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #region Properties

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                PropertyChangedCheck("User");
            }
        }

        public string RepeatPass 
        { 
            get{
                return _repeatPass;
            } 
            set{
                _repeatPass = value;
            } 
        }

        public string Error 
        {
            get{
                return _error;
            } 
            set{
                _error = value;
                PropertyChangedCheck("Error");
            } 
        }

        public ICommand CreateUserCommand 
        { 
            get; 
            private set; 
        }

        #endregion
    }
}
