using Microsoft.AspNetCore.Mvc;
using Market.Interfaces;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Market.Dtoes.PutDto;
using Microsoft.AspNetCore.Authorization;
using Market.Independents;
using Market.Domain.Entities;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Developer,Boss")]
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
            var response = await _response.GetResponse(data);
            return response;

        }

        [HttpPost("CreateCash")]
        public async Task<IActionResult> CreateCash([FromQuery] CashPostDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.CreateCashAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCash")]
        public async Task<IActionResult> PutCash([FromQuery] CashPutDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _cash.PutCashAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCash")]
        public async Task<IActionResult> DeleteCash([FromQuery] int Id)
        {
            var data = await _cash.DeleteCashAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }


        [HttpDelete("DeleteCashRealAsync")]
        public async Task<IActionResult> DeleteCashRealAsync([FromQuery] int Id)
        {
            var data = await _cash.DeleteCashRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCash")]
        public async Task<IActionResult> ReturnCash([FromQuery] int Id)
        {
            var data = await _cash.ReturnCashAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }
    }
}
