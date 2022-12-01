using PoointWebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoointWebApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertUser(UserLogIn user);
        Task<User> GetUserLogin(UserLogIn user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UpdateUserStatus(User user);
    }
}
