using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję Collection
    public class Flashcard {
        [Key]
        public int Id_flashcard { get; set; }
        public int Id_collection { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
