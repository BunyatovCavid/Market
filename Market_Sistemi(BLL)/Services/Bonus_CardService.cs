using AutoMapper;
using Market.Domain.Entities;
using Market.Domain;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Microsoft.EntityFrameworkCore;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes;

namespace Market.Services
{
    public class Bonus_CardService:IBonus_Card
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public Bonus_CardService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<Bonus_CardGetDto>> GetBonus_CardAsync()
        {
            var data = await _db.Bonus_Cards.ToListAsync();
            List<Bonus_CardGetDto> response = new();
            Bonus_CardGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Bonus_CardGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        private async Task<Bonus_CardGetDto> GetBonus_CardByIdAsync(int Barkod)
        {
            var data = await _db.Bonus_Cards.FirstOrDefaultAsync(c => c.Barkod == Barkod);
            var response = _mapper.Map<Bonus_CardGetDto>(data);
            return response;
        }

        public async Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardAsync(Bonus_CardPostDto dto)
        {
            var data = await GetBonus_CardByIdAsync(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Bonus_Card>(dto);
                await _db.AddAsync(request);
            }
            var response = await GetBonus_CardAsync();
            return response;
        }

        public async Task<ICollection<Bonus_CardGetDto>> PutBonus_CardAsync(Bonus_cardPutDto dto)
        {
            var data = await GetBonus_CardByIdAsync(dto.Barkod);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetBonus_CardAsync();
            return response;
        }

        public async Task<ICollection<Bonus_CardGetDto>> DeleteBonus_CardAsync(int Barkod)
        {
            var data = await GetBonus_CardByIdAsync(Barkod);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetBonus_CardAsync();
            return response; ;
        }



        private async Task<Bonus_Card_ReportGetDto> GetBonus_Card_ReportAsync(int Barkod)
        {
            var data = await _db.Bonus_Cards.Include(c=>c.Bonus_Card_Report).FirstOrDefaultAsync(c => c.Barkod == Barkod);
            var response = _mapper.Map<Bonus_Card_ReportGetDto>(data);
            return response;
        }


        public async Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardReportAsync(Bonus_Card_ReportPostDto dto)
        {
            var data = await GetBonus_Card_ReportAsync(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Bonus_Card>(dto);
                await _db.AddAsync(request);
            }
            var response = await GetBonus_CardAsync();
            return response;
        }

        public async Task<Bonus_Card_ReportGetDto> DeleteBonus_Card_ReportAsync(Bonus_Card_ReportDeleteDto dto)
        {
            var data = await GetBonus_Card_ReportAsync(dto.Barkod);
            if (data != null)
            {
                foreach (var item in data.Bonus_Card_Reports)
                {
                    if(item.Bonus_CardId==dto.Id)
                    {
                        data.Description = "IsDelete";
                    }
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetBonus_Card_ReportAsync(dto.Barkod);
            return response; ;
        }



    }
}
