using Market.Domain.Entities;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
        public async Task<IActionResult> Login([FromQuery] LoginDto dto)
        {
            var data = await _token.LogIn(dto);
            var response = JsonSerializer.Serialize(data);
            return Ok(response);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromQuery] LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _account.CreateAccountAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpGet("GetAccountByName")]
        public async Task<IActionResult> GetAccountByName([FromQuery] string Name)
        {
            if (ModelState.IsValid)
            {
                var data = await _account.GetAccountByNameAsync(Name);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }
        [HttpGet("GetAccount")]
        public async Task<IActionResult> GetAccount()
        {
            if (ModelState.IsValid)
            {
                 var data = await _account.GetAccountAsync();
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }
        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            if (ModelState.IsValid)
            {
                var data = await _account.GetAllAccountAsync();
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutAccount")]
        public async Task<IActionResult> PutAccount([FromQuery] AccountPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _account.PutAccountAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount([FromQuery] string Name)
        {
            if (ModelState.IsValid)
            {
                var data = await _account.DeleteAccountAsync(Name);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }






        [HttpGet("GetAccountByRole")]
        public async Task<IActionResult> GetAccountByRole()
        {
            
            if (ModelState.IsValid)
            {
                var data = await _cross.GetAccountsAsync();
                var _response = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                if (data != null)
                    return Ok(_response);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpGet("GetAccountRoleById")]
        public async Task<IActionResult> GetAccountRoleById(int id)
        {
            if (ModelState.IsValid)
            {
                var data = await _cross.GetAccountByIdAsync(id);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPost("CreateAccountRole")]
        public async Task<IActionResult> CreateAccountRole([FromQuery] Cross_Account_RoleDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _cross.PostAccountRoleAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }
        [HttpDelete("DeleteAccountRole")]
        public async Task<IActionResult> DeleteAccountRole([FromQuery] Cross_Account_RoleDto dto)
        {

            if (ModelState.IsValid)
            {
                var data = await _cross.DeleteAccountRoleAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }






    }
}