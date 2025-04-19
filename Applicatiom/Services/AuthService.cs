using Applicatiom.DTOs;
using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Domain.Permissions;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Applicatiom.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserDto> AuthenticateUser(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmail(loginDto.UserAPI);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                throw new UnauthorizedAccessException("Credenciais inválidas");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnviromentsVariables.Jwt_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permissions = PermissionsRole.GetPermissionsForRole(user.Role);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            claims.AddRange(permissions.Select(p => new Claim("permission", p)));

            var token = new JwtSecurityToken(
                issuer: EnviromentsVariables.Jwt_Issuer,
                audience: EnviromentsVariables.Jwt_Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserDto
            {
                User = user.Email,
                Token = tokenString
            };
        }

    }
}