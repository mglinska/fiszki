namespace Flashcards.Models {
    public interface ILinkRepository {
        Task<List<Link>> GetAllLinks();
        Task<Link> GetLinkByUrl(string url);
        Task<Link> CreateLink( Link link );
        Task<string> DeleteLink(string url);
        Task<string> RemoveExpiredLink();
    }
}
