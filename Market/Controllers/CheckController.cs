using AutoMapper.Execution;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market.Independents;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Developer,Boss")]
    public class CheckController : ControllerBase
    {
        private readonly ISale _sale;
        private readonly ICheck _check;
        private readonly Response _response;
        public CheckController(ISale sale, ICheck check, Response response)
        {
            _sale = sale;
            _check = check;
            _response = response;

        }

        [HttpGet("GetChecksAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetChecksAsync()
        {
            var data = await _check.GetChecksAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllChecksAsync")]
        public async Task<IActionResult> GetAllChecksAsync()
        {
            var data = await _check.GetAllChecksAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCheckbyNumberAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetCheckbyNumberAsync(AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.GetCheckbyNumberAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCheckAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> CreateCheckAsync([FromQuery] CheckPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.CreateCheckAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("UseBonus_CardAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> UseBonus_CardAsync([FromQuery] UseCardPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.UseBonus_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("UseDiscount_CardAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> UseDiscount_CardAsync([FromQuery] UseCardPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.UseDiscount_CardAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("AddAmountInCheckAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> AddAmountInCheckAsync([FromQuery] AddAmountPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.AddAmountInCheckAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("SaveCheckByIncluded")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> SaveCheckByIncluded([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.SaveCheckByIncluded(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCheckAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteCheckAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _check.DeleteCheckAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCheckRealAsync")]
        public async Task<IActionResult> DeleteCheckRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data =  await _check.DeleteCheckRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCheckAsync")]
        public async Task<IActionResult> ReturnCheckAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data =  await _check.ReturnCheckAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


        //Sale


        [HttpGet("GetSalesAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetSalesAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.GetSalesAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllSalesAsync")]
        public async Task<IActionResult> GetAllSalesAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.GetAllSalesAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSaleByIdAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetSaleByIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.GetSaleByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSaleVisualAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> GetSaleVisualAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.GetSaleVisualAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("AddSaleVisualAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> AddSaleVisualAsync([FromQuery] SalePostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.AddSaleVisualAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutSaleOwnerAsync")]
        public async Task<IActionResult> PutSaleOwnerAsync([FromQuery] SalePutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.PutSaleOwnerAsync(dto);
            var response = _response.GetResponse(data);
            return response;

        }

        [HttpPut("PutSaleVisualAsync")]
        [Authorize("Admin,Kassir")]
        public async Task<IActionResult> PutSaleVisualAsync([FromQuery] SalePutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.PutSaleVisualAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutSaleVisualOwnerAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> PutSaleVisualOwnerAsync([FromQuery] SalePutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.PutSaleVisualOwnerAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSaleVisualAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteSaleVisualAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.DeleteSaleVisualAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSaleAsync")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteSaleAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.DeleteSaleAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSaleRealAsync")]
        public async Task<IActionResult> DeleteSaleRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.DeleteSaleRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnSaleAsync")]
        public async Task<IActionResult> ReturnSaleAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sale.ReturnSaleAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

    }
}
