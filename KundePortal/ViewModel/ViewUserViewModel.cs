using System;
namespace KundePortal.ViewModel
{
    public class ViewUserViewModel
    {
        public ViewUserViewModel()
        {
        }
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
