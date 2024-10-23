using ProductApi_Task.Models;
using System.Collections.Generic;

namespace ProductApi_Task.DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllUsersIncludingDeleted(); // Keep this for including soft-deleted users
        User GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void SoftDeleteUser(int userId); // Keep this for soft deleting users
        void ToggleUserActiveStatus(int userId, bool isActive);
    }
}
