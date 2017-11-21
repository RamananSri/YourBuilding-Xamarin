using System;
namespace KundePortal.Model
{
    public class UserModel
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string cvr { get; set; }
    }
}
