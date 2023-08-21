using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckController : Controller
    {
        private readonly ISale _sale;
        private readonly ICheck _check;

        public CheckController(ISale sale, ICheck check)
        {
            _sale = sale;
            _check = check;
        }


        [HttpGet("GetChecks")]
        public async Task<IActionResult> GetChecks()
        {

            var data = await _check.GetChecks();
            if (data != null)
                return Ok(data);
            return NotFound();
        }


        [HttpGet("GetAllCheck")]
        public async Task<IActionResult> GetAllCheck()
        {

            var data = await _check.GetAllChecks();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet("GetCheckbyNumber")]
        public async Task<IActionResult> GetCheckByNumber([FromQuery] int Number)
        {
            var data = await _check.GetCheckbyNumber(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpPost("CreateCheck")]
        public async Task<IActionResult> CreateCheck([FromQuery] CheckPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _check.CreateCheck(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutCheck")]
        public async Task<IActionResult> PutCheck([FromQuery] CheckPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _check.PutCheck(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem([FromQuery] int Number)
        {
            var data = await _check.DeleteCheck(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet("SaveCheck")]
        public async Task<IActionResult> SaveCheck()
        {

            var data = await _check.SaveCheckByIncluded();
            if (data != null)
                return Ok(data);
            return NotFound();
        }




        [HttpGet("GetCheckSaleByNumber")]
        public async Task<IActionResult> GetCheckInculededsByNumber([FromQuery] int Number)
        {
            var data = await _sale.GetSales(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }


        [HttpGet("GetSaleById")]
        public async Task<IActionResult> GetSaleById([FromQuery] int Id)
        {
            var data = await _sale.GetSaleById(Id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpPost("AddSale")]
        public async Task<IActionResult> AddSale([FromQuery] SaleGetDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _sale.AddSale(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutSale")]
        public async Task<IActionResult> PutSale([FromQuery] SaleGetDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _sale.PutSale(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteSale")]
        public async Task<IActionResult> DeleteSale([FromQuery] int Number)
        {
            var data = await _sale.DeleteSale(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}
