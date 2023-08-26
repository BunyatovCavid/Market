using Microsoft.AspNetCore.Mvc;
using Market.Interfaces;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Market.Dtoes.PutDto;
using Microsoft.AspNetCore.Authorization;
using Market.Independents;
using Market.Domain.Entities;
using Market_Sistemi_BLL_.Dtoes;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Developer,Boss")]
    public class CashController : ControllerBase
    {
        private readonly ICash _cash;
        private readonly Response _response;
        public CashController(ICash cash, Response response)
        {
            _cash = cash;
            _response = response;
        }


        [HttpGet("GetCash")]
        public async Task<IActionResult> GetCashAsync()
        {
            var data = await _cash.GetCashAsync();
            var response = _response.GetResponse(data);
            return response;

        }

        [HttpPost("CreateCash")]
        public async Task<IActionResult> CreateCash([FromQuery] CashPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.CreateCashAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCash")]
        public async Task<IActionResult> PutCash([FromQuery] CashPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.PutCashAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCash")]
        public async Task<IActionResult> DeleteCash([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.DeleteCashAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpDelete("DeleteCashRealAsync")]
        public async Task<IActionResult> DeleteCashRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.DeleteCashRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCash")]
        public async Task<IActionResult> ReturnCash([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.ReturnCashAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }
    }
}
