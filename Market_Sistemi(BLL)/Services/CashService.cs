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
    public class CashService : ICash
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public CashService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<CashGetDto>> GetCashAsync()
        {
            var data = await _db.Cashes.ToListAsync();
            List<CashGetDto> response = new();
            CashGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CashGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        private async Task<Cash> GetCashByIdAsync(CashPutDto dto)
        {
            var data = await _db.Cashes.FirstOrDefaultAsync(c =>
            dto.Id != 0 ? c.Id == dto.Id : c.Number == dto.Number
            );
            return data;
        }

        public async Task<ICollection<CashGetDto>> CreateCashAsync(CashPostDto dto)
        {
            var data = await GetCashByIdAsync(new() { Number = dto.Number });
            if (data == null)
            {
                var request = _mapper.Map<Cash>(dto);
                await _db.Cashes.AddAsync(request);
                await _db.SaveChangesAsync();
            }
            var response = await GetCashAsync();
            return response;
        }

        public async Task<ICollection<CashGetDto>> PutCashAsync(CashPutDto dto)
        {
            var data = await GetCashByIdAsync(new() { Id = dto.Id });
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetCashAsync();
            return response;
        }
        public async Task<ICollection<CashGetDto>> DeleteCashRealAsync(int Id)
        {
            var data = await GetCashByIdAsync(new (){ Id = Id });
            if (data != null)
            {
                _db.Cashes.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetCashAsync();
            return response;
        }

    }
}
