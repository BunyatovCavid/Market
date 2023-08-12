using Market.Domain.Entities;
using Market.Dtoes;

namespace Market.Interfaces
{
    public interface ICrossAccountRole
    {
        public Task<ICollection<Account>> GetAccountsAsync();
        public Task<Account> GetAccountByIdAsync(int id);
        public Task<ICollection<Account>> PostAccountRoleAsync(Cross_Account_RoleDto dto);
        public Task<Account> DeleteAccountRoleAsync(Cross_Account_RoleDto dto);

    }
}
