using Flashcards.Models;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Models {
    public class AppDbContext : DbContext {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options) {
        }

        // --- Dodawanie encji do kontekstu bazy danych
        public DbSet<User> User { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Flashcard> Flashcard { get; set; }
        public DbSet<FlashcardUser> Flashcard_user { get; set; }
        public DbSet<CollectionUser> Collection_user { get; set; }
    }
}
