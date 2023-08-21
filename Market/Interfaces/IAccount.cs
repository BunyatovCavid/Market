using Market.Domain.Entities.Cross;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IAccount
    {
        public Task<ICollection<AccountGetDto>> GetAccountAsync();
        public Task<ICollection<AccountGetDto>> GetAllAccountAsync();
        public Task<AccountGetDto> GetAccountByNameAsync(string name);
            
        public Task<ICollection<AccountGetDto>> CreateAccountAsync(LoginDto dto);
        public Task<ICollection<AccountGetDto>> DeleteAccountAsync(string name);
        public Task<ICollection<AccountGetDto>> PutAccountAsync(AccountPutDto dto);


    }
}
