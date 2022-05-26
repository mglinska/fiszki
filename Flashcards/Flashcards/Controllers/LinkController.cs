using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase {
        private readonly ILinkRepository _linkRepository;

        public LinkController( ILinkRepository linkRepository ) {
            _linkRepository = linkRepository;
        }

        // --- Pobranie listy linków
        [HttpGet]
        public async Task<ActionResult<List<Link>>> GetAllLinks() {
            try {
                return Ok(await _linkRepository.GetAllLinks());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Pobranie linku po url
        [HttpGet("{url}")]
        public async Task<ActionResult<Collection>> GetLinkByUrl( string url ) {
            try {
                url = url.Replace("%2F", "/");

                return Ok(await _linkRepository.GetLinkByUrl(url));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Utworzenie nowej kolekcji
        [HttpPost]
        public async Task<ActionResult<Collection>> CreateLink( Link link ) {
            try {
                link.Url = link.Url.Replace("%2F", "/");

                return Ok(await _linkRepository.CreateLink(link));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Usuwanie linku
        [HttpDelete("{url}")]
        public async Task<string> DeleteLink( string url ) {
            url = url.Replace("%2F", "/");

            return await _linkRepository.DeleteLink(url);
        }

        // --- Usuwanie linków, które wygasły
        [HttpDelete]
        public async Task<string> RemoveExpiredLink() {
            return await _linkRepository.RemoveExpiredLink();
        }
    }
}
