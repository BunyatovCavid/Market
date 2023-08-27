using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
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

        private ICollection<Discount_CardGetDto> Get_Back(List<Discount_Card> data)
        {
            List<Discount_CardGetDto> response = new();
            Discount_CardGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Discount_CardGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<Discount_CardGetDto>> GetDiscount_CardAsync()
        {
            var data = await _db.Discount_Cards.Where(d=>d.Description !="IsDelete").ToListAsync();
            var response = Get_Back(data);
            return response;
        }

        private ICollection<Discount_CardAllGetDto> Get_BackAll(List<Discount_Card> data)
        {
            List<Discount_CardAllGetDto> response = new();
            Discount_CardAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Discount_CardAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<Discount_CardAllGetDto>> GetAllDiscount_CardAsync()
        {
            var data = await _db.Discount_Cards.ToListAsync();
            var response = Get_BackAll(data);
            return response;
        }

        private async Task<Discount_Card> GetDiscount_CardByIdAsync(int Barkod)
        {
            var data = await _db.Discount_Cards.FirstOrDefaultAsync(c => c.Barkod == Barkod && c.Description!="IsDelete");
            return data;
        }

        public async Task<ICollection<Discount_CardGetDto>> CreateDiscount_CardAsync(Discount_CardPostDto dto)
        {
            var data = await GetDiscount_CardByIdAsync(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Discount_Card>(dto);
                await _db.AddAsync(request);
                await _db.SaveChangesAsync();
            }
            var response = await GetDiscount_CardAsync();
            return response;
        }

        public async Task<ICollection<Discount_CardGetDto>> PutDiscount_CardAsync(Discount_CardPutDto dto)
        {
            var data = await GetDiscount_CardByIdAsync((int)dto.Barkod);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetDiscount_CardAsync();
            return response;
        }

        private async Task<Discount_Card> GetDiscount_CardForDeleteAsync(int Id)
        {
            var data = await _db.Discount_Cards.FirstOrDefaultAsync(d=>d.Id==Id);
            return data;
        }
        public async Task<ICollection<Discount_CardGetDto>> DeleteDiscount_CardAsync(int Barkod)
        {
            var data = await GetDiscount_CardByIdAsync(Barkod);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetDiscount_CardAsync();
            return response; ;
        }
        public async Task<ICollection<Discount_CardAllGetDto>> DeleteDiscount_CardRealAsync(int Id)
        {
            var data = await GetDiscount_CardForDeleteAsync(Id);
            if (data != null)
            {
                _db.Discount_Cards.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAllDiscount_CardAsync();
            return response; ;
        }
        public async Task<ICollection<Discount_CardAllGetDto>> ReturnDiscount_CardAsync(int Id)
        {
            var data = await GetDiscount_CardForDeleteAsync(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetAllDiscount_CardAsync();
            return response; ;
        }

    }
}
