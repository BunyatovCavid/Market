using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Market.Services
{
    public class IncludedService:IIncluded
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public IncludedService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<IncludedGetDto>> GetPaperInculededsByNumber(int Number)
        {
            var data = await _db.Includeds.Include(i => i.Paper).Include(i=>i.Item).Where(i => i.Paper.Paper_Number == Number && i.Description!="IsDelete").ToListAsync();
            List<IncludedGetDto> response = new();
            IncludedGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<IncludedGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<IncludedGetDto> GetInculededById(int Id)
        {
            var data = await _db.Includeds.FirstOrDefaultAsync(i=>i.Id==Id);
            var response = _mapper.Map<IncludedGetDto>(data);
            return response;
        }

        public async Task<ICollection<IncludedGetDto>> AddIncluded(IncludedGetDto dto)
        {
            var data = await GetPaperInculededsByNumber(dto.PaperId);
            if (data == null)
            {
                var request = _mapper.Map<Sale>(dto);
                await _db.AddAsync(request);
            }
            var response = await GetPaperInculededsByNumber(dto.PaperId);
            return response;
        }

        public async Task<ICollection<IncludedGetDto>> PutIncluded(IncludedGetDto dto)
        {
            var data = await GetInculededById(dto.Id);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetPaperInculededsByNumber(dto.PaperId);
            return response;
        }

        public async Task<ICollection<IncludedGetDto>> DeleteIncluded(int Id)
        {
            var data = await GetInculededById(Id);
            ICollection<IncludedGetDto> response = null;
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
                response = await GetPaperInculededsByNumber(data.PaperId);
            }
            return response;
        }






    }
}
