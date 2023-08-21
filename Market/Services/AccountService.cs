using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Market.Services
{
    public class AccountService:IAccount
    {

        private readonly IMapper _mapper;
        private readonly MarketDbContext _db;

        public AccountService(IMapper mapper, MarketDbContext db)
        { 
            _db = db;
            _mapper = mapper;
        }
        public async Task<ICollection<AccountGetDto>> GetAccountAsync()
        {
            var data = await _db.Accounts.Where(a=>a.Description!="IsDelete").ToListAsync();
            List<AccountGetDto> response = new();
            AccountGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<AccountGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<AccountGetDto>> GetAllAccountAsync()
        {
            var data = await _db.Accounts.ToListAsync();
            List<AccountGetDto> response = new();
            AccountGetDto request = new();
            foreach (var item in data)
            {
                _mapper.Map<AccountGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<AccountGetDto> GetAccountByNameAsync(string name)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(r=>r.Name==name);
            var response = _mapper.Map<AccountGetDto>(data);
            return response;
        }

        public async Task<ICollection<AccountGetDto>> CreateAccountAsync(LoginDto dto)
        {
            var check = await GetAccountByNameAsync(dto.Name);
            if (check == null)
            {
                var data = _mapper.Map<Account>(dto);
                await _db.AddAsync(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAccountAsync();
            return response;

        }
        public async Task<ICollection<AccountGetDto>> DeleteAccountAsync(string name)
        {
            var data = await GetAccountByNameAsync(name);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetAccountAsync();
            return response;
        }
        public async Task<ICollection<AccountGetDto>> PutAccountAsync(AccountPutDto dto)
        {
            var data = await GetAccountByNameAsync(dto.Name);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAccountAsync();
            return response;
        }


    }
}
