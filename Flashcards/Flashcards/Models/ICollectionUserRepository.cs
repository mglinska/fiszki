namespace Flashcards.Models {
    public interface ICollectionUserRepository {
        Task<List<Collection>> GetAllCollectionsByUserId( int userId );
    }
}
