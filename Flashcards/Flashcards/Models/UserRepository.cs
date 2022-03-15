using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _context;

        public UserRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers() {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById( int userId ) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByLogin( string login ) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == login);
        }

        public async Task<User> RegisterUser( User user ) {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser( User user ) {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (result != null) {
                result.Email = user.Email;
                result.Password = user.Password;
                result.Name = user.Name;
                result.Surname = user.Surname;
                result.Is_admin = user.Is_admin;
                result.Is_blocked = user.Is_blocked;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<string> DeleteUser( int userId ) {
            try {
                var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (result != null) {
                    _context.Users.Remove(result);
                    await _context.SaveChangesAsync();

                    return "Operation successful!";
                }

                return "Operation failed!";
            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
