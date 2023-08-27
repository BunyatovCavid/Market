using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Independents;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes;
using Market_Sistemi_BLL_.Dtoes.PostDtoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Data;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItem _item;
        private readonly IPaper _paper;
        private readonly IIncluded _included;
        private readonly Response _response;
        public ItemController(IItem item, IPaper paper, IIncluded included, Response response)
        {
            _item = item;
            _paper = paper;
            _included = included;
            _response = response;
        }


        [HttpGet("GetItems")]
        [Authorize(Roles = "Operator,Boss,Developer")]
        public async Task<IActionResult> GetItems()
        {
            var data = await _item.GetItems();
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpGet("GetItemsByFilter")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetItemsByFIlter([FromQuery] ItemFilterDto dto)
        {
            if (dto == null)
            {
                dto = new ItemFilterDto();
            }
            var data = await _item.GetItemsByFilter(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("CreateItem")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> CreateItem([FromQuery] ItemPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _item.CreateItemAsync(dto);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPut("PutItem")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> PutItem([FromQuery] ItemPutDto dto, [FromQuery] ItemPostDto putdto)
        {
            var check = _response.CheckState(putdto);
            if (check != null) return check;
            var data = await _item.PutItemAsync(dto, putdto);
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpDelete("DeleteItem")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> DeleteItem([FromQuery] ItemPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _item.Delete(new ItemFilterDto() { Barkod = dto.Barkod, Name = dto.Name });
            var response = _response.GetResponse(data);
            return response;
            
        }


        //Paper


        [HttpGet("GetPapers")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetPapers()
        {
            var data = await _paper.GetPapers();
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpGet("GetAllPaper")]
        [Authorize(Roles = "Developer,Boss")]
        public async Task<IActionResult> GetAllPaper()
        {
            var data = await _paper.GetAllPapers();
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpGet("GetPaperbyNumber")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetPaperByNumber([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _paper.GetPaperbyNumber(dto.Id);
            var response = _response.GetResponse(data);
            return response;
            
        }

        [HttpPost("CreatePaper")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> CreatePaper([FromQuery] PaperPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _paper.CreatePaper(dto);
            var response = _response.GetResponse(data);
            return response;
            
        }

        [HttpPut("PutPaper")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> PutPaper([FromQuery] PaperPutDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _paper.PutPaper(dto);
            var response = _response.GetResponse(data);
            return response;
            
        }

        [HttpDelete("DeletePaper")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> DeletePaper([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _paper.DeletePaper(dto.Id);
            var response = _response.GetResponse(data);
            return response;
            
        }




        //Include


        [HttpGet("GetPaperInculededsByNumber")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetPaperInculededsByNumber([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _included.GetPaperInculededsByNumber(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }


        [HttpGet("GetIncludedById")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> GetIncludedById([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _included.GetInculededById(dto.Id);
            var response = _response.GetResponse(data);
            return response;
        }

        [HttpPost("AddIncluded")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> AddIncluded([FromQuery] IncludedGetDto dto)
        {

            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _included.AddIncluded(dto);
            var response = _response.GetResponse(data);
            return response;
            

        }

        [HttpPut("PutIncluded")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> PutIncluded([FromQuery] IncludedGetDto dto)
        {

            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _included.PutIncluded(dto);
            var response = _response.GetResponse(data);
            return response;
            

        }

        [HttpDelete("DeleteIncluded")]
        [Authorize(Roles  = "Operator,Developer,Boss")]
        public async Task<IActionResult> DeleteIncluded([FromQuery] AllOneNumberPostDto dto)
        {
            var check = _response.CheckState(dto);
            if (check != null) return check;
            var data = await _included.DeleteIncluded(dto.Id);
            var response = _response.GetResponse(data);
            return response;
            

        }
    }
}
