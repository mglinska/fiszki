using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję User
    public class User {
        [Key]
        public int Id_user { get; set; }
        public string First_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Is_admin { get; set; }
    }
}
