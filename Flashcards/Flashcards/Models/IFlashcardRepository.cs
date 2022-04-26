namespace Flashcards.Models {
    public interface IFlashcardRepository {
        Task<List<Flashcard>> GetAllFlashcards();
        Task<Flashcard> GetFlashcardById( int flashcardId );
        Task<Flashcard> GetFlashcardByCollectionId( int collectionId );
        Task<Flashcard> CreateFlashcard( Flashcard flashcard, int userId );
        Task<Flashcard> UpdateFlashcard( Flashcard flashcard );
        Task<string> DeleteFlashcard( int flashcardId );
    }
}
