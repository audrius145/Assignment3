using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using WebApplication7.Model;

namespace WebApplication7.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string UsernName, string Password);
        

      
        
    }
}