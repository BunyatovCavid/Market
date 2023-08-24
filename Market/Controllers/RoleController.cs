using Market.Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Developer")]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var data = await _role.GetRoleAsync();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet("GetRoleByFilter")]
        public async Task<IActionResult> GetRoleByFilter([FromQuery] RoleDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _role.GetRoleByIdAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);

        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromQuery] RolePostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _role.PostRoleAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            return BadRequest(dto);
        }

        [HttpPut("PutRole")]
        public async Task<IActionResult> PutRole([FromQuery]RoleDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _role.PutRoleAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromQuery]int id)
        {
            if (ModelState.IsValid)
            {
                var data = await _role.DeleteRoleAsync(id);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

    }
}
