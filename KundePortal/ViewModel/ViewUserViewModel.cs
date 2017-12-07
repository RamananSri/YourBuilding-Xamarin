#region imports
using KundePortal.Model;
using KundePortal.Services;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;
using KundePortal.View;
#endregion

namespace KundePortal.ViewModel
{
    public class ViewUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        APIService API;
        UserService userService;

        UserModel _user;
        bool _switchValue;
        string _passValidation;

        // Constructor
        public ViewUserViewModel()
        {         
            userService = new UserService();
            API = new APIService();
            initCommands();
            loadCurrentUser();
        }

        // Initialise commands
        void initCommands()
        {
            logoutCommand = new Command(Logout);
            updateCommand = new Command(Update);
            deleteCommand = new Command(Delete);
            myQuestionsCommand = new Command(MyQuestions);
        }

        // Navigate to my questions view
        async void MyQuestions()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MyQuestionsView());
        }

        // Fill viewmodel user with information from current user 
        void loadCurrentUser()
        {
            _user = new UserModel
            {
                _id = APIService.currentUser._id,
                phone = APIService.currentUser.phone,
                name = APIService.currentUser.name,
                address = APIService.currentUser.address,
                email = APIService.currentUser.email,
                cvr = APIService.currentUser.cvr
            };
        }

        // Delete user (validating action with dialog)
        async void Delete()
        {
            var page = await Application.Current.MainPage.DisplayAlert("Slet bruger", "Ønsker du at slette din bruger?", "Nej", "ja");
                
            if(!page)
            {
                ResponseAPI result = await userService.Delete(_user._id);
                if (!result.success)
                {
                    await Application.Current.MainPage.DisplayAlert("Fejl", result.message, "OK");
                    return;
                }
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        // Update user  
        async void Update()
        {
            // Check if entries are empty  
            if(string.IsNullOrEmpty(_user.name) ||
               string.IsNullOrEmpty(_user.address) ||
               string.IsNullOrEmpty(_user.email) ||
               string.IsNullOrEmpty(User.phone))
            {
                await Application.Current.MainPage.DisplayAlert("Opdatering af bruger", "Udfyld venligst alle felter", "OK");
                return;           
            }

            // Check if new password matches if present
            if(_switchValue && _user.newPassword != _passValidation){
                await Application.Current.MainPage.DisplayAlert("Opdatering af bruger", "Nye kodeord matcher ikke", "OK");
                return; 
            }

            // Call API to update user
            ResponseAPI result = await userService.Update(_user._id, _user);

                // If successs show dialog, update currentuser and pop page
                if (result.success)
                {
                    await Application.Current.MainPage.DisplayAlert("Opdatering af bruger", result.message, "OK");
                    APIService.currentUser.name = _user.name;
                    APIService.currentUser.address = _user.address;
                    APIService.currentUser.email = _user.email;
                    APIService.currentUser.phone = _user.phone;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Opdatering af bruger", result.message, "OK");
                }           
        }

        // Logout
        async void Logout()
        {
            userService.Logout();
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        // PropertyChanged check
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

        public bool SwitchValue
        {
            get => _switchValue;

            set
            {
                _switchValue = value;
                PropertyChangedCheck("SwitchValue");
            }
        }

        public string PassValidation 
        {
            get => _passValidation; 

            set
            {
                _passValidation = value;
            } 
        }

        public ICommand myQuestionsCommand { get; private set; }
        public ICommand updateCommand { get; private set; }
        public ICommand logoutCommand { get; private set; }
        public ICommand deleteCommand { get; private set; }

        #endregion Properties
    }
}
