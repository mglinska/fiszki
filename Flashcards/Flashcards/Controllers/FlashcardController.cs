using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardContorller : ControllerBase {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardContorller( IFlashcardRepository flashcardRepository ) {
            _flashcardRepository = flashcardRepository;
        }

        // --- Pobranie listy fiszek
        [HttpGet]
        public async Task<ActionResult<List<Flashcard>>> GetAllFlashcards() {
            try {
                return Ok(await _flashcardRepository.GetAllFlashcards());
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Pobranie fiszki po id
        [HttpGet("{flashcardId:int}")]
        public async Task<ActionResult<Flashcard>> GetFlashcardById( int flashcardId ) {
            try {
                return Ok(await _flashcardRepository.GetFlashcardById(flashcardId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Utworzenie nowej fiszki
        [HttpPost]
        public async Task<ActionResult<Flashcard>> CreateFlashcard( Flashcard flashcard, int userId ) {
            try {
                return Ok(await _flashcardRepository.CreateFlashcard(flashcard, userId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Aktualizacja danych fiszki
        [HttpPut]
        public async Task<ActionResult<Flashcard>> UpdateFlashcard( Flashcard flashcard ) {
            try {
                return Ok(await _flashcardRepository.UpdateFlashcard(flashcard));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Usuwanie fiszki
        [HttpDelete("{flashcardId:int}")]
        public async Task<string> DeleteFlashcard( int flashcardId ) {
            return await _flashcardRepository.DeleteFlashcard(flashcardId);
        }
    }
}
