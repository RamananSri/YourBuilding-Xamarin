using System.ComponentModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using KundePortal.View;
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
        string _alert;

        public LoginViewModel()
        {
            userService = new UserService();
            loginCommand = new Command(Login);
            createUserCommand = new Command(CreateUserPush);
        }

        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        async void Login()
        {
            Alert = "";
            ResponseAPI result = await userService.Login(_username, _password);

            if (result.success && APIService.token != null)
            {
                if (APIService.currentUser.cvr != null)
                {
                    INavigation nav = Application.Current.MainPage.Navigation;
                    await nav.PushAsync(new LoginView());

                    // pro page
                }
                else
                {
                    // user page
                }
            }
            else
            {
                Alert = "Prøv igen";
            }
        }

        void CreateUserPush()
        {
            // create page    

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
        public string Alert
        {
            get
            {
                return _alert;
            }
            set
            {
                _alert = value;
                PropertyChangedCheck("Alert");
            }
        }

        #endregion
    }
}
