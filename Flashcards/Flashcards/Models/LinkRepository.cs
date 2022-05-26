using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Flashcards.Models {
    public class LinkRepository : ILinkRepository {

        private readonly AppDbContext _context;

        public LinkRepository( AppDbContext context ) {
            _context = context;
        }

        public async Task<List<Link>> GetAllLinks() {
            List<Link> links = await _context.Link.ToListAsync();

            return links;
        }

        public async Task<Link> GetLinkByUrl( string url ) {
            var result = await _context.Link.FirstOrDefaultAsync(l => l.Url == url);

            return result;
        }

        public async Task<Link> CreateLink( Link link ) {
            var result = await _context.Link.AddAsync(link);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<string> DeleteLink( string url ) {
            try {
                var result = await _context.Link.FirstOrDefaultAsync(l => l.Url == url);

                if (result != null) {
                    _context.Link.Remove(result);
                    await _context.SaveChangesAsync();

                    return "Operation successful!";
                }

                return "Operation failed!";
            } catch (Exception ex) {
                return ex.Message;
            }
        }

        public async Task<bool> CheckLink( string url ) {
            var result = await _context.Link.FirstOrDefaultAsync(l => l.Url == url);

            if (result != null) {
                return true;
            }

            return false;
        }


        public async Task<string> RemoveExpiredLink() {
            try {
                List<Link> result = await _context.Link.Where(l => l.Expiration_time <= DateTime.Now).ToListAsync();

                if (result != null) {
                    foreach (var record in result) {
                        _context.Link.Remove(record);
                        await _context.SaveChangesAsync();
                    }

                    return "Operation successful!";
                }

                return "Operation failed!";
            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
