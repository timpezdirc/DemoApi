using DemoApi.Models;

namespace DemoApi.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>
        {
            new User { Ime = "Janez", Starost = 23 },
            new User { Ime = "Tone", Starost = 43 },
            new User { Ime = "Tine", Starost = 29 },
            new User { Ime = "Ana", Starost = 33 }
        };

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
