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
    public class CheckService:ICheck
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public CheckService(IMapper mapper,MarketDbContext db)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ICollection<CheckGetDto>> GetChecks()
        {
            var data = await _db.Checks.Include(c=>c.Discount_Card).Include(c=>c.Bonus_Card).Where(p => p.Description != "IsDelete").ToListAsync();
            List<CheckGetDto> response = new();
            CheckGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CheckGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<CheckGetDto>> GetAllChecks()
        {
            var data = await _db.Checks.ToListAsync();
            List<CheckGetDto> response = new();
            CheckGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CheckGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<CheckGetDto> GetCheckbyNumber(int Id)
        {
            var data = await _db.Checks.Include(p => p.Sales).FirstOrDefaultAsync(p => p.Id == Id);
            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }


        public async Task<CheckGetDto> CreateCheck(CheckPostDto dto)
        {
            var data = _mapper.Map<Check>(dto);
            data.Date = DateTime.Now;
            await _db.Checks.AddAsync(data);


            var response = _mapper.Map<CheckGetDto>(data);
            return response;
        }

        public async Task<ICollection<CheckGetDto>> PutCheck(CheckPostDto dto)
        {
            var data = await GetCheckbyNumber(dto.Id);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetChecks();
            return response;
        }

        public async Task<ICollection<CheckGetDto>> DeleteCheck(int Number)
        {
            var data = await GetCheckbyNumber(Number);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetChecks();
            return response;
        }

        public async Task<CheckGetDto> UseBonus_Card(int Bonus_CardBarkod,int checkid)
        {
            var data = await GetCheckbyNumber(checkid);
            var bonus_Card = await _db.Bonus_Cards.FirstOrDefaultAsync(b=>b.Barkod == Bonus_CardBarkod);

            bonus_Card.Bonus_Card_Report.Add(new() { Amount =data.Amount / 100 });
            var response = _mapper.Map<CheckGetDto>(data);
            return response;

        }

        public async Task<CheckGetDto> UseDiscount_Card(int Bonus_CardBarkod, int checkid)
        {
            var data = await _db.Checks.Include(c => c.Sales).Where(s => s.Description == "Yes").ToListAsync();
            var bonus_Card = await _db.Discount_Cards.FirstOrDefaultAsync(b => b.Barkod == Bonus_CardBarkod);
          if(bonus_Card!=null)
            {
                foreach (var item in data)
                {
                    item.Amount = (item.Amount / 100 )* 80;
                }
            }
            var response = _mapper.Map<CheckGetDto>(data);
            return response;

        }


        public async Task<ICollection<CheckGetDto>> SaveCheckByIncluded()
        {
            await _db.SaveChangesAsync();
            var data = await GetChecks();
            return data;
        }

    }
}
