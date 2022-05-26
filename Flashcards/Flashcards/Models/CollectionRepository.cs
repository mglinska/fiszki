using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class CollectionRepository : ICollectionRepository {

        private readonly AppDbContext _context;

        public CollectionRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Collection>> GetAllCollections() {
            return await _context.Collection.ToListAsync();
        }

        public async Task<Collection> GetCollectionById( int collectionId ) {
            return await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == collectionId);
        }

        public async Task<Collection> GetCollectionByName( string name ) {
            return await _context.Collection.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Collection> CreateCollection( Collection collection, int userId ) {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id_user == userId);

            if (user != null) {
                var allCollectionsUser = await _context.Collection_user.Where(u => u.Id_user == userId).ToListAsync();

                foreach (var col in allCollectionsUser) {
                    Collection collectionU = await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == col.Id_collection);

                    if(collectionU.Name == collection.Name) {
                        collection.Id_collection = -1;

                        return collection;
                    }
                }

                var result = await _context.Collection.AddAsync(collection);
                await _context.SaveChangesAsync();

                CollectionUser collectionUser = new CollectionUser();
                collectionUser.Id_collection = result.Entity.Id_collection;
                collectionUser.Id_user = userId;
                collectionUser.Rights = "owner";
                collectionUser.Study_time = 0;

                await _context.Collection_user.AddAsync(collectionUser);

                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        public async Task<Collection> UpdateCollection( Collection collection, int userId ) {
            var result = await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == collection.Id_collection);

            if (result != null) {
                //result.Id_collection = collection.Id_collection;
                //result.Name = collection.Name;
                //result.Created_on = collection.Created_on;
                //result.Description = collection.Description;

                var allCollectionsUser = await _context.Collection_user.Where(u => u.Id_user == userId).ToListAsync();

                foreach (var col in allCollectionsUser) {
                    Collection collectionU = await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == col.Id_collection);

                    if (collectionU != null) {
                        if (collectionU.Name == collection.Name) {
                            result.Id_collection = -1;

                            return result;
                        }
                    }
                }

                _context.Entry(result).CurrentValues.SetValues(collection);
                await _context.SaveChangesAsync();


                return result;
            }

            return null;
        }

        public async Task<string> DeleteCollection( int collectionId ) {
            try {
                var result = await _context.Collection.FirstOrDefaultAsync(c => c.Id_collection == collectionId);

                if (result != null) {
                    var flashcards = await _context.Flashcard.Where(f => f.Id_collection == collectionId).ToListAsync();

                    if (flashcards != null) {
                        foreach (var flashcard in flashcards) {
                            _context.Flashcard.Remove(flashcard);
                            await _context.SaveChangesAsync();
                        }
                    }

                    var collectionUser = await _context.Collection_user.FirstOrDefaultAsync(cu => cu.Id_collection == collectionId);

                    if (collectionUser != null) {
                        _context.Collection_user.Remove(collectionUser);
                        await _context.SaveChangesAsync();
                    }

                    _context.Collection.Remove(result);
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
