using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItem _item;
        private readonly IPaper _paper;
        private readonly IIncluded _included;
        public ItemController(IItem item, IPaper paper, IIncluded included)
        {
            _item = item;
            _paper = paper;
            _included = included;
        }

        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItems([FromQuery] ItemFilterDto dto)
        {
            if (ModelState.IsValid)
            {
                if (dto == null)
                {
                    dto = new ItemFilterDto();
                }
                var data = await _item.GetItemsByFilter(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> CreateItem([FromQuery] ItemGetDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _item.CreateItemAsync(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutItem")]
        public async Task<IActionResult> PutItem([FromQuery] ItemPutDto dto, [FromQuery] ItemGetDto putdto)
        {
            if (ModelState.IsValid)
            {
                var data = await _item.Put(dto, putdto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }


        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem([FromQuery] ItemPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _item.Delete(new ItemFilterDto { Barkod = dto.Barkod, Name = dto.Name });
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }




        [HttpGet("GetPapers")]
        public async Task<IActionResult> GetPapers()
        {

            var data = await _paper.GetPapers();
            if (data != null)
                return Ok(data);
            return NotFound();
        }


        [HttpGet("GetAllPaper")]
        public async Task<IActionResult> GetAllPaper()
        {

            var data = await _paper.GetAllPapers();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet("GetPaperbyNumber")]
        public async Task<IActionResult> GetPaperByNumber([FromQuery] int Number)
        {
            var data = await _paper.GetPaperbyNumber(Number);
                if (data != null)
                    return Ok(data);
                return NotFound();
        }

        [HttpPost("CreatePaper")]
        public async Task<IActionResult> CreatePaper([FromQuery] PaperPostDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _paper.CreatePaper(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutPaper")]
        public async Task<IActionResult> PutPaper([FromQuery] PaperPutDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _paper.PutPaper(dto);
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
                var data = await _paper.DeletePaper(Number);
                if (data != null)
                    return Ok(data);
                return NotFound();
        }

        [HttpGet("SavePaper")]
        public async Task<IActionResult> SavePaper()
        {

            var data = await _paper.SavePaperByIncluded();
            if (data != null)
                return Ok(data);
            return NotFound();
        }




        [HttpGet("GetPaperInculededsByNumber")]
        public async Task<IActionResult> GetPaperInculededsByNumber([FromQuery] int Number)
        {
            var data = await _included.GetPaperInculededsByNumber(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }


        [HttpGet("GetIncludedById")]
        public async Task<IActionResult> GetIncludedById([FromQuery] int Id)
        {
            var data = await _included.GetInculededById(Id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpPost("AddIncluded")]
        public async Task<IActionResult> AddIncluded([FromQuery] IncludedGetDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _included.AddIncluded(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpPut("PutIncluded")]
        public async Task<IActionResult> PutIncluded([FromQuery] IncludedGetDto dto)
        {
            if (ModelState.IsValid)
            {
                var data = await _included.PutIncluded(dto);
                if (data != null)
                    return Ok(data);
                return NotFound();
            }
            var response = ModelState.Values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
            return BadRequest(response);
        }

        [HttpDelete("DeleteIncluded")]
        public async Task<IActionResult> DeleteIncluded([FromQuery] int Number)
        {
            var data = await _included.DeleteIncluded(Number);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
    }
}
