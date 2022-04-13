using System.ComponentModel.DataAnnotations;

namespace Flashcards.Models {
    // --- Klasa opisująca encję Collection
    public class CollectionUser {
        [Key]
        public int Id_collection { get; set; }
        public int Id_user { get; set; }
        public string Rights { get; set; }
        public long Study_time { get; set; }
    }
}
