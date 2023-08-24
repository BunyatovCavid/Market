using Market.Domain.Entities.Cross;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;

namespace Market.Interfaces
{
    public interface IAccount
    {
        public Task<ICollection<AccountGetDto>> GetAccountAsync();
        public Task<ICollection<AccountAllGetDto>> GetAllAccountAsync();
        public Task<AccountGetDto> GetAccountByNameAsync(string name);
            
        public Task<ICollection<AccountGetDto>> CreateAccountAsync(LoginDto dto);
        public Task<ICollection<AccountGetDto>> PutAccountAsync(AccountPutDto dto);
        public Task<ICollection<AccountGetDto>> DeleteAccountAsync(int Id);
        public Task<ICollection<AccountAllGetDto>> DeleteAccountRealAsync(int Id);

        public Task<ICollection<AccountAllGetDto>> ReturnAccountAsync(int Id);


    }
}
