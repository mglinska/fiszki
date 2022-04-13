namespace Flashcards.Models {
    public interface ICollectionRepository {
        Task<List<Collection>> GetAllCollections();
        Task<Collection> GetCollectionById( int collectionId );
        Task<Collection> CreateCollection( Collection collection, int userId );
        Task<Collection> GetCollectionByName( string name );
        Task<Collection> UpdateCollection( Collection collection );
        Task<string> DeleteCollection( int collectionId );
    }
}
