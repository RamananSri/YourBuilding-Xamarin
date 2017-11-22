using System;
namespace KundePortal.ViewModel
{
    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {
        }
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
