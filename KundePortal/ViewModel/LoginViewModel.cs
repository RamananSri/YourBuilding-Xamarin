using System.ComponentModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.Utility;
using KundePortal.View;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{

    // nedarver fra INotifyPropertyChanged - håndterer ændringer fra viewmodel -> view
    public class LoginViewModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged event som raises ved ændringer. 
        // Alle bindings i view der binder på den ændrede property får besked
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand loginCommand { get; private set; }
        public ICommand CreateUserCommand { get; private set; }
        UserService userService;

        string _username;
        string _password;

        public LoginViewModel()
        {
            userService = new UserService();
            loginCommand = new Command(Login);
            CreateUserCommand = new Command(CreateUserPush);
        }

        // INotifyPropertyChanged check. Er der en ikke-null ændring? 
        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        // Login - call API, check if success and determine if pro or not pro
        async void Login()
        {
            ResponseAPI result = await userService.Login(_username, _password);

            if (result.success && APIService.token != null)
            {
                APIService.currentUser = result.user;
                APIService.token = result.token;

                INavigation nav = Application.Current.MainPage.Navigation;
                //CategoryView view = new CategoryView{HasBackButton=false};

                if (APIService.currentUser.cvr != null)
                {
                    await nav.PushAsync(new ProMenuView());
                }
                else
                {
                    await nav.PushAsync(new MyUserView());
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login", result.message, "OK");
                return;
            }
        }

        // Push createUserView command
        async void CreateUserPush(){
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PushAsync(new CreateUserView());   
        }

        #region Properties

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                PropertyChangedCheck("Password");   // Raise event om at "Password" er ændret
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
                PropertyChangedCheck("Username");   // Raise event om at "Username" er ændret 
            }
        }

        #endregion
    }
}
