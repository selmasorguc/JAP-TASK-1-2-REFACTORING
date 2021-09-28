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

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<RegisterDto>>> Register(string username, string password)
        {
            var response = await _authRepo.Register(username, password);
            if (response.Success == false) return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<RegisterDto>>> Login(LogInDto loginDto)
        {
            var response = await _authRepo.Login(loginDto);
            if (response.Success == false) return BadRequest(response);
            return Ok(response);
        }
    }
}
