using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class CollectionUserRepository : ICollectionUserRepository {

        private readonly AppDbContext _context;

        public CollectionUserRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Collection>> GetAllCollectionsByUserId( int userId ) {
            var restult = await _context.Collection_user.Where(u => u.Id_user == userId).ToListAsync();

            if (restult != null) {
                List<Collection> collectionsUser = new List<Collection>();

                foreach (var item in restult) {
                    var collection = await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == item.Id_collection);
                    if(collection  != null) {
                        collectionsUser.Add(collection);
                    }
                }

                return collectionsUser;
            }

            return null;
        }

    }
}
