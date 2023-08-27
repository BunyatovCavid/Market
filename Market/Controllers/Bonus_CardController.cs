using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
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
    public class Bonus_CardController : ControllerBase
    {
        private readonly IBonus_Card _bonus;
        private readonly Response _response;
        public Bonus_CardController(IBonus_Card Bonus_Card, Response response)
        {
            _bonus = Bonus_Card;
            _response = response;
        }


        [HttpGet("GetBonus_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> GetBonus_CardAsync()
        {
            var data = await _bonus.GetBonus_CardAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllBonus_CardAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> GetAllBonus_CardAsync()
        {
            var data = await _bonus.GetAllBonus_CardAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllBonus_CardReportAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> GetAllBonus_CardReportAsync()
        {
            var data = await _bonus.GetAllBonus_CardReportAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateBonus_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> CreateBonus_Card([FromQuery] Bonus_CardPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.CreateBonus_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutBonus_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> PutBonus_Card([FromQuery] Bonus_cardPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.PutBonus_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> DeleteBonus_Card([FromQuery]AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.DeleteBonus_CardAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateBonus_Card_Report")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> CreateBonus_Card_Report([FromQuery] Bonus_Card_ReportPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.CreateBonus_CardReportAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_CardAsync")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> DeleteBonus_Card_ReportAsync([FromQuery] Bonus_Card_ReportDeleteDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.DeleteBonus_Card_ReportAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_CardRealAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> DeleteBonus_CardRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.DeleteBonus_CardRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_Card_ReportRealAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> DeleteBonus_Card_ReportRealAsync([FromQuery] AllTwoNumberPostDto dto )
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.DeleteBonus_Card_ReportRealAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

    }
}
