using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
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

        private ICollection<PaperGetDto> Get_Back(List<Paper> data)
        {
            List<PaperGetDto> response = new();
            PaperGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<PaperGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<PaperGetDto>> GetPapers()
        {
            var data = await _db.Papers.Where(p => p.Description != "IsDelete").ToListAsync();
            var response = Get_Back(data);
            return response;
        }

        private ICollection<PaperAllGetDto> Get_BackAll(List<Paper> data)
        {
            List<PaperAllGetDto> response = new();
            PaperAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<PaperAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<PaperAllGetDto>> GetAllPapers()
        {
            var data = await _db.Papers.ToListAsync();
            var response = Get_BackAll(data);
            return response;
        }

        public async Task<PaperGetDto> GetPaperbyNumber(int Number)
        {
            var data = await _db.Papers.Include(p => p.Includeds).FirstOrDefaultAsync(p => p.Paper_Number == Number &&p.Description !="IsDelete");
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
            else
            {
                data.Paper_Number = number.Paper_Number + 1;
            }
            await _db.Papers.AddAsync(data);


            var response = _mapper.Map<PaperGetDto>(data);
            return response;
        }

        public async Task<ICollection<PaperGetDto>> PutPaper(PaperPutDto dto)
        {
            var data = await GetPaperbyNumber(dto.PaperNumber);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetPapers();
            return response;
        }

        private async Task<Paper> GetPaperAsyncByIdForMethods(int Id)
        {
            var data = await _db.Papers.FirstOrDefaultAsync(c=>c.Id==Id);
            return data;
        }
        public async Task<ICollection<PaperGetDto>> DeletePaper(int Id)
        {
            var data = await GetPaperAsyncByIdForMethods(Id);
            if (data != null)
            {
                data.Description = "IsDelete";
                foreach (var item in data.Includeds)
                {
                    item.Description = "IsDelete";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetPapers();
            return response;
        }

        public async Task<ICollection<PaperAllGetDto>> DeletePaperReal(int Id)
        {
            var data = await GetPaperAsyncByIdForMethods(Id);
            if (data != null)
            {
                _db.Papers.Remove(data);
                foreach (var item in data.Includeds)
                {
                    _db.Includeds.Remove(item);
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetAllPapers();
            return response;
        }

        public async Task<ICollection<PaperAllGetDto>> ReturnDelete(int Id)
        {
            var data = await GetPaperAsyncByIdForMethods(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                foreach (var item in data.Includeds)
                {
                    item.Description = "ReturnData";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetAllPapers();
            return response;
        }
    }
}
