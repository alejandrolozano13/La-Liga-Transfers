using Applicatiom.DTOs;

namespace Applicatiom.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<UserDto> AuthenticateUser(LoginDto loginDto);
    }
}
