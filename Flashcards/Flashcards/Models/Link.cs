using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję Link
    public class Link {
        [Key]
        public int Id_link { get; set; }
        public string Url { get; set; }
        public DateTime Expiration_time { get; set; }
    }
}
