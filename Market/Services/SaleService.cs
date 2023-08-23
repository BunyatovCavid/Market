using AutoMapper;
using Market.Domain.Entities;
using Market.Domain;
using Market.Dtoes.Get_Dtoes;
using Microsoft.EntityFrameworkCore;
using Market.Interfaces;

namespace Market.Services
{
    public class SaleService:ISale
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public SaleService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<SaleGetDto>> GetSales(int Number)
        {
            var data = await _db.Sales.Include(i => i.Check).Include(i => i.Item).Where(i => i.Check.Id == Number && i.Description != "IsDelete").ToListAsync();
            List<SaleGetDto> response = new();
            SaleGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<SaleGetDto>(item);
                request.ItemName = item.Item.Name;
                request.ItemBarkod = item.Item.Barkod;
                request.Amount = item.Item.Amount * item.Number;
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<SaleGetDto>> GetAllSale(int id)
        {
            var data = await _db.Sales.Include(c => c.Check).Where(c=>c.CheckId==id).ToListAsync();
            List<SaleGetDto> response = new();
            SaleGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<SaleGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<SaleGetDto> GetSaleById(int Id)
        {
            var data = await _db.Sales.FirstOrDefaultAsync(i => i.Id == Id);
            var response = _mapper.Map<SaleGetDto>(data);
            return response;
        }


        public async Task<ICollection<SaleGetDto>> PutSale(SaleGetDto dto)
        {
            var data = await GetSaleById(dto.Id);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetSales(dto.Id);
            return response;
        }

        public async Task<ICollection<SaleGetDto>> DeleteSale(int Id)
        {
            var data = await GetSaleById(Id);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetSales(data.Id);
            return response;
        }

        public Task<ICollection<SaleGetDto>> AddSale(SaleGetDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
