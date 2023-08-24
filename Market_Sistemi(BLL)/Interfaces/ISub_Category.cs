using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface ISub_Category
    {
        public Task<ICollection<Sub_CategoryGetDto>> GetSub_CategoryAsync();
        public Task<ICollection<Sub_CategoryAllGetDto>> GetSub_CategoryAllAsync();
        public Task<Sub_CategoryGetDto> GetSub_CategoryByIdAsync(int Id);
        public Task<Sub_CategoryGetDto> GetSub_CategoryByCategoryIdAsync(int Id);
        public Task<ICollection<Sub_CategoryGetDto>> CreateSub_CategoryAsync(Sub_CategoryPostDto dto);
        public Task<ICollection<Sub_CategoryGetDto>> PutSub_CategoryAsync(Sub_CategoryPutDto dto);
        public Task<ICollection<Sub_CategoryGetDto>> DeleteSub_CategoryAsync(int Id);
        public Task<ICollection<Sub_CategoryAllGetDto>> DeleteSub_CategoryRealAsync(int Id);
        public Task<ICollection<Sub_CategoryAllGetDto>> ReturnSub_CategoryRealAsync(int Id);
    }
}
