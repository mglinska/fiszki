using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionController( ICollectionRepository collectionRepository ) {
            _collectionRepository = collectionRepository;
        }

        // --- Pobranie listy kolekcji
        [HttpGet]
        public async Task<ActionResult<List<Collection>>> GetAllCollections() {
            try {
                return Ok(await _collectionRepository.GetAllCollections());
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Pobranie kolekcji po id
        [HttpGet("{collectionId:int}")]
        public async Task<ActionResult<Collection>> GetCollectionById( int collectionId ) {
            try {
                return Ok(await _collectionRepository.GetCollectionById(collectionId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Pobranie kolekcji po nazwie
        [HttpGet("{collectionName}")]
        public async Task<ActionResult<Collection>> GetCollectionByName( string collectionName ) {
            try {
                return Ok(await _collectionRepository.GetCollectionByName(collectionName));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Utworzenie nowej kolekcji
        [HttpPost]
        public async Task<ActionResult<Collection>> CreateCollection( Collection collection, int userId ) {
            try {
                return Ok(await _collectionRepository.CreateCollection(collection, userId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Aktualizacja danych kolekcji
        [HttpPut]
        public async Task<ActionResult<Collection>> UpdateCollection( Collection collection ) {
            try {
                return Ok(await _collectionRepository.UpdateCollection(collection));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Usuwanie kolekcji
        [HttpDelete("{collectionId:int}")]
        public async Task<string> DeleteCollection( int collectionId ) {
            return await _collectionRepository.DeleteCollection(collectionId);
        }
    }
}
