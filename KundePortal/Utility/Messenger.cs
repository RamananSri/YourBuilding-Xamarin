using System;
namespace KundePortal.Utility
{
    public class Messenger
    {
        static Messenger _instance;

        private Messenger()
        {
        }

        // Singleton instance management
        public static Messenger GetInstance{
            get
            {
                if (_instance == null)
                {
                    _instance = new Messenger();
                }
                return _instance;
            }
        }
    }
}
