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
        public async Task<ICollection<Account>> GetAccountAsync()
        {
            var data = await _db.Accounts.FirstOrDefaultAsync();
            return (ICollection<Account>)data;
        }
        public async Task<RegisterDto> CreateAccountAsync(LoginDto dto)
        {
            var check = await _db.Accounts.FirstOrDefaultAsync(a => a.Name == dto.Name);

            RegisterDto response = _mapper.Map<RegisterDto>(dto);

            if (check == null)
            {
                var data = _mapper.Map<Account>(dto);
                await _db.Accounts.AddAsync(data);
                await _db.SaveChangesAsync();
                response.Discount = $"Welcome {dto.Name}";
            }
            else
            {
                response.Discount = $"Failed";
            }
            return response;

        }
        public async Task<ICollection<Account>> DeleteAccountAsync(int id)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (data != null)
            {
                data.Description = "IsDelete";
                var response = await _db.Accounts.FirstOrDefaultAsync(a => a.Description != "IsDelete");
                return (ICollection<Account>)response;
            }
            data = new Account() { Description = "Empty Id" };
            return (ICollection<Account>)data;
        }
        public async Task<Account> GetAccountAsync(int id)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            return data;
        }
        public async Task<ICollection<Account>> PutAccountAsync(AccountPutDto dto)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(a=>a.Id == dto.Id);
            data = _mapper.Map<Account>(dto);
            await _db.SaveChangesAsync();
            var response = await _db.Accounts.FirstOrDefaultAsync();
            return (ICollection<Account>)response;
        }


    }
}
