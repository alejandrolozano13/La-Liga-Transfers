using Applicatiom.DTOs;
using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using BCrypt.Net;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Applicatiom.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly string _jwtSecret;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtSecret = GenerateJwtKey();
        }

        public async Task<UserDto> AuthenticateUser(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmail(loginDto.UserAPI);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                throw new UnauthorizedAccessException("Credenciais inválidas");

            var token = GenerateToken(user);

            return new UserDto
            {
                User = user.Email,
                Token = token
            };
        }

        private string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateJwtKey()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32]; // 256 bits
                randomNumberGenerator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}