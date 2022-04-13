namespace Flashcards.Models {
    public interface IFlashcardUserRepository {
        Task<List<Flashcard>> GetAllFlashcardsByUserId( int userId );
    }
}
