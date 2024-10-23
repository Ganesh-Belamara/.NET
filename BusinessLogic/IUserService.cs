using ProductApi_Task.DTOs;
using System.Collections.Generic;

namespace ProductApi_Task.BusinessLogic
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers(); // Get all users
        IEnumerable<UserDTO> GetAllUsersIncludingDeleted(); // Get all users including deleted
        UserDTO GetUserById(int id); // Get a user by ID
        void AddUser(UserDTO userDto); // Add a new user
        void UpdateUser(UserDTO userDto); // Update an existing user
        void SoftDeleteUser(int id); // Soft delete a user
        
    }
}
