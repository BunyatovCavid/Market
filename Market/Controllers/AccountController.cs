using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Boss")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        private readonly JWTTokenService _token;
        public AccountController(IAccount account, JWTTokenService token)
        {
            _token = token;
            _account = account;
        }

        [HttpGet("{Login}")]
        [AllowAnonymous]
        public async Task<string> Login([FromQuery]LoginDto dto)
        {
            var data = await _token.LogIn(dto);
            var response = JsonSerializer.Serialize(data);
            return response;
        }


        [HttpPost("Register")]
        public async Task<RegisterDto> Register([FromQuery] LoginDto dto)
        {
            var data = await _account.CreateAccountAsync(dto);
            return data;
        }

        [HttpGet("GetAccountById")]
        public async Task<Account> GetAccountById([FromQuery]int id)
        {
            var data = await _account.GetAccountAsync(id);
            return data;
        }
        [HttpGet("GetAccount")]
        public async Task<ICollection<Account>> GetAccount()
        {   var data = await _account.GetAccountAsync();
            return data;
        }

        [HttpPut("PutAccount")]
        public async Task<ICollection<Account>> PutAccount([FromQuery]AccountPutDto dto)
        {
            var data = await _account.PutAccountAsync(dto);
            return data;
        }

        [HttpDelete("DeleteAccount")]
        public async Task<ICollection<Account>> DeleteAccount([FromQuery] int id)
        {
            var data = await _account.DeleteAccountAsync(id);
            return data;
        }


        




    }
}