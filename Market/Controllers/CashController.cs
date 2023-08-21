using Microsoft.AspNetCore.Mvc;
using Market.Interfaces;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Market.Dtoes.PutDto;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashController : ControllerBase
    {
        private readonly ICash _cash;
        public CashController(ICash cash)
        {
            _cash = cash;
        }


        [HttpGet("GetCash")]
        public async Task<IActionResult> GetCashAsync()
        {
            if (ModelState.IsValid)
            {
                var data = await _cash.GetCashAsync();
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);

        }

        [HttpPost("CreateCash")]
        public async Task<IActionResult> CreateCash([FromQuery] CashPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _cash.CreateCashAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            return BadRequest(dto);
        }

        [HttpPut("PutCash")]
        public async Task<IActionResult> PutCash([FromQuery] CashPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _cash.PutCashAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteCash")]
        public async Task<IActionResult> DeleteCash([FromQuery] CashPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _cash.DeleteCashAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }





    }
}
