using Flashcards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace Flashcards.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserRepository _userRepository;

        public UserController( IUserRepository userRepository ) {
            _userRepository = userRepository;
        }

        // --- Pobranie listy użytkowników
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            try {
                return Ok(await _userRepository.GetAllUsers());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Pobranie użytkownika po id
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser( int userId ) {
            try {
                return Ok(await _userRepository.GetUserById(userId));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Logowanie użytkownika
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> LoginUser( User user ) {
            try {
                User loginUser = await _userRepository.GetUserByLogin(user.Email);

                if (loginUser != null) {
                    if (user.Password.Equals(loginUser.Password)) {
                        return Ok(loginUser);
                    }
                }

                throw new Exception();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Rejestracja użytkownika
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser( User user ) {
            try {
                return Ok(await _userRepository.RegisterUser(user));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Aktualizacja danych użytkownika
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser( User user ) {
            try {
                return Ok(await _userRepository.UpdateUser(user));
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // --- Usuwanie użytkownika
        [HttpDelete("{id}")]
        public async Task<string> DeleteUser( int id ) {
            return await _userRepository.DeleteUser(id);
        }
    }
}
