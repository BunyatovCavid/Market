using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;

namespace Market.Interfaces
{
    public interface ICheck
    {

        public Task<ICollection<CheckGetDto>> GetChecks();
        public Task<ICollection<CheckGetDto>> GetAllChecks();
        public Task<CheckGetDto> GetCheckbyNumber(int Id);
        public Task<CheckGetDto> CreateCheck(CheckPostDto dto);
        public Task<ICollection<CheckGetDto>> PutCheck(CheckPostDto dto);
        public Task<ICollection<CheckGetDto>> DeleteCheck(int Number);
        public Task<ICollection<CheckGetDto>> SaveCheckByIncluded();


    }
}
