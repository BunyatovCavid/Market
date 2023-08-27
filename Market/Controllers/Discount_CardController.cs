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
    public class Discount_CardController : ControllerBase
    {
        private readonly IDiscount_Card _discount;
        private readonly Response _response;
        public Discount_CardController(IDiscount_Card discount_Card,Response response)
        {
            _discount = discount_Card;
            _response = response;
        }


        [HttpGet("GetDiscount_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> GetDiscount_CardAsync()
        {
            var data = await _discount.GetDiscount_CardAsync();
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpGet("GetAllDiscount_Card")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> GetAllDiscount_CardAsync()
        {
            var data = await _discount.GetAllDiscount_CardAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateDiscount_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> CreateDiscount_Card([FromQuery] Discount_CardPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _discount.CreateDiscount_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutDiscount_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> PutDiscount_Card([FromQuery] Discount_CardPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _discount.PutDiscount_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteDiscount_Card")]
        [Authorize(Roles  = "Admin,Developer,Boss")]
        public async Task<IActionResult> DeleteDiscount_Card([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _discount.DeleteDiscount_CardAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteDiscount_CardReal")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> DeleteDiscount_CardReal([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _discount.DeleteDiscount_CardRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }
        [HttpDelete("ReturnDiscount_Card")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> ReturnDiscount_Card([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _discount.ReturnDiscount_CardAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }



    }
}
