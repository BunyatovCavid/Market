using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface ICategory
    {
        public Task<ICollection<CategoryGetDto>> GetCategoryAsync();
        public Task<ICollection<CategoryAllGetDto>> GetCategoryAllAsync();
        public Task<CategoryGetDto> GetCategoryByIdAsync(int id);

        public Task<ICollection<CategoryBySub_CategoryGetDto>> GetCategoryBySubCategoryAsync();
        public Task<ICollection<CategoryBySub_CategoryGetDto>> GetCategoryAllBySubCategoryAsync();
        public Task<CategoryBySub_CategoryGetDto> GetCategoryBySubCategoryByIdAsync(int id);


        public Task<ICollection<CategoryGetDto>> CreateCategoryAsync(CategoryPostDto dto);

        public Task<ICollection<CategoryGetDto>> PutCategoryAsync(CategoryPutDto dto);

        public Task<ICollection<CategoryGetDto>> DeleteCategoryAsync(int id);
        public Task<ICollection<CategoryAllGetDto>> DeleteCategoryRealAsync(int id);

        public Task<ICollection<CategoryAllGetDto>> ReturnCategoryAsync(int Id);
    }
}
