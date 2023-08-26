using Market.Dtoes.Get_Dtoes;
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
    [Authorize(Roles = "Developer,Boss")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        private readonly ISub_Category _sub_category;
        private readonly Response _response;
        public CategoryController(ICategory category, ISub_Category sub_category, Response response)
        {
            _category = category;
            _sub_category = sub_category;
            _response = response;
        }


        [HttpGet("GetCategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetCategoryAsync()
        {
            var data = await _category.GetCategoryAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryByIdAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetCategoryGetCategoryByIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.GetCategoryByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryBySubCategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetCategoryBySubCategoryAsync()
        {
            var data = await _category.GetCategoryBySubCategoryAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryBySubCategoryByIdAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetCategoryBySubCategoryByIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.GetCategoryBySubCategoryByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryAllAsync")]
        public async Task<IActionResult> GetCategoryAllAsync()
        {
            var data = await _category.GetCategoryAllAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryAllBySubCategoryAsync")]
        public async Task<IActionResult> GetCategoryAllBySubCategoryAsync()
        {
            var data = await _category.GetCategoryAllBySubCategoryAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateCategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> CreateCategoryAsync([FromQuery] CategoryPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.CreateCategoryAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutCategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> PutCategoryAsync([FromQuery] CategoryPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.PutCategoryAsync(dto);
            var response_ = _response.GetResponse(data);
            return response_;
        }

        [HttpDelete("DeleteCategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> DeleteCategoryAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.DeleteCategoryAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteCategoryRealAsync")]
        public async Task<IActionResult> DeleteCategoryRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.DeleteCategoryRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnCategoryAsync")]
        public async Task<IActionResult> ReturnCategoryAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _category.ReturnCategoryAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


        //Sub_Category

        [HttpGet("GetSub_CategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetSub_CategoryAsync()
        {
            var data = await _sub_category.GetSub_CategoryAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryByIdAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetSub_CategoryByIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.GetSub_CategoryByIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryByCategoryIdAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GetSub_CategoryByCategoryIdAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.GetSub_CategoryByCategoryIdAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryAllAsync")]
        public async Task<IActionResult> GetSub_CategoryAllAsync()
        {
            var data = await _sub_category.GetSub_CategoryAllAsync();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateSub_CategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> CreateSub_CategoryAsync([FromQuery] Sub_CategoryPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.CreateSub_CategoryAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutSub_CategoryAsync")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> PutSub_CategoryAsync([FromQuery] Sub_CategoryPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.PutSub_CategoryAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSub_CategoryAsync")]
        public async Task<IActionResult> DeleteSub_CategoryAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.DeleteSub_CategoryAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSub_CategoryRealAsync")]
        public async Task<IActionResult> DeleteSub_CategoryRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.DeleteSub_CategoryRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnSub_CategoryRealAsync")]
        public async Task<IActionResult> ReturnSub_CategoryRealAsync([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _sub_category.ReturnSub_CategoryRealAsync(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }
    }
}
