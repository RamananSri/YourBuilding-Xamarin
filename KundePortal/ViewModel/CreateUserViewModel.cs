using System;
using System.ComponentModel;
using System.Windows.Input;
using KundePortal.Model;
using KundePortal.Services;
using Xamarin.Forms;

namespace KundePortal.ViewModel
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        UserModel _user;
        UserService userService; 

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand createCommand { get; private set; }


        public CreateUserViewModel()
        {
            userService = new UserService();
            createCommand = new Command(CreateUser);
        }

        void CreateUser(){
            if()
            
        } 


        void PropertyChangedCheck(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #region

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                PropertyChangedCheck("User");
            }
        }

        #endregion
    }
}

//HttpClient client;
//string url;
//User user;

//public CreateUserPage()
//{
//    user = new User();
//    client = new HttpClient();
//    url = ConnectionAPI.Instance.url + "create";
//    InitializeComponent();
//}

//async Task createUserBtn_clickedAsync(object sender, System.EventArgs e)
//{
//    user.name = nameEntry.Text;
//    user.address = addressEntry.Text;
//    user.phone = phoneEntry.Text;
//    user.email = emailEntry.Text;
//    user.password = passwordEntry.Text;

//    if (!String.IsNullOrEmpty(nameEntry.Text) &&
//       !String.IsNullOrEmpty(addressEntry.Text) &&
//       !String.IsNullOrEmpty(phoneEntry.Text) &&
//       !String.IsNullOrEmpty(emailEntry.Text) &&
//        !String.IsNullOrEmpty(passwordEntry.Text))
//    {
//        if (!string.IsNullOrEmpty(cvrEntry.Text))
//        {
//            user.cvr = cvrEntry.Text;
//        }

//        var userSerial = JsonConvert.SerializeObject(user);
//        await client.PostAsync(url, new StringContent(userSerial, Encoding.UTF8, "application/json"));
//        await Navigation.PopAsync();
//    }
//}
