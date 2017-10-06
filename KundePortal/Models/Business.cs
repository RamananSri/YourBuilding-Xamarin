using System;
namespace KundePortal.Models
{
    public class Business : User
    {
        public string CVR
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public Business()
        {
        }
    }
}
