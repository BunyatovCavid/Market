using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface ICash
    {
        public Task<ICollection<CashGetDto>> GetCashAsync();

        public Task<ICollection<CashGetDto>> CreateCashAsync(CashPostDto dto);

        public Task<ICollection<CashGetDto>> PutCashAsync(CashPutDto dto);

        public Task<ICollection<CashGetDto>> DeleteCashAsync(CashPutDto dto);
    }
}
