using AutoMapper;
using Market.Domain.Entities;
using Market.Domain;
using Market.Dtoes.Get_Dtoes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Market.Services
{
    public class JWTTokenService
    {
        private readonly IMapper _mapper;
        private readonly MarketDbContext _db;
        private readonly IConfiguration _iconfiguration;
        public JWTTokenService(IMapper mapper, MarketDbContext db, IConfiguration iconfiguration)
        {
            _mapper = mapper;
            _db = db;
            _iconfiguration = iconfiguration;
        }

        private async Task<Account> GetUserAsync(LoginDto dto)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(b => b.Name == dto.Name && b.Password == dto.Password);
            return data;
        }
        public async Task<string> LogIn(LoginDto dto)
        {
            var user = GetUserAsync(dto);
            if (user != null)
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);


                var tokenDecriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim (ClaimTypes.Name,dto.Name)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenhandler.CreateToken(tokenDecriptor);
                return tokenhandler.WriteToken(token);
            }
            else return "User not registered.";
        }
    }
}
