using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję Collection
    public class FlashcardUser {
        [Key]
        public int Id_flashcard { get; set; }
        public int Id_user { get; set; }
        public byte Memorized { get; set; }
    }
}
