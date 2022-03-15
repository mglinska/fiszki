using Flashcards.Models;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Models {
    public class AppDbContext : DbContext {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options) {
        }

        // --- Dodawanie encji do kontekstu bazy danych
        public DbSet<User> Users { get; set; }
    }
}
