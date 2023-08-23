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
        public async Task<IActionResult> GetCategoryAsync()
        {
            var data = await _category.GetCategoryAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryByIdAsync")]
        public async Task<IActionResult> GetCategoryGetCategoryByIdAsync([FromQuery] int Id)
        {
            var data = await _category.GetCategoryByIdAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryBySubCategoryAsync")]
        public async Task<IActionResult> GetCategoryBySubCategoryAsync()
        {
            var data = await _category.GetCategoryBySubCategoryAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryBySubCategoryByIdAsync")]
        public async Task<IActionResult> GetCategoryBySubCategoryByIdAsync([FromQuery]int Id)
        {
            var data = await _category.GetCategoryBySubCategoryByIdAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetCategoryAllAsync")]
        public async Task<IActionResult> GetCategoryAllAsync()
        {
            var data = await _category.GetCategoryAllAsync();
            var response = await _response.GetResponse(data);
            return response;
        }
        
        [HttpGet("GetCategoryAllBySubCategoryAsync")]
        public async Task<IActionResult> GetCategoryAllBySubCategoryAsync()
        {
            var data = await _category.GetCategoryAllBySubCategoryAsync();
            var response = await _response.GetResponse(data);
            return response;
        }
        
        [HttpPost("CreateCategoryAsync")]
        public async Task<IActionResult> CreateCategoryAsync([FromQuery]CategoryPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _category.CreateCategoryAsync(dto);
                var response_ = await _response.GetResponse(data);
                return response_;
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }
        
        [HttpPut("PutCategoryAsync")]
        public async Task<IActionResult> PutCategoryAsync([FromQuery]CategoryPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _category.PutCategoryAsync(dto);
                var response_ = await _response.GetResponse(data);
                return response_;
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }
        
        [HttpDelete("DeleteCategoryAsync")]
        public async Task<IActionResult> DeleteCategoryAsync([FromQuery]int Id)
        {
            var data = await _category.DeleteCategoryAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }
        
        [HttpDelete("DeleteCategoryRealAsync")]
        public async Task<IActionResult> DeleteCategoryRealAsync([FromQuery] int Id)
        {
            var data = await _category.DeleteCategoryRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }
      
        [HttpPut("ReturnCategoryAsync")]
        public async Task<IActionResult> ReturnCategoryAsync([FromQuery]int Id)
        {
            var data = await _category.ReturnCategoryAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }


        //Sub_Category

        [HttpGet("GetSub_CategoryAsync")]
        public async Task<IActionResult> GetSub_CategoryAsync()
        {
            var data = await _sub_category.GetSub_CategoryAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryByIdAsync")]
        public async Task<IActionResult> GetSub_CategoryByIdAsync([FromQuery] int Id)
        {
            var data = await _sub_category.GetSub_CategoryByIdAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryByCategoryIdAsync")]
        public async Task<IActionResult> GetSub_CategoryByCategoryIdAsync([FromQuery]int Id)
        {
            var data = await _sub_category.GetSub_CategoryByCategoryIdAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetSub_CategoryAllAsync")]
        public async Task<IActionResult> GetSub_CategoryAllAsync()
        {
            var data = await _sub_category.GetSub_CategoryAllAsync();
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateSub_CategoryAsync")]
        public async Task<IActionResult> CreateSub_CategoryAsync([FromQuery] Sub_CategoryPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _sub_category.CreateSub_CategoryAsync(dto);
                var response_ = await _response.GetResponse(data);
                return response_;
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutSub_CategoryAsync")]
        public async Task<IActionResult> PutSub_CategoryAsync([FromQuery] Sub_CategoryPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _sub_category.PutSub_CategoryAsync(dto);
                var response_ = await _response.GetResponse(data);
                return response_;
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteSub_CategoryAsync")]
        public async Task<IActionResult> DeleteSub_CategoryAsync([FromQuery] int Id)
        {
            var data = await _sub_category.DeleteSub_CategoryAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpDelete("DeleteSub_CategoryRealAsync")]
        public async Task<IActionResult> DeleteSub_CategoryRealAsync([FromQuery] int Id)
        {
            var data = await _sub_category.DeleteSub_CategoryRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }

        [HttpPut("ReturnSub_CategoryRealAsync")]
        public async Task<IActionResult> ReturnSub_CategoryRealAsync([FromQuery] int Id)
        {
            var data = await _sub_category.ReturnSub_CategoryRealAsync(Id);
            var response = await _response.GetResponse(data);
            return response;
        }
    }
}
