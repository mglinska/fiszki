using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class FlashcardUserRepository : IFlashcardUserRepository {

        private readonly AppDbContext _context;

        public FlashcardUserRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Flashcard>> GetAllFlashcardsByUserId( int userId ) {
            var restult = await _context.Flashcard_user.Where(u => u.Id_user == userId).ToListAsync();

            if (restult != null) {
                List<Flashcard> flashcardsUser = new List<Flashcard>();

                foreach (var item in restult) {
                    var flashcard = await _context.Flashcard.FirstOrDefaultAsync(c => c.Id_flashcard == item.Id_flashcard);
                    if (flashcard != null) {
                        flashcardsUser.Add(flashcard);
                    }
                }

                return flashcardsUser;
            }

            return null;
        }
    }
}
