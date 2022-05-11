using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Pobranie użytkownika po id
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetUserById( int userId ) {
            try {
                return Ok(await _userRepository.GetUserById(userId));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Pobranie użytkownika po emailu
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail( string email ) {
            try {
                return Ok(await _userRepository.GetUserByLogin(email));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Aktualizacja danych użytkownika
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser( User user ) {
            try {
                return Ok(await _userRepository.UpdateUser(user));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // --- Rejestracja użytkownika
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser( User user ) {
            try {
                return Ok(await _userRepository.RegisterUser(user));
            } catch (Exception ex) {
                return BadRequest(ex.InnerException.Message);
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
                        HttpContext.Session.SetString("login", user.Email);
                        loginUser.Password = "";
                        return Ok(loginUser);
                    }
                }

                return null;
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Route("check-logged-user")]
        [HttpGet]
        public async Task<ActionResult<User>> CheckLoggedUser() {
            string login = HttpContext.Session.GetString("login");

            if (!string.IsNullOrEmpty(login)) {
                return await _userRepository.GetUserByLogin(login);
            }

            return null;
        }

        [Route("logout")]
        [HttpGet]
        public void LogoutUser() {
            HttpContext.Session.Remove("login");

            return;
        }

        // --- Usuwanie użytkownika
        [HttpDelete("{id:int}")]
        public async Task<string> DeleteUser( int id ) {
            return await _userRepository.DeleteUser(id);
        }
    }
}
