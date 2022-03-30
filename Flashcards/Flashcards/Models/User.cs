using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję User
    public class User {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Is_admin { get; set; }
        public byte Is_blocked { get; set; }
    }
}
