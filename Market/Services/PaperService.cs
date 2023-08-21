using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class PaperService : IPaper
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public PaperService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<PaperGetDto>> GetPapers()
        {
            var data = await _db.Papers.Where(p => p.Description != "IsDelete").ToListAsync();
            List<PaperGetDto> response = new();
            PaperGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<PaperGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<PaperGetDto>> GetAllPapers()
        {
            var data = await _db.Papers.ToListAsync();
            List<PaperGetDto> response = new();
            PaperGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<PaperGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<PaperGetDto> GetPaperbyNumber(int Number)
        {
            var data = await _db.Papers.Include(p => p.Includeds).FirstOrDefaultAsync(p => p.Paper_Number == Number);
            var response = _mapper.Map<PaperGetDto>(data);
            return response;
        }


        public async Task<PaperGetDto> CreatePaper(PaperPostDto dto)
        {
            var data = _mapper.Map<Paper>(dto);
            data.Date = DateTime.Now;

            var number = await _db.Papers.OrderByDescending(p => p.Paper_Number).FirstOrDefaultAsync();
            if (number == null)
            {
                data.Paper_Number = 1;
            }
            data.Paper_Number = number.Paper_Number + 1;
            await _db.Papers.AddAsync(data);


            var response = _mapper.Map<PaperGetDto>(data);
            return response;
        }

        public async Task<ICollection<PaperGetDto>> PutPaper(PaperPutDto dto)
        {
            var data = await GetPaperbyNumber(dto.Paper_Number);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetPapers();
            return response;
        }

        public async Task<ICollection<PaperGetDto>> DeletePaper(int Number)
        {
            var data = await GetPaperbyNumber(Number);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetPapers();
            return response;
        }

        public async Task<ICollection<PaperGetDto>> SavePaperByIncluded()
        {
            await _db.SaveChangesAsync();
            var data = await GetPapers();
            return data;
        }

    }
}
