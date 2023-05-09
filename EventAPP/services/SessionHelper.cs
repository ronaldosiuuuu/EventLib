using System.Text.Json;

namespace EventAPP.services
{
    public static class SessionHelper
    {
        private const String Key = "User";
        public static void SetUser(IUserRepository service, HttpContext context)
        {
            String json = JsonSerializer.Serialize(service);
            context.Session.SetString(Key, json);
        }

        public static IUserRepository GetUser(HttpContext context)
        {
            String? json = context.Session.GetString(Key);

            if(json is not null)
            {
                return JsonSerializer.Deserialize<UserRepository>(json);
            }

            UserRepository ur = new UserRepository();
            ur.UserLoggedOut();
            return ur;
        }
    }
}
