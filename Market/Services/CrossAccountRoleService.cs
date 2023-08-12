using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class CrossAccountRoleService:ICrossAccountRole
    {
        private readonly IMapper _mapper;
        private readonly MarketDbContext _db;

        public CrossAccountRoleService(IMapper mapper, MarketDbContext db)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ICollection<Account>> GetAccountsAsync()
        {
            var data = await _db.Accounts.Include(a=>a.Cross_Account_Role).FirstOrDefaultAsync();
            return (ICollection<Account>)data;
        }
        public async Task<ICollection<Account>> PostAccountRoleAsync(Cross_Account_RoleDto dto)
        {
            var data = new Account()
            {
                Id = dto.AccountId,
                Cross_Account_Role = new HashSet<Cross_Account_Role>() {
                    new() { RoleId = dto.RoleId }
               }
            };
            await _db.AddAsync(data);

 

            var response = GetAccountsAsync();
            await _db.SaveChangesAsync();
            return (ICollection<Account>)response;

        }
        public async Task<Account> DeleteAccountRoleAsync(Cross_Account_RoleDto dto) {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == dto.AccountId);
            Role data2 = new();
            if (data != null)
            {
                foreach (var item in data.Cross_Account_Role)
                {
                    if (item.RoleId == dto.RoleId)
                    {
                        data2 = await _db.Roles.FirstOrDefaultAsync(r => r.Id == dto.RoleId);
                        break;
                    }
                }
                if (data2 != null)
                {
                    data.Cross_Account_Role.Remove(new Cross_Account_Role()
                    {
                        AccountId = dto.AccountId,
                        RoleId = dto.RoleId
                    });
                    await _db.SaveChangesAsync();
                    var response = await _db.Accounts.Include(a => a.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == dto.AccountId);
                    return response;
                }

            }
            return null;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var data = await _db.Accounts.Include(a => a.Cross_Account_Role).FirstOrDefaultAsync(a=>a.Id ==id);
            return data;
        }
    }
}
