using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardUserContorller : ControllerBase {
        private readonly IFlashcardUserRepository _flashcardUserRepository;

        public FlashcardUserContorller( IFlashcardUserRepository flashcardUserRepository ) {
            _flashcardUserRepository = flashcardUserRepository;
        }

        // --- Pobranie listy fiszek dla danego użytkownika
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<List<Flashcard>>> GetAllFlashcardsByUserId(int userId) {
            try {
                return Ok(await _flashcardUserRepository.GetAllFlashcardsByUserId( userId ));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
