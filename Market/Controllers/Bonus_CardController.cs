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
    [Authorize("Developer,Boss,Admin")]
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
        [Authorize("Developer,Boss,Admin,Kassir")]
        public async Task<IActionResult> GetBonus_CardAsync()
        {
            var data = await _bonus.GetBonus_CardAsync();
            var response = await _response.GetResponse(data);
            return response;

        }

        [HttpPost("CreateBonus_Card")]
        public async Task<IActionResult> CreateBonus_Card([FromQuery] Bonus_CardPostDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.CreateBonus_CardAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutBonus_Card")]
        public async Task<IActionResult> PutBonus_Card([FromQuery] Bonus_cardPutDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.PutBonus_CardAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_Card")]
        public async Task<IActionResult> DeleteBonus_Card([FromQuery]int Barkod)
        {           
            var data = await _bonus.DeleteBonus_CardAsync(Barkod);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateBonus_Card_Report")]
        public async Task<IActionResult> CreateBonus_Card_Report([FromQuery] Bonus_Card_ReportPostDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.CreateBonus_CardReportAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteBonus_CardAsync")]
        public async Task<IActionResult> DeleteBonus_Card_ReportAsync([FromQuery] Bonus_Card_ReportDeleteDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _bonus.DeleteBonus_Card_ReportAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }




    }
}
