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
    public class Sub_CategoryService : ISub_Category
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public Sub_CategoryService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ICollection<Sub_CategoryAllGetDto>> GetSub_CategoryAllAsync()
        {
            var data = await _db.Sub_Categories.OrderByDescending(s=>s.Date).ToListAsync();
            List<Sub_CategoryAllGetDto> response = new();
            Sub_CategoryAllGetDto request = new();
            foreach (var item in data) 
            {
                request = _mapper.Map<Sub_CategoryAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<Sub_CategoryGetDto>> GetSub_CategoryAsync()
        {
            var data = await _db.Sub_Categories.Where(s => s.Description != "IsDelete").OrderByDescending(s => s.Date).ToListAsync();
            List<Sub_CategoryGetDto> response = new();
            Sub_CategoryGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<Sub_CategoryGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<Sub_CategoryGetDto> GetSub_CategoryByIdAsync(int Id)
        {
            var data = await _db.Sub_Categories.FirstOrDefaultAsync(s=>s.Description!="IsDelete" && s.Id==Id);
            var response = _mapper.Map<Sub_CategoryGetDto>(data);
            return response;
        }
        public async Task<Sub_CategoryGetDto> GetSub_CategoryByCategoryIdAsync(int Id)
        {
            var data = await _db.Sub_Categories.FirstOrDefaultAsync(s => s.CategoryId == Id);
            var response = _mapper.Map<Sub_CategoryGetDto>(data);
            return response;
        }

        private async Task<Sub_Category> GetSub_CategorybByNameForCreate(string Name)
        {
            var data = await _db.Sub_Categories.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Name == Name);
            return data;
        }
        public async Task<ICollection<Sub_CategoryGetDto>> CreateSub_CategoryAsync(Sub_CategoryPostDto dto)
        {
            var check = await GetSub_CategorybByNameForCreate(dto.Name);
            if(check==null)
            {
                Sub_Category request = _mapper.Map<Sub_Category>(dto);
                request.Date = DateTime.Now;
                await _db.Sub_Categories.AddAsync(request);
                await _db.SaveChangesAsync();
            }
            var response = await GetSub_CategoryAsync();
            return response;
        }

        private async Task<Sub_Category> GetSub_CategoryByIdForPutAsync(int Id)
        {
            var data = await _db.Sub_Categories.FirstOrDefaultAsync(s => s.Description != "IsDelete" && s.Id == Id);
            return data;
        }
        public async Task<ICollection<Sub_CategoryGetDto>> PutSub_CategoryAsync(Sub_CategoryPutDto dto)
        {
            var data = await GetSub_CategoryByIdForPutAsync(dto.Id);
            if(data!=null)
            {
                _mapper.Map(dto, data);
                data.Date = DateTime.Now;
                await _db.SaveChangesAsync();
            }
            var response = await GetSub_CategoryAsync();
            return response;
        }


        private async Task<Sub_Category> GetCategoryByIdForDelete(int Id)
        {
            var data = await _db.Sub_Categories.FirstOrDefaultAsync(c => c.Id == Id);
            return data;
        }
        public async Task<ICollection<Sub_CategoryGetDto>> DeleteSub_CategoryAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if(data!=null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetSub_CategoryAsync();
            return response;
        }
        public async Task<ICollection<Sub_CategoryAllGetDto>> DeleteSub_CategoryRealAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if(data!=null)
            {
                _db.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetSub_CategoryAllAsync();
            return response;
        }
        public async Task<ICollection<Sub_CategoryAllGetDto>> ReturnSub_CategoryRealAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if(data!=null)
            {
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetSub_CategoryAllAsync();
            return response;
        }

  
    }
}
