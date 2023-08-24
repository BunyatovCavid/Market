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
    public class CategoryService : ICategory
    {
        private IMapper _mapper;
        private MarketDbContext _db;
        public CategoryService(IMapper mapper, MarketDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }


        public async Task<ICollection<CategoryAllGetDto>> GetCategoryAllAsync()
        {
            var data = await _db.Categories.ToListAsync();
            List<CategoryAllGetDto> response = new();
            CategoryAllGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CategoryAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<CategoryBySub_CategoryGetDto>> GetCategoryAllBySubCategoryAsync()
        {
            var data = await _db.Categories.Include(c => c.Sub_Categories).ToListAsync();
            List<CategoryBySub_CategoryGetDto> response = new();
            CategoryBySub_CategoryGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CategoryBySub_CategoryGetDto>(item);
                foreach (var sub_item in item.Sub_Categories)
                {
                    request.Sub_Categories.Add(sub_item);
                }
                response.Add(request);
            }
            return response;
        }

        public async Task<ICollection<CategoryGetDto>> GetCategoryAsync()
        {
            var data = await _db.Categories.Where(c => c.Description != "IsDelete").ToListAsync();
            List<CategoryGetDto> response = new();
            CategoryGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CategoryGetDto>(item);
                response.Add(request);
            }
            return response;
        }

        public async Task<CategoryGetDto> GetCategoryByIdAsync(int Id)
        {
            var data = await _db.Categories.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Id == Id);
            CategoryGetDto response = _mapper.Map<CategoryGetDto>(data);
            return response;
        }

        public async Task<ICollection<CategoryBySub_CategoryGetDto>> GetCategoryBySubCategoryAsync()
        {
            var data = await _db.Categories.Include(c => c.Sub_Categories).Where(c => c.Description != "IsDelete").OrderByDescending(c => c.Date).ToListAsync();
            List<CategoryBySub_CategoryGetDto> response = new();
            CategoryBySub_CategoryGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CategoryBySub_CategoryGetDto>(item);
                foreach (var sub_item in item.Sub_Categories)
                {
                    if (sub_item.Description == "IsDelete")
                        request.Sub_Categories.Remove(sub_item);
                }
                response.Add(request);
            }
            return response;
        }

        public async Task<CategoryBySub_CategoryGetDto> GetCategoryBySubCategoryByIdAsync(int Id)
        {
            var data = await _db.Categories.Include(c => c.Sub_Categories).FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Id == Id);
            CategoryBySub_CategoryGetDto response = new();
            if (data != null)
            {
               response= _mapper.Map<CategoryBySub_CategoryGetDto>(data);
                foreach (var item in data.Sub_Categories)
                {
                    if (item.Description == "IsDelete")
                        response.Sub_Categories.Remove(item);
                }
            }
            return response;
        }


        private async Task<Category> GetCategoryByNameForCreateAsync(string Name)
        {
            var data = await _db.Categories.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Name == Name);
            return data;
        }
        public async Task<ICollection<CategoryGetDto>> CreateCategoryAsync(CategoryPostDto dto)
        {
            var check = await GetCategoryByNameForCreateAsync(dto.Name);
            if(check==null)
            {
                Category request = _mapper.Map<Category>(dto);
                request.Date = DateTime.Now;
                await _db.Categories.AddAsync(request);
                await _db.SaveChangesAsync();
            }
            var response = await GetCategoryAsync();
            return response;
        }


        private async Task<Category> GetCategoryByIdForPutAsync(int Id)
        {
            var data = await _db.Categories.FirstOrDefaultAsync(c => c.Description != "IsDelete" && c.Id == Id);
            return data;

        }
        public async Task<ICollection<CategoryGetDto>> PutCategoryAsync(CategoryPutDto dto)
        {
            var check = await GetCategoryByIdForPutAsync(dto.Id);
            if(check!=null)
            {
                _mapper.Map(dto, check);
                check.Date = DateTime.Now;
                await _db.SaveChangesAsync();
            }
            var response = await GetCategoryAsync();
            return response;
        }


        private async Task<Category> GetCategoryByIdForDelete(int Id)
        {
            var data = await _db.Categories.Include(c=>c.Sub_Categories).FirstOrDefaultAsync(c=>c.Id==Id);
            return data;
        }
        public async Task<ICollection<CategoryGetDto>> DeleteCategoryAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if(data!=null)
            {
                data.Description = "IsDelete";
                foreach (var item in data.Sub_Categories)
                {
                    item.Description = "IsDelete";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetCategoryAsync();
            return response;
        }

        public async Task<ICollection<CategoryAllGetDto>> DeleteCategoryRealAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if(data!=null)
            {
                _db.Categories.Remove(data);
                foreach (var item in data.Sub_Categories)
                {
                    _db.Sub_Categories.Remove(item);
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetCategoryAllAsync();
            return response;
        }

        public async Task<ICollection<CategoryAllGetDto>> ReturnCategoryAsync(int Id)
        {
            var data = await GetCategoryByIdForDelete(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                foreach (var item in data.Sub_Categories)
                {
                    item.Description = "ReturnData";
                }
                await _db.SaveChangesAsync();
            }
            var response = await GetCategoryAllAsync();
            return response;
        }
    }
}
