namespace Flashcards.Models {
    public interface ILinkRepository {
        Task<List<Link>> GetAllLinks();
        Task<Link> GetLinkByUrl( string url );
        Task<Link> CreateLink( Link link );
        Task<bool> CheckLink( string url );
        Task<string> DeleteLink( string url );
        Task<string> RemoveExpiredLink();
    }
}
