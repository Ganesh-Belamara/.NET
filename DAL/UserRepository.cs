using ProductApi_Task.Data;
using ProductApi_Task.Models;

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
            var activeUsers = _context.Users.Where(u => u.IsActive).ToList(); // Only return active users
            var inactiveUsers = _context.Users.Where(u => !u.IsActive).ToList(); // Only return active users
            return activeUsers;

        }

        public IEnumerable<User> GetAllUsersIncludingDeleted()
        {
            return _context.Users.ToList(); // Will return active & inactive users
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
            //user.IsDeleted = true; // Mark as soft-deleted
            user.IsActive = false; // Set as inactive
            _context.Users.Update(user);
            _context.SaveChanges();
            }
        }

    }
}
