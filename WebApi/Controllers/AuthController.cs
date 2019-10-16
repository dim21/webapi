using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.User;
using WebApi.Repos.User;

namespace WebApi.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST /auth/auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            var result = await _userRepository.CheckAuth(user);
            if (!string.IsNullOrEmpty(result.Error))
            {
                return BadRequest(new { Error = result.Error });
            }
            return Ok(new { authToken = result.Id });
        }
    }
}