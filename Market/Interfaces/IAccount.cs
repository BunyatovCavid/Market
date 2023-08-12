using Market.Domain.Entities.Cross;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IAccount
    {
        public Task<RegisterDto> CreateAccountAsync(LoginDto dto);
        public  Task<ICollection<Account>> DeleteAccountAsync(int id);
        public  Task<Account> GetAccountAsync(int id);
        public  Task<ICollection<Account>> GetAccountAsync();
        public Task<ICollection<Account>> PutAccountAsync(AccountPutDto dto);
    }
}
