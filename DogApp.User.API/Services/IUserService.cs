using DogApp.Shared.EntityModelsAuth;

namespace DogApp.User.API.Services
{
    public interface IUserService
    {
        
        string GenerateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }

}
