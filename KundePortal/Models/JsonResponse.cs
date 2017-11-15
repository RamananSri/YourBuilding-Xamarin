using System;
namespace KundePortal.Models
{
    public class JsonResponse
    {
        public string token
        {
            get;
            set;
    
        }
        public string message
        {
            get;
            set;
        }

        public bool success
        {
            get;
            set;
        }

        public string statusCode
        {
            get;
            set;
        }

        public User user
        {
            get;
            set;
        }
    }
}
