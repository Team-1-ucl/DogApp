using DogApp.Shared.EntityModelsAuth;
using DogApp.User.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }


       [HttpGet]
        public async Task<bool>RegisterUser(LoginUser user)
        {
            return await _userService.RegisterUser(user);
        }
        [HttpPost]
        public async Task Login(LoginUser user)
        {
            await _userService.Login(user);
        }
    }
}
