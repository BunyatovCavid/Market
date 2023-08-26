using Market.Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Independents;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Developer")]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        private readonly Response _response;
        public RoleController(IRole role, Response response)
        {
            _response = response;
            _role = role;
        }

        [HttpGet("GetRolesAsync")]
        public async Task<IActionResult> GetRolesAsync()
        {

            var data = await _role.GetRoleAsync();
            var response =  _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetRoleByIdAsync")]
        public async Task<IActionResult> GetRoleByIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _role.GetRoleByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateRoleAsync")]
        public async Task<IActionResult> CreateRoleAsync([FromQuery] RolePostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _role.PostRoleAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutRoleAsync")]
        public async Task<IActionResult> PutRoleASync([FromQuery] RoleDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _role.PutRoleAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteRoleAsync")]
        public async Task<IActionResult> DeleteRoleAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _role.DeleteRoleAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

    }
}
