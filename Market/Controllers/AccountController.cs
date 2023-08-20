using Market.Domain.Entities;
using Market.Dtoes;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        private readonly JWTTokenService _token;
        private readonly ICrossAccountRole _cross;
        public AccountController(IAccount account, JWTTokenService token, ICrossAccountRole cross)
        {
            _token = token;
            _account = account;
            _cross = cross;

        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery]LoginDto dto)
        {
            var data = await _token.LogIn(dto);
            var response = JsonSerializer.Serialize(data);
            return Ok(response);
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






        [HttpGet("GetAccountByRole")]
        public async Task<IActionResult> GetAccountByRole()
        {
            var data = await _cross.GetAccountsAsync();
            return Ok(data);
        }

        [HttpGet("GetAccountRoleById")]
        public async Task<IActionResult> GetAccountRoleById(int id)
        {
            var data = await _cross.GetAccountByIdAsync(id);
            return Ok(data);
        }

        [HttpPost("CreateAccountRole")]
        public async Task<IActionResult> CreateAccountRole([FromQuery] Cross_Account_RoleDto dto)
        {
            var data = await _cross.PostAccountRoleAsync(dto);
            return Ok(data);
        }
        [HttpDelete("DeleteAccountRole")]
        public async Task<IActionResult> DeleteAccountRole([FromQuery] Cross_Account_RoleDto dto)
        {
            var data = await _cross.DeleteAccountRoleAsync(dto);
            return Ok(data);
        }






    }
}