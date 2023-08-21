using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    public class Discount_CardController : ControllerBase
    {
        private readonly IDiscount_Card _discount;
        public Discount_CardController(IDiscount_Card Discount_Card)
        {
            _discount = Discount_Card;
        }


        [HttpGet("GetDiscount_Card")]
        public async Task<IActionResult> GetDiscount_CardAsync()
        {
            if (ModelState.IsValid)
            {
                var data = await _discount.GetDiscount_CardAsync();
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);

        }

        [HttpPost("CreateDiscount_Card")]
        public async Task<IActionResult> CreateDiscount_Card([FromQuery] Discount_CardPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _discount.CreateDiscount_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            return BadRequest(dto);
        }

        [HttpPut("PutDiscount_Card")]
        public async Task<IActionResult> PutDiscount_Card([FromQuery] Discount_CardPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _discount.PutDiscount_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteDiscount_Card")]
        public async Task<IActionResult> DeleteDiscount_Card([FromQuery] Discount_CardPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _discount.DeleteDiscount_CardAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }


    }
}
