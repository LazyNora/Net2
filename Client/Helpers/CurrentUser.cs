using SQl_Database.Models;

namespace Client.Helpers
{
    public static class CurrentUser
    {
        private static Customer _currentCustomer;

        public static Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set { _currentCustomer = value; }
        }

        public static bool IsLoggedIn
        {
            get { return _currentCustomer != null; }
        }

        public static void Logout()
        {
            _currentCustomer = null;
        }
    }
}
