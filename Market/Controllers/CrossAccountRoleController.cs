using Market.Domain.Entities;
using Market.Dtoes;
using Market.Interfaces;
using Market.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrossAccountRoleController : ControllerBase
    {

        private readonly ICrossAccountRole _cross;
        public CrossAccountRoleController(ICrossAccountRole cross)
        {
            _cross = cross;
        }

        [HttpGet("GetAccountByRole")]
        public async Task<ICollection<Account>> GetAccountByRole()
        {
            var data = await _cross.GetAccountsAsync();
            return data;
        }

        [HttpGet("GetAccountRoleById")]
        public async Task<Account> GetAccountRoleById(int id)
        {
            var data = await _cross.GetAccountByIdAsync(id);
            return data;
        }

        [HttpPost("{CreateAccountRole}")]
        public async Task<ICollection<Account>> CreateAccountRole([FromQuery]Cross_Account_RoleDto dto)
        {
            var data = await _cross.PostAccountRoleAsync(dto);
            return data;
        }
        [HttpDelete("DeleteAccountRole")]
        public async Task<Account> DeleteAccountRole([FromQuery] Cross_Account_RoleDto dto)
        {
            var data = await _cross.DeleteAccountRoleAsync(dto);
            return data;
        }



    }
}
