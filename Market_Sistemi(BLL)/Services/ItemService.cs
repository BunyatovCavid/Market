using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.PostDtoes;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class ItemService : IItem
    {
        private MarketDbContext _db { get; set; }
        private IMapper _mapper { get; set; }
        private ItemFilterDto _emptyfilter;
        public ItemService(MarketDbContext DB, IMapper mapper, ItemFilterDto emptyfilter)
        {
            _db = DB;
            _mapper = mapper;
            _emptyfilter = emptyfilter;
        }

        public async Task<ICollection<ItemGetDto>> Delete(ItemFilterDto dto)
        {
            var data = await GetItemsByFilter(new ItemFilterDto() { Barkod = dto.Barkod });

            if (data != null)
            {
                foreach (var item in data)
                {
                    item.Description = "IsDelete";
                    await _db.SaveChangesAsync();
                }
            }
            var response = await GetItemsByFilter(_emptyfilter);
            return response;
        }

        private async Task<ICollection<Item>> ItemFilter(ItemFilterDto dto)
        {
            var data = await _db.Items.Where(i =>
                 dto.Barkod != null ? i.Barkod == dto.Barkod : i.Barkod != 0 &&
                 dto.Name != null ? i.Name == dto.Name : i.Name != "" &&
                 dto.CategoryId != null ? i.CategoryId == dto.CategoryId : i.CategoryId != 0 &&
                 dto.CompanyId != null ? i.CompanyId == dto.CompanyId : i.CompanyId != 0 &&
                 dto.Sub_CategoryId != null ? i.Sub_CategoryId == dto.Sub_CategoryId : i.Sub_CategoryId != 0 &&
                 dto.Before_Date != null ? dto.After_Date != null ? i.Date > dto.Before_Date && i.Date < dto.After_Date : i.Date > dto.Before_Date : i.Date != null
                 ).ToListAsync();

            return data;
        }
        public async Task<ICollection<ItemGetDto>> GetItemsByFilter(ItemFilterDto dto)
        {
            var data = await ItemFilter(dto);
            List<ItemGetDto> response = new();
            ItemGetDto request = new();
            foreach (var item in data)
            {
                request =_mapper.Map<ItemGetDto>(item);
                response.Add(request);
            }
            return response;

        }

        public async Task<ICollection<ItemGetDto>> CreateItemAsync(ItemPostDto dto)
        { 
            var check = await GetItemsByFilter(new ItemFilterDto { Name =dto.Name, Barkod = dto.Barkod});
            if (check.Count == 0)
            {
                var data = _mapper.Map<Item>(dto);
                data.Date = DateTime.Now;
                await _db.AddAsync(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetItemsByFilter(_emptyfilter);
            return response;

        }

        public async Task<ICollection<ItemGetDto>> PutItemAsync(ItemPutDto dto, ItemPostDto putdto)
        {
            var data = await GetItemsByFilter(new ItemFilterDto() { Barkod = dto.Barkod,Name = dto.Name});
            if (data != null)
            {
                foreach (var item in data)
                {
                    _mapper.Map(dto, item);
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetItemsByFilter(_emptyfilter);
            return response;
        }
    }
}
