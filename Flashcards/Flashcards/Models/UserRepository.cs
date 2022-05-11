using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _context;

        public UserRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers() {
            List<User> users = await _context.User.ToListAsync();

            if (users != null) {
                foreach (User user in users) {
                    user.Password = "";
                }
            }

            return users;
        }

        public async Task<User> GetUserById( int userId ) {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Id_user == userId);
            if (user != null) {
                user.Password = "";
            }

            return user;
        }

        public async Task<User> GetUserByLogin( string login ) {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Email == login);

            return user;
        }

        public async Task<User> RegisterUser( User user ) {
            var result = await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> UpdateUser( User user ) {
            var result = await _context.User.FirstOrDefaultAsync(u => u.Id_user == user.Id_user);

            if (result != null) {
                //result.Email = user.Email;
                //result.Password = user.Password;
                //result.First_name = user.First_name;
                //result.Is_admin = user.Is_admin;

                _context.Entry(result).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();

                result.Password = "";

                return result;
            }

            return null;
        }

        public async Task<string> DeleteUser( int userId ) {
            try {
                var result = await _context.User.FirstOrDefaultAsync(u => u.Id_user == userId);

                if (result != null) {
                    var collectionUser = await _context.Collection_user.FirstOrDefaultAsync(cu => cu.Id_user == userId);

                    if(collectionUser != null) {
                        var collections = await _context.Collection.Where(c => c.Id_collection == collectionUser.Id_collection).ToListAsync();

                        foreach (var collection in collections) {
                            if (collection != null) {
                                var flashcards = await _context.Flashcard.Where(f => f.Id_collection == collection.Id_collection).ToListAsync();

                                if (flashcards != null) {
                                    foreach (var flashcard in flashcards) {
                                        _context.Flashcard.Remove(flashcard);
                                        await _context.SaveChangesAsync();
                                    }
                                }

                                _context.Collection.Remove(collection);
                                await _context.SaveChangesAsync();
                            }
                        }

                        _context.Collection_user.Remove(collectionUser);
                        await _context.SaveChangesAsync();
                    }

                    _context.User.Remove(result);
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
