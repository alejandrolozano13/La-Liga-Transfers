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

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
                ?? throw new InvalidOperationException("Chave JWT não configurada");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
                ?? throw new InvalidOperationException("Issuer JWT não configurado");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_ISSUER")
                ?? throw new InvalidOperationException("Audience JWT não configurado");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
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