using Login.Context;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Dbcontexts _authContext;
        public LoginController(Dbcontexts dbcontexts)
        {
            _authContext = dbcontexts;
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials userCredentials)
        {
            if (userCredentials == null)
                return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(s => s.username == userCredentials.username && s.password == userCredentials.password);

            if (user == null)
                return NotFound(new { Message = "User Not Found" });

            // Login success
            return Ok(new { Message = "Login success" });
        }

        public class UserCredentials
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "register success"
            });
        }
    }
}
