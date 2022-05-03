using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class FlashcardRepository : IFlashcardRepository {

        private readonly AppDbContext _context;

        public FlashcardRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Flashcard>> GetAllFlashcards() {
            return await _context.Flashcard.ToListAsync();
        }

        public async Task<Flashcard> GetFlashcardById( int flashcardId ) {
            return await _context.Flashcard.FirstOrDefaultAsync(c => c.Id_flashcard == flashcardId);
        }
        
        public async Task<List<Flashcard>> GetFlashcardsByCollectionId( int collectionId ) {
            return await _context.Flashcard.Where(c => c.Id_collection == collectionId).ToListAsync();
        }

        public async Task<Flashcard> CreateFlashcard( Flashcard flashcard, int userId ) {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id_user == userId);

            if (user != null) {
                var result = await _context.Flashcard.AddAsync(flashcard);
                await _context.SaveChangesAsync();

                FlashcardUser flashcardUser = new FlashcardUser();
                flashcardUser.Id_flashcard = result.Entity.Id_flashcard;
                flashcardUser.Id_user = userId;
                flashcardUser.Memorized = 0;

                await _context.Flashcard_user.AddAsync(flashcardUser);

                await _context.SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        public async Task<Flashcard> UpdateFlashcard( Flashcard flashcard ) {
            var result = await _context.Flashcard.FirstOrDefaultAsync(c => c.Id_flashcard == flashcard.Id_flashcard);

            if (result != null) {
                //result.Id_flashcard = flashcard.Id_flashcard;
                //result.Id_collection = flashcard.Id_collection;
                //result.Answer = flashcard.Answer;
                //result.Question = flashcard.Question;

                _context.Entry(result).CurrentValues.SetValues(flashcard);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<string> DeleteFlashcard( int flashcardId ) {
            try {
                var result = await _context.Flashcard.FirstOrDefaultAsync(c => c.Id_flashcard == flashcardId);

                if (result != null) {
                    _context.Flashcard.Remove(result);
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
