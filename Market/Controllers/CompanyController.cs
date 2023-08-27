using Market.Domain.Entities;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
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
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            var data = await _company.GetCompanyAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetAllCompany")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> GetAllCompanyAsync()
        {
            var data = await _company.GetAllCompanyAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCompany")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> CreateCompanyAsync([FromQuery] CompanyPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.CreateCompanyAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCompany")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> PutCompanyAsync([FromQuery] CompanyPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.PutCompanyAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCompany")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> DeleteCompanyAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.DeleteCompanyAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpDelete("DeleteCategoryRealAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> DeleteCategoryRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.DeleteCompanyRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCategoryAsync")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> ReturnCategoryAsync([FromQuery]AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _company.ReturnCompanyAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


    }
}
