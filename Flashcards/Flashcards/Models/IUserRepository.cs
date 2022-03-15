namespace Flashcards.Models {
    public interface IUserRepository {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> RegisterUser(User user);
        Task<User> GetUserByLogin(string email);
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(int userId);
    }
}
