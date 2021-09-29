namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.Core.DTOs.UserDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public UsersController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        /// <summary>
        /// Adds new user to the DB
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Token</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<RegisterDto>>> Register(string username, string password)
        {
            var response = await _authRepo.Register(username, password);
            if (response.Success == false) return BadRequest(response);
            return Ok(response);
        }

        /// <summary>
        /// Checks if the user exists, checks if password matches
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>Token</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<RegisterDto>>> Login(LogInDto loginDto)
        {
            var response = await _authRepo.Login(loginDto);
            if (response.Success == false) return BadRequest(response);
            return Ok(response);
        }
    }
}
