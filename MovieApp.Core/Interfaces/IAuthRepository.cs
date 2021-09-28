namespace MovieApp.Core.Interfaces
{
    using MovieApp.Core.DTOs.UserDtos;
    using MovieApp.Core.Entities;
    using System.Threading.Tasks;

    public interface IAuthRepository
    {
        Task<ServiceResponse<RegisterDto>> Login(LogInDto loginDto);

        Task<ServiceResponse<RegisterDto>> Register(string username, string password);

        Task<bool> UserExists(string username, string password);

        Task<User> GetUserByUsernameAsync(string username);
    }
}
