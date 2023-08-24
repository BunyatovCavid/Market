using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;

namespace Market.Interfaces
{
    public interface IIncluded
    {

        public Task<ICollection<IncludedGetDto>> GetPaperInculededsByNumber(int Number);

        public Task<IncludedGetDto> GetInculededById(int Id);

        public Task<ICollection<IncludedGetDto>> AddIncluded(IncludedGetDto dto);

        public Task<ICollection<IncludedGetDto>> PutIncluded(IncludedGetDto dto);

        public Task<ICollection<IncludedGetDto>> DeleteIncluded(int Id);

    }
}
