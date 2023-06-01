using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
        User GetUserByUsername(string username);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}