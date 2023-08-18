using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
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
        public async Task<ICollection<AccountGetDto>> GetAccountsAsync()
        {
            var data = await _db.Accounts.Include(a=>a.Cross_Account_Role).ToListAsync();
            ICollection<AccountGetDto> response = _mapper.Map<ICollection<AccountGetDto>>(data);
            return response;
        }
        public async Task<ICollection<AccountGetDto>> PostAccountRoleAsync(Cross_Account_RoleDto dto)
        {
            var check = await GetAccountByIdAsync(dto.AccountId);
            ICollection<AccountGetDto> response = null;
            if (check != null)
            {
                var data = new Account()
                {
                     Description = "IsCreate",
                    Cross_Account_Role = new HashSet<Cross_Account_Role>() {
                    new() { RoleId = dto.RoleId }
               }
                };
                await _db.AddAsync(data);

                await _db.SaveChangesAsync();

                 response = await GetAccountsAsync();
            }
            return response;

        }
        public async Task<AccountGetDto> DeleteAccountRoleAsync(Cross_Account_RoleDto dto) {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == dto.AccountId);
            AccountGetDto response = null;
            if (data != null)
            {
                Role data2 = new();
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
                    var data_final = await _db.Accounts.Include(a => a.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == dto.AccountId);
                     response = _mapper.Map<AccountGetDto>(data_final);
                }
            }
            return response;
        }
        public async Task<AccountGetDto> GetAccountByIdAsync(int id)
        {
            var data = await _db.Accounts.Include(a => a.Cross_Account_Role).FirstOrDefaultAsync(a=>a.Id ==id);
            AccountGetDto response = _mapper.Map<AccountGetDto>(data);
            return response;
        }
    }
}
