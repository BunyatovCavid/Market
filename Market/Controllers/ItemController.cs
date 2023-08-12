using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController :ControllerBase
    {
        private readonly IItem _item;
        public ItemController(IItem item)
        {
            _item = item;
        }

        [HttpGet("Item")]
        public async Task<ICollection<Item>> GetItems(ItemFilterDto dto)
        {
            var data = await _item.GetAllMal(dto);
            return data;
        }

        [HttpPost("CrateItem")]
        public async Task<ICollection<Item>> CreateItem(ItemGetDto dto)
        {
            var data = await _item.Post(dto);
            return data;
        }

        [HttpPut("EditItem")]
        public async Task<Item> EditItem(ItemPutDto dto, ItemGetDto putdto)
        {
            var data = await _item.Put(dto,putdto);
            return data;
        }


        [HttpPut("DeleteItem")]
        public async Task<ICollection<Item>> DeleteItem(ItemPutDto dto)
        {
            var data = await _item.Delete(dto);
            return data;
        }






    }
}
