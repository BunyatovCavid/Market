using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Bonus_CardController : ControllerBase
    {
        private readonly IBonus_Card _bonus;
        public Bonus_CardController(IBonus_Card Bonus_Card)
        {
            _bonus = Bonus_Card;
        }


        [HttpGet("GetBonus_Card")]
        public async Task<IActionResult> GetBonus_CardAsync()
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.GetBonus_CardAsync();
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);

        }

        [HttpPost("CreateBonus_Card")]
        public async Task<IActionResult> CreateBonus_Card([FromQuery] Bonus_CardPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.CreateBonus_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            return BadRequest(dto);
        }

        [HttpPut("PutBonus_Card")]
        public async Task<IActionResult> PutBonus_Card([FromQuery] Bonus_cardPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.PutBonus_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteBonus_Card")]
        public async Task<IActionResult> DeleteBonus_Card([FromQuery] Bonus_cardPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.DeleteBonus_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPost("CreateBonus_Card_Report")]
        public async Task<IActionResult> CreateBonus_Card_Report([FromQuery] Bonus_Card_ReportPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.CreateBonus_CardReportAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteBonus_CardAsync")]
        public async Task<IActionResult> DeleteBonus_CardAsync([FromQuery]int Barkod, [FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var data = await _bonus.DeleteBonus_Card_ReportAsync(Barkod,id);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }




    }
}
