using System;
namespace KundePortal.Model
{
    public class ResponseAPI
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public UserModel user { get; set; }
    }
}
