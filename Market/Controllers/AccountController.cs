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
using Market.Independents;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Developer")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        private readonly JWTTokenService _token;
        private readonly ICrossAccountRole _cross;
        private readonly Response _response;
        public AccountController(IAccount account, JWTTokenService token, ICrossAccountRole cross, Response response)
        {
            _token = token;
            _account = account;
            _cross = cross;
            _response = response;
        }


        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _token.LogIn(dto);
            var request = JsonSerializer.Serialize(data);

            var response = await _response.GetResponse(request);
            return response;
        }


        [HttpPost("Register")]
        [Authorize("Boss")]
        public async Task<IActionResult> Register([FromQuery] LoginDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _account.CreateAccountAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAccountByName")]
        [Authorize("Boss")]
        public async Task<IActionResult> GetAccountByName([FromQuery] string Name)
        {
            var data = await _account.GetAccountByNameAsync(Name);
            var response = await _response.GetResponse(data);
            return response;
        }
        [HttpGet("GetAccount")]
        [Authorize("Boss")]
        public async Task<IActionResult> GetAccount()
        {
            var data = await _account.GetAccountAsync();
            var response = await _response.GetResponse(data);
            return response;
        }
        [HttpGet("GetAllAccount")]
        [Authorize("Boss")]
        public async Task<IActionResult> GetAllAccount()
        {
            var data = await _account.GetAllAccountAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutAccount")]
        [Authorize("Boss")]
        public async Task<IActionResult> PutAccount([FromQuery] AccountPutDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return null;

            var data = await _account.PutAccountAsync(dto);

            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteAccount")]
        [Authorize("Boss")]
        public async Task<IActionResult> DeleteAccount([FromQuery] int Id)
        {
            var data = await _account.DeleteAccountAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteAccountReal")]
        [Authorize("Boss")]
        public async Task<IActionResult> DeleteAccountReal([FromQuery] int Id)
        {
            var data = await _account.DeleteAccountRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnAccount")]
        [Authorize("Boss")]
        public async Task<IActionResult> ReturnAccount([FromQuery] int Id)
        {
            var data = await _account.ReturnAccountAsync(Id);
            var response = await _response.GetResponse(data);
            return response;

        }



        // Cross


        [HttpGet("GetCross")]
        [Authorize("Boss")]
        public async Task<IActionResult> GetCross()
        {
            var data = await _cross.GetCrossAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCrossById")]
        [Authorize("Boss")]
        public async Task<IActionResult> GetCrossById(int id)
        {
            var data = await _cross.GetCrossByIdAsync(id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCross")]
        [Authorize("Boss")]
        public async Task<IActionResult> CreateCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.PostCrossAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }
        [HttpDelete("DeleteCross")]
        [Authorize("Boss")]
        public async Task<IActionResult> DeleteCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.DeleteCrossAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetOwnerCrossById")]
        public async Task<IActionResult> GetOwnerByIddCross(int Id)
        {
            var data = await _cross.GetOwnerCrossByIdAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateOwnerCross")]
        public async Task<IActionResult> CreateOwnerCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.PostOwnerCrossAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }
        [HttpDelete("DeleteOwnerCross")]
        public async Task<IActionResult> DeleteOwnerCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.DeleteOwnerCrossAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }




    }
}