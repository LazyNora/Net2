using SQl_Database.Models;

namespace Server.Helpers
{
    public static class CurrentUser
    {
        private static Employee _currentEmployee;

        public static Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set { _currentEmployee = value; }
        }

        public static bool IsLoggedIn
        {
            get { return _currentEmployee != null; }
        }

        public static void Logout()
        {
            _currentEmployee = null;
        }
    }
}
