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

        private async Task IncreedDecreedItems(Included data, string symbol)
        {
                var request = await _db.Items.FirstOrDefaultAsync(c => c.Id == data.ItemId);
            if (symbol == "+")
                request.Number += data.Number;
            else if (symbol == "-")
                request.Number -= data.Number;
            
        }

        private  ICollection<IncludedGetDto> Get_Back(List<Included> data)
        {
            List<IncludedGetDto> response = new();
            IncludedGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<IncludedGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<IncludedGetDto>> GetPaperInculededsByNumber(int Number)
        {
            var data = await _db.Includeds.Include(i => i.Paper).Include(i=>i.Item).Where(i => i.Paper.Paper_Number == Number && i.Description!="IsDelete").ToListAsync();
            var response = Get_Back(data);
            return response;
        }

        public async Task<IncludedGetDto> GetInculededById(int Id)
        {
            var data = await _db.Includeds.FirstOrDefaultAsync(i=>i.Id==Id);
            var response = _mapper.Map<IncludedGetDto>(data);
            return response;
        }
        private async Task<Included> GetInculededByIdForMethods(int Id)
        {
            var data = await _db.Includeds.FirstOrDefaultAsync(i => i.Id == Id);
            return data;
        }

        public async Task<ICollection<IncludedGetDto>> AddIncluded(IncludedGetDto dto)
        {
            var data = await GetInculededByIdForMethods(dto.PaperId);
            if (data == null)
            {
                await _db.Includeds.AddAsync(data);
                IncreedDecreedItems(data,"+");
                await _db.SaveChangesAsync();
            }
            var response = await GetPaperInculededsByNumber(dto.PaperId);
            return response;
        }

        public async Task<ICollection<IncludedGetDto>> PutIncluded(IncludedGetDto dto)
        {
            var data = await GetInculededByIdForMethods(dto.Id);
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
            var data = await GetInculededByIdForMethods(Id);
            ICollection<IncludedGetDto> response = null;
            if (data != null)
            {
                _db.Remove(data);
                IncreedDecreedItems(data,"-");
                await _db.SaveChangesAsync();
                response = await GetPaperInculededsByNumber(data.PaperId);
            }
            return response;
        }






    }
}
