using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class DiscountService:IDiscount_Card
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public DiscountService (IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<Discount_CardGetDto>> GetDiscount_CardAsync()
        {
            var data = await _db.Discount_Cards.ToListAsync();
            List<Discount_CardGetDto> response = new();
            Discount_CardGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Discount_CardGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        private async Task<Discount_CardGetDto> GetDiscount_CardByIdAsync(int Barkod)
        {
            var data = await _db.Discount_Cards.FirstOrDefaultAsync(c => c.Barkod == Barkod);
            var response = _mapper.Map<Discount_CardGetDto>(data);
            return response;
        }

        public async Task<ICollection<Discount_CardGetDto>> CreateDiscount_CardAsync(Discount_CardPostDto dto)
        {
            var data = await GetDiscount_CardByIdAsync(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Discount_Card>(dto);
                await _db.AddAsync(request);
            }
            var response = await GetDiscount_CardAsync();
            return response;
        }

        public async Task<ICollection<Discount_CardGetDto>> PutDiscount_CardAsync(Discount_CardPutDto dto)
        {
            var data = await GetDiscount_CardByIdAsync(dto.Barkod);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetDiscount_CardAsync();
            return response;
        }

        public async Task<ICollection<Discount_CardGetDto>> DeleteDiscount_CardAsync(Discount_CardPutDto dto)
        {
            var data = await GetDiscount_CardByIdAsync(dto.Barkod);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetDiscount_CardAsync();
            return response; ;
        }

    }
}
