using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class ItemService : IItem
    {
        private MarketDbContext _db { get; set; }
        private IMapper _mapper { get; set; }

        public ItemService(MarketDbContext DB, IMapper mapper)
        {
            _db = DB;
            _mapper = mapper;
        }

        public async Task<ICollection<Item>> Delete(ItemPutDto dto)
        {
            var data = await _db.Items.FirstOrDefaultAsync(i =>
            dto.Barkod != null ? i.Barkod == dto.Barkod : i.Barkod != 0 &&
            dto.Name != null ? i.Name == dto.Name : i.Name != ""
            );

            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();

                var response = await _db.Items.FirstOrDefaultAsync();
                return (ICollection<Item>)response;
            }
            data.Description = "Empty Data";
            return (ICollection<Item>)data;
        }

        public async Task<ICollection<Item>> GetAllMal(ItemFilterDto dto)
        {
            var data = await _db.Items.FirstOrDefaultAsync(i =>
                  dto.Barkod != null ? i.Barkod == dto.Barkod : i.Barkod != 0 &&
                  dto.Name != null ? i.Name == dto.Name : i.Name != "" &&
                  dto.Category!=null?i.CategoryId==dto.Category : i.CategoryId !=0 &&
                  dto.Company!=null?i.CompanyId == dto.Company :i.CompanyId!=0 &&
                  dto.Sub_Category!=null?i.Sub_CategoryId ==dto.Sub_Category:i.Sub_CategoryId!=0 &&
                  dto.Before_Date!=null? dto.After_Date!=null? i.Date>dto.Before_Date && i.Date<dto.After_Date :i.Date>dto.Before_Date :i.Date!=null
                  );

            return (ICollection<Item>)data;


        }

        public async Task<ICollection<Category>> GetKategori(CategoryDto dto)
        {
            var data = await _db.Categories.FirstOrDefaultAsync(c=>dto.Name!=null?c.Name == dto.Name:c.Name!="");
            return (ICollection<Category>)data;
        }
        public async Task<ICollection<Item>> Post(ItemGetDto dto)
        {
            var check = await _db.Items.FirstOrDefaultAsync(i =>
              dto.Barkod != null ? i.Barkod == dto.Barkod : i.Barkod != 0);
            if (check == null)
            {
                var data = _mapper.Map<Item>(dto);
                await _db.Items.AddAsync(data);
                await _db.SaveChangesAsync();


                var response = await _db.Items.FirstOrDefaultAsync();
                return (ICollection<Item>)response;
            }
            else
            {
                check.Description = "Dont Empty";
                return (ICollection<Item>)check;
            }
        }

        public async Task<Item> Put(ItemPutDto dto, ItemGetDto putdto)
        {
            var data = await _db.Items.FirstOrDefaultAsync(i =>
            dto.Barkod != null ? i.Barkod == dto.Barkod : i.Barkod != 0 &&
            dto.Name != null ? i.Name == dto.Name : i.Name != ""
            );

            _mapper.Map(data, putdto);
            await _db.SaveChangesAsync();

            return data;
        }

        public async Task<ICollection<Sub_Category>> GetSub_Category(Category dto)
        {
            var data = await _db.Categories.FirstOrDefaultAsync(c => dto.Name != null ? c.Name == dto.Name : c.Name != "");
            return (ICollection<Sub_Category>)data;
        }
    }
}
