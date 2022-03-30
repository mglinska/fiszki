using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class CollectionRepository : ICollectionRepository {

        private readonly AppDbContext _context;

        public CollectionRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Collection>> GetAllCollections() {
            return await _context.Collections.ToListAsync();
        }

        public async Task<Collection> GetCollectionById( int collectionId ) {
            return await _context.Collections.FirstOrDefaultAsync(c => c.Id_collection == collectionId);
        }

        public async Task<Collection> GetCollectionByName( string name ) {
            return await _context.Collections.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Collection> CreateCollection( Collection collection ) {
            var result = await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Collection> UpdateCollection( Collection collection ) {
            var result = await _context.Collections.FirstOrDefaultAsync(c => c.Id_collection == collection.Id_collection);

            if (result != null) {
                result.Id_collection = collection.Id_collection;
                result.Name = collection.Name;
                result.Created_on = collection.Created_on;
                result.Description = collection.Description;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<string> DeleteCollection( int collectionId ) {
            try {
                var result = await _context.Collections.FirstOrDefaultAsync(c => c.Id_collection == collectionId);

                if (result != null) {
                    _context.Collections.Remove(result);
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
