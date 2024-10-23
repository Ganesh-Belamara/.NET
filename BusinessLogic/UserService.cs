using ProductApi_Task.DTOs;
using System.Collections.Generic;
using ProductApi_Task.DataAccess;
using ProductApi_Task.Models;
using System.Linq;
using System;

namespace ProductApi_Task.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers().Select(u => new UserDTO
            {
                UserID = u.UserID,
                UserName = u.UserName,
                Email = u.Email,
                IsActive = u.IsActive // Include active status in DTO
            });
        }

        public IEnumerable<UserDTO> GetAllUsersIncludingDeleted()
        {
            return _userRepository.GetAllUsersIncludingDeleted().Select(u => new UserDTO
            {
                UserID = u.UserID,
                UserName = u.UserName,
                Email = u.Email,
                IsActive = u.IsActive // Include active status in DTO
            });
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null) return null;

            return new UserDTO
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive // Include active status in DTO
            };
        }

        public void AddUser(UserDTO userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                CreatedDate = DateTime.UtcNow, // Set created date to now
                IsActive = true, // Set active status to true
                IsDeleted = false // Ensure user is not marked as deleted upon creation
            };
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UserDTO userDto)
        {
            var user = _userRepository.GetUserById(userDto.UserID);
            if (user != null)
            {
                user.UserName = userDto.UserName;
                user.Email = userDto.Email;
                // Active status should not be updated here
                _userRepository.UpdateUser(user);
            }
        }

        public void SoftDeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false; // Set active status to false
               _userRepository.UpdateUser(user); // Update the user in the repository
            }
        }
    }
}
