using Market.Domain.Entities;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market.Independents;
using Market.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Developer,Boss")]
    public class CompanyController : ControllerBase
    {

        private readonly ICompany _company;
        private readonly Response _response;
        public CompanyController(ICompany company, Response response)
        {
            _response = response;
            _company = company;
        }


        [HttpGet("GetCompany")]
        [Authorize("Operator")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            var data = await _company.GetCompanyAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompanyAsync()
        {
            var data = await _company.GetAllCompanyAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCompany")]
        [Authorize("Operator")]
        public async Task<IActionResult> CreateCompanyAsync([FromQuery] CompanyPostDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.CreateCompanyAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCompany")]
        [Authorize("Operator")]
        public async Task<IActionResult> PutCompanyAsync([FromQuery] CompanyPutDto dto)
        {
            var check = await _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.PutCompanyAsync(dto);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCompany")]
        [Authorize("Operator")]
        public async Task<IActionResult> DeleteCompanyAsync([FromQuery] int Id)
        {
            var data = await _company.DeleteCompanyAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }


        [HttpDelete("DeleteCategoryRealAsync")]
        public async Task<IActionResult> DeleteCategoryRealAsync([FromQuery] int Id)
        {
            var data = await _company.DeleteCompanyRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCategoryAsync")]
        public async Task<IActionResult> ReturnCategoryAsync([FromQuery] int Id)
        {
            var data = await _company.ReturnCompanyAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }


    }
}
