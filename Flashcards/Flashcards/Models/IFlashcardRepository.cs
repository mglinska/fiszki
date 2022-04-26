namespace Flashcards.Models {
    public interface IFlashcardRepository {
        Task<List<Flashcard>> GetAllFlashcards();
        Task<Flashcard> GetFlashcardById( int flashcardId );
        Task<List<Flashcard>> GetFlashcardsByCollectionId( int collectionId );
        Task<Flashcard> CreateFlashcard( Flashcard flashcard, int userId );
        Task<Flashcard> UpdateFlashcard( Flashcard flashcard );
        Task<string> DeleteFlashcard( int flashcardId );
    }
}
