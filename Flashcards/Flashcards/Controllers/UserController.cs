using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
                string password = user.Password;
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider()) {
                    rngCsp.GetNonZeroBytes(salt);
                }

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                user.Password = Convert.ToBase64String(salt) + "$" + hashed;

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

                    string password = user.Password;

                    string saltString = loginUser.Password.Split("$")[0];
                    byte[] salt = Convert.FromBase64String(saltString);

                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));

                    user.Password = Convert.ToBase64String(salt) + "$" + hashed;

                    if (user.Password.Equals(loginUser.Password)) {
                        HttpContext.Session.SetString("login", user.Email);
                        loginUser.Password = "";
                        return Ok(loginUser);
                    }
                }

                throw new Exception();
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
