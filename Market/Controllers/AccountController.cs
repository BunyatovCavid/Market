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
using Market_Sistemi_BLL_.Dtoes;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult Login([FromQuery] LoginDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = _token.LogIn(dto);
            var request = JsonSerializer.Serialize(data);

            var response = _response.GetResponse(request);
            return response;
        }


        [HttpPost("Register")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> Register([FromQuery] LoginDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _account.CreateAccountAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAccountByName")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> GetAccountByName([FromQuery] AllOneNamePostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _account.GetAccountByNameAsync(dto.Name);
            var response = _response.GetResponse(data);
            return response;
        }
        [HttpGet("GetAccount")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> GetAccount()
        {

            var data = await _account.GetAccountAsync();
            var response = _response.GetResponse(data);
            return response;
        }
        [HttpGet("GetAllAccount")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> GetAllAccount()
        {
            var data = await _account.GetAllAccountAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutAccount")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> PutAccount([FromQuery] AccountPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _account.PutAccountAsync(dto);

            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteAccount")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> DeleteAccount([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _account.DeleteAccountAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteAccountReal")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> DeleteAccountReal([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _account.DeleteAccountRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnAccount")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> ReturnAccount([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _account.ReturnAccountAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;

        }



        // Cross


        [HttpGet("GetCross")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> GetCross()
        {
            var data = await _cross.GetCrossAsync();
            var request = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var response = _response.GetResponse(request);
            return response;
        }

        [HttpGet("GetCrossBydto")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> GetCrossById([FromQuery]AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cross.GetCrossByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCross")]
        [Authorize(Roles =("Developer"))]
        public async Task<IActionResult> CreateCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.PostCrossAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }
        [HttpDelete("DeleteCross")]
        [Authorize(Roles =("Boss,Developer"))]
        public async Task<IActionResult> DeleteCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.DeleteCrossAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }




        //Owner

        [HttpGet("GetOwnerCrossById")]
        [Authorize(Roles =("Developer"))]
        public async Task<IActionResult> GetOwnerByIddCross([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cross.GetOwnerCrossByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateOwnerCross")]
        [Authorize(Roles =("Developer"))]
        public async Task<IActionResult> CreateOwnerCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.PostOwnerCrossAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }
        [HttpDelete("DeleteOwnerCross")]
        [Authorize(Roles =("Developer"))]
        public async Task<IActionResult> DeleteOwnerCross([FromQuery] Cross_Account_RoleDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;

            var data = await _cross.DeleteOwnerCrossAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }




    }
}