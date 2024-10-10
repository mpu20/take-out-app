using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TakeOutApp.API.Common;
using TakeOutApp.API.Models;
using TakeOutApp.API.Repositories;

namespace TakeOutApp.API.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly UserRepository _userRepository;

        public AuthService(IConfiguration config, UserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        private string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("Jwt:Key"));
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private string GetHashedPassword(string password)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), HashPasswordConfig.salt, HashPasswordConfig.iterations, HashAlgorithmName.SHA512, HashPasswordConfig.keySize);

            return Convert.ToHexString(hash);
        }

        public async Task<string?> LoginAsync(User user)
        {
            var hashedPassword = GetHashedPassword(user.Password);
            var userInfo = await _userRepository.GetUserByPhoneNumberAndPassword(user.PhoneNumber, user.Password);

            if (userInfo == null) return null;

            return GenerateToken(userInfo);
        }

        public async Task<bool> IsUserExist(string phoneNumber)
        {
            return await _userRepository.IsUserExist(phoneNumber);
        }

        public async Task RegisterAsync(User user)
        {
            await _userRepository.Create(user);
        }
    }
}
