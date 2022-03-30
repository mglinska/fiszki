using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję Collection
    public class Collection {
        [Key]
        public int Id_collection { get; set; }
        public string Name { get; set; }
        public DateTime Created_on { get; set; }
        public string Description { get; set; }
    }
}
