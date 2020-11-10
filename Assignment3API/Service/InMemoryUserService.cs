using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3API.Model;

namespace Assignment3API.Data
{
    public class InMemoryUserService : IUserService 
    {
        private List<User> users;

        public InMemoryUserService() {
            users = new[] {
                new User {
                    Password = "123456",
                    Role = "user",
                    UserName = "filipina"
                },
                new User {
                    
                    Password = "123456",
                    Role = "admin",
                    UserName = "eva"
                },
                new User {
                    Password = "1234",
                    Role = "collector",
                    UserName = "levente"
                }
            }.ToList();
        }

        public async Task<User> ValidateUser(string userName, string passWord)
        {
            User user = users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(passWord));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }
    }
}