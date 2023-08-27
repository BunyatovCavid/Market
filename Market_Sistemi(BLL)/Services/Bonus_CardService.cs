using AutoMapper;
using Market.Domain.Entities;
using Market.Domain;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Microsoft.EntityFrameworkCore;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes;
using Market_Sistemi_BLL_.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace Market.Services
{
    public class Bonus_CardService : IBonus_Card
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public Bonus_CardService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<ICollection<Bonus_CardAllGetDto>> GetAllBonus_CardAsync()
        {
            var data = await _db.Bonus_Cards.ToListAsync();
            List<Bonus_CardAllGetDto> response = new();
            Bonus_CardAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Bonus_CardAllGetDto>(item);
                response.Add(request);
            }
            return response;

        }

        public async Task<ICollection<Bonus_CardGetDto>> GetBonus_CardAsync()
        {
            var data = await _db.Bonus_Cards.Where(b => b.Description != "IsDelete").ToListAsync();
            List<Bonus_CardGetDto> response = new();
            Bonus_CardGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Bonus_CardGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        private async Task<Bonus_CardGetDto> GetBonus_CardByIdAsync(int Id)
        {
            var data = await _db.Bonus_Cards.FirstOrDefaultAsync(c => c.Id == Id && c.Description != "IsDelete");
            var response = _mapper.Map<Bonus_CardGetDto>(data);
            return response;
        }

        public async Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardAsync(Bonus_CardPostDto dto)
        {
            var data = await GetBonus_CardByIdAsync(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Bonus_Card>(dto);
                request.Bonus = 0;
                await _db.Bonus_Cards.AddAsync(request);
                await _db.SaveChangesAsync();
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


        private async Task<Bonus_Card> GetBonus_CardByIdForDelete(int Id)
        {
            var data = await _db.Bonus_Cards.FirstOrDefaultAsync(b => b.Id == Id);
            return data;
        }
        public async Task<ICollection<Bonus_CardGetDto>> DeleteBonus_CardAsync(int Barkod)
        {
            var data = await GetBonus_CardByIdForDelete(Barkod);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetBonus_CardAsync();
            return response; ;
        }


        public async Task<Bonus_CardGetDto> CreateBonus_CardReportAsync(Bonus_Card_ReportPostDto dto)
        {
            var data = await GetBonus_CardByIdForDelete(dto.Barkod);
            if (data == null)
            {
                var request = _mapper.Map<Bonus_Card>(dto);
                await _db.Bonus_Cards.AddAsync(request);
            }
            var response = await GetBonus_CardByIdAsync(dto.Barkod);
            return response;
        }

        public async Task<ICollection<Bonus_CardGetDto>> DeleteBonus_Card_ReportAsync(Bonus_Card_ReportDeleteDto dto)
        {
            var data = await GetBonus_CardByIdForDelete(dto.Barkod);
            if (data != null)
            {
                foreach (var item in data.Bonus_Card_Report)
                {
                    if (item.Bonus_CardId == dto.Id)
                    {
                        data.Description = "IsDelete";
                    }
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetBonus_CardAsync();
            return response;
        }



        public async Task<ICollection<Bonus_CardAllGetDto>> DeleteBonus_CardRealAsync(int Id)
        {
            var data = await GetBonus_CardByIdForDelete(Id);
            if (data != null)
            {
                _db.Bonus_Cards.Remove(data);
                foreach (var item in data.Bonus_Card_Report)
                {
                    _db.Bonus_Card_Reports.Remove(item);
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetAllBonus_CardAsync();
            return response;
        }

        public async Task<ICollection<Bonus_CardAllGetDto>> ReturnBonus_CardAsync(int Id)
        {
            var data = await GetBonus_CardByIdForDelete(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                foreach (var item in data.Bonus_Card_Report)
                {
                    item.Description = "ReturnData";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetAllBonus_CardAsync();
            return response;

        }

        private ICollection<Bonus_CardAllGetDto> Get_BackAll(List<Bonus_Card> data)
        {
            List<Bonus_CardAllGetDto> response = new();
            Bonus_CardAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Bonus_CardAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }


        public async Task<ICollection<Bonus_CardAllGetDto>> GetAllBonus_CardReportAsync()
        {
            var data = await _db.Bonus_Cards.Include(c => c.Bonus_Card_Report).ToListAsync();
            var response = Get_BackAll(data);
            return response;

        }

        private async Task<Bonus_CardAllGetDto> GetBonus_CardReportbyIdAsync(AllTwoNumberPostDto dto)
        {
            var data = await _db.Bonus_Card_Reports.FirstOrDefaultAsync(c=>c.Bonus_CardId==dto.Number2 && c.Id == dto.Number1);
            var response = _mapper.Map<Bonus_CardAllGetDto>(data);
            return response;
        }

        private async Task<Bonus_Card> GetBonus_Card_ReportForDeleteAsync(int Barkod)
        {
            var data = await _db.Bonus_Cards.Include(c => c.Bonus_Card_Report).FirstOrDefaultAsync(c => c.Barkod == Barkod);
            return data;

        }
        private async Task Delete_Back(Bonus_Card data)
        {
            if (data != null)
            {
                foreach (var item in data.Bonus_Card_Report)
                {
                    item.Description = "ReturnData";
                }
                await _db.SaveChangesAsync();
            }
        }
        public async Task<Bonus_CardAllGetDto> DeleteBonus_Card_ReportRealAsync(AllTwoNumberPostDto dto)
        {
            var data = await GetBonus_CardByIdForDelete(dto.Number1);
            await Delete_Back(data);
            var response = await GetBonus_CardReportbyIdAsync(dto);
            return response;
        }

        private async Task Return_Back(Bonus_Card data, int Number)
        {
            if (data != null)
            {
                foreach (var item in data.Bonus_Card_Report)
                {
                    if (item.Id == Number)
                    {
                        item.Description = "Return Data";
                    }
                }
                await _db.SaveChangesAsync();
            }
        }
        public async Task<Bonus_CardAllGetDto> ReturnBonus_Card_ReportAsync(AllTwoNumberPostDto dto)
        {
            var data = await GetBonus_CardByIdForDelete(dto.Number2);
            await Return_Back(data, dto.Number1);
            var response = await GetBonus_CardReportbyIdAsync(dto);
            return response;
        }


    }
}
