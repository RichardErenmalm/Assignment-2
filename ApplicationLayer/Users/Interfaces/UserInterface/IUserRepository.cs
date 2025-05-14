using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        public List<User> GetUsersFromRepositoryAndDb();
        Task<string> AddUserAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
