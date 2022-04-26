using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionUserController : ControllerBase {
        private readonly ICollectionUserRepository _collectionUserRepository;

        public CollectionUserController( ICollectionUserRepository collectionUserRepository ) {
            _collectionUserRepository = collectionUserRepository;
        }

        // --- Pobranie listy kolekcji dla danego użytkownika
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<List<Flashcard>>> GetAllCollectionsByUserId( int userId ) {
            try {
                return Ok(await _collectionUserRepository.GetAllCollectionsByUserId(userId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
