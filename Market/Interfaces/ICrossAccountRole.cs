using Market.Domain.Entities;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;

namespace Market.Interfaces
{
    public interface ICrossAccountRole
    {
        public Task<ICollection<AccountGetDto>> GetAccountsAsync();
        public Task<AccountGetDto> GetAccountByIdAsync(int id);
        public Task<ICollection<AccountGetDto>> PostAccountRoleAsync(Cross_Account_RoleDto dto);
        public Task<AccountGetDto> DeleteAccountRoleAsync(Cross_Account_RoleDto dto);

    }
}
