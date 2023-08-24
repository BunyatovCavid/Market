using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class CompanyService : ICompany
    {
        private IMapper _mapper;
        private MarketDbContext _db;

        public CompanyService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        private async Task<CompanyGetDto> GetCompanyByIdAsync(string Name)
        {
            var data = await _db.Companies.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Name == Name);
            var response = _mapper.Map<CompanyGetDto>(data);
            return response;
        }
        public async Task<ICollection<CompanyGetDto>> CreateCompanyAsync(CompanyPostDto dto)
        {
            var data = await GetCompanyByIdAsync(dto.Name);
            if (data == null)
            {
                var request = _mapper.Map<Company>(dto);
                await _db.AddAsync(request);
            }
            var response = await GetCompanyAsync();
            return response;
        }

        public async Task<ICollection<CompanyAllGetDo>> GetAllCompanyAsync()
        {
            var data = await _db.Companies.ToListAsync();
            List<CompanyAllGetDo> response = new();
            CompanyAllGetDo request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CompanyAllGetDo>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<CompanyGetDto>> GetCompanyAsync()
        {
            var data = await _db.Companies.Where(c => c.Description != "IsDelete").ToListAsync();
            List<CompanyGetDto> response = new();
            CompanyGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CompanyGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<CompanyGetDto> GetCompanyByIdAsync(int Id)
        {
            var data = await _db.Companies.FirstOrDefaultAsync(c=>c.Description!="IsDelete" && c.Id ==Id);
            var response = _mapper.Map<CompanyGetDto>(data);
            return response;
        }

        public async Task<ICollection<CompanyGetDto>> PutCompanyAsync(CompanyPutDto dto)
        {
            var data = await GetCompanyByIdAsync(dto.Id);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetCompanyAsync();
            return response;
        }

        private async Task<Company> GetCompanyByIdForDeleteAsync(int Id)
        {
            var data = await _db.Companies.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Id == Id);
            return data;
        }
        public async Task<ICollection<CompanyGetDto>> DeleteCompanyAsync(int Id)
        {
            var data = await GetCompanyByIdForDeleteAsync(Id);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetCompanyAsync();
            return response;
        }

        public async Task<ICollection<CompanyAllGetDo>> DeleteCompanyRealAsync(int Id)
        {
            var data = await GetCompanyByIdForDeleteAsync(Id);
            if (data != null)
            {
                _db.Companies.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAllCompanyAsync();
            return response;
        }

        public async Task<ICollection<CompanyAllGetDo>> ReturnCompanyAsync(int Id)
        {
            var data = await GetCompanyByIdForDeleteAsync(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetAllCompanyAsync();
            return response;
        }
    }
}
