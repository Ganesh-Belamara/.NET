using ProductApi_Task.Data;
using ProductApi_Task.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi_Task.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Where(u => !u.IsDeleted).ToList(); // Only return active users
        }

        public IEnumerable<User> GetAllUsersIncludingDeleted()
        {
            return _context.Users.ToList(); // Return all users including soft-deleted ones
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == userId && !u.IsDeleted);
        }

        public void AddUser(User user)
        {
            user.IsActive = true; // Set active by default
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void SoftDeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
            user.IsDeleted = true; // Mark as soft-deleted
            user.IsActive = false; // Set as inactive
            _context.Users.Update(user);
            _context.SaveChanges();
            }
        }

        public void ToggleUserActiveStatus(int userId, bool isActive)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.IsActive = isActive; // Update active status
                _context.SaveChanges();
            }
        }
    }
}
