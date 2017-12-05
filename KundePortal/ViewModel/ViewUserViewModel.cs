using KundePortal.Model;
using KundePortal.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using KundePortal.Utility;

namespace KundePortal.ViewModel
{
    public class ViewUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand switchCommand { get; private set; }    
        public ICommand updateCommand { get; private set; }
        public ICommand logoutCommand { get; private set; }
        public ICommand deleteCommand { get; private set; }

        APIService API;
        UserService userService;

        string _alert;
        UserModel _user;
        bool _switchValue;
        public ViewUserViewModel()
        {
            logoutCommand = new Command(Logout);
            updateCommand = new Command(Update);
            deleteCommand = new Command(Delete);

            userService = new UserService();
            _switchValue = new bool();

            _user = new UserModel
            {
            _id = APIService.currentUser._id,
            phone = APIService.currentUser.phone,
            name = APIService.currentUser.name,
            address = APIService.currentUser.address,
            email = APIService.currentUser.email,
            cvr = APIService.currentUser.cvr
            };
            API = new APIService();

            APIService.currentUser = _user;
            
        }

        async void Delete()
        {
                var page = await App.Current.MainPage.DisplayAlert("Slet bruger", "Ønsker du virkelig at slette din bruger?", "Nej", "ja");
                if(page == true)
                {
                    return;
                }
                else
                {
                    ResponseAPI result = await userService.Delete(_user._id);
                    if (result.success)
                    {
                        Alert = result.message;
                    }
                    INavigation nav = Application.Current.MainPage.Navigation;
                    await nav.PopToRootAsync();
                }
        }

        async void Update()
        {
            ResponseAPI result = await userService.Update(_user._id, _user);
            if (result.success)
            {
                await App.Current.MainPage.DisplayAlert("Opdatering af bruger", result.message, "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Opdatering af bruger", result.message, "OK");
                return;
            }
        }

        async void Logout()
        {
            userService.Logout();
            INavigation nav = Application.Current.MainPage.Navigation;
            await nav.PopToRootAsync();
        }

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
            get
            {
                return _user;                
            }
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

        #endregion Properties
    }
}

//HttpClient client;
//string url;
//JsonResponse loggedIn;


//public ViewUserPage()
//{
//    InitializeComponent();

//    client = new HttpClient();
//    //url = ConnectionAPI.Instance.url + "api/users/" + LoginPage.loggedIn.user._id;

//    //loggedIn = LoginPage.loggedIn;

//    nameEntry.Text = loggedIn.user.name;
//    addressEntry.Text = loggedIn.user.address;
//    phoneEntry.Text = loggedIn.user.phone;
//    emailEntry.Text = loggedIn.user.email;
//    tableSectionUser.Title = "Du er logget ind som " + loggedIn.user.name;
//}

//async void updateUserBtn_clickedAsync(object sender, System.EventArgs e)
//{

//    var name = nameEntry.Text;
//    var address = addressEntry.Text;
//    var phone = phoneEntry.Text;
//    var email = emailEntry.Text;
//    var password = passwordEntry.Text;
//    var newPassword = newPasswordEntryAgain.Text;

//    if (!String.IsNullOrEmpty(name) &&
//       !String.IsNullOrEmpty(address) &&
//       !String.IsNullOrEmpty(phone) &&
//        !String.IsNullOrEmpty(email) &&
//        !String.IsNullOrEmpty(password))

//    {
//        User user = new User { _id = loggedIn.user._id, name = name, address = address, phone = phone, email = email, password = password, newPassword = newPassword };
//        if (userSwitch.On && !String.IsNullOrEmpty(newPasswordEntry.Text) && !String.IsNullOrEmpty(newPasswordEntryAgain.Text))
//        {
//            user.newPassword = newPassword;
//        }

//        var userSerial = JsonConvert.SerializeObject(user);
//        //client.DefaultRequestHeaders.Add("token", LoginPage.loggedIn.token);

//        var res = await client.PutAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
//        var content = await res.Content.ReadAsStringAsync();
//        JsonResponse response = JsonConvert.DeserializeObject<JsonResponse>(content);

//        //if(response.statusCode == "1"){
//        //    passwordEntry.LabelColor = Color.Red;
//        //}

//        if (response.success)
//        {
//            //LoginPage.loggedIn = null;
//            await DisplayAlert("Opdateret", "Din bruger er opdateret", "OK");
//            await Navigation.PopToRootAsync();
//        }
//        else
//        {
//            await DisplayAlert("Alert", response.message, "OK");
//        }

//    }
//}

//void logOutBtn_clicked(object sender, System.EventArgs e)
//{
//    //LoginPage.loggedIn = null;
//    Navigation.PopToRootAsync();

//}
