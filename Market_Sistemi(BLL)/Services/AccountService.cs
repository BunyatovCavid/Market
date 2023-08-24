using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Market.Services
{
    public class AccountService : IAccount
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
            var data = await _db.Accounts.Where(a => a.Description != "IsDelete").ToListAsync();
            List<AccountGetDto> response = new();
            AccountGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<AccountGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<AccountAllGetDto>> GetAllAccountAsync()
        {
            var data = await _db.Accounts.ToListAsync();
            List<AccountAllGetDto> response = new();
            AccountAllGetDto request = new();
            foreach (var item in data)
            {
               request = _mapper.Map<AccountAllGetDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<AccountGetDto> GetAccountByNameAsync(string name)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(r => r.Name == name);
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
        public async Task<ICollection<AccountGetDto>> PutAccountAsync(AccountPutDto dto)
        {
            var data = await GetAccountByIDForDelete(dto.Id);
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAccountAsync();
            return response;
        }
        private async Task<Account> GetAccountByIDForDelete(int Id)
        {
            var data = await _db.Accounts.FirstOrDefaultAsync(c => c.Id == Id);
            return data;
        }

        public async Task<ICollection<AccountGetDto>> DeleteAccountAsync(int Id)
        {
            var data = await GetAccountByIDForDelete(Id);
            if (data != null)
            {
                data.Description = "IsDelete";
                await _db.SaveChangesAsync();
            }
            var response = await GetAccountAsync();
            return response;
        }
        public async Task<ICollection<AccountAllGetDto>> DeleteAccountRealAsync(int Id)
        {
            var data = await GetAccountByIDForDelete(Id);
            if (data != null)
            {
                _db.Accounts.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetAllAccountAsync();
            return response;
        }


        public async Task<ICollection<AccountAllGetDto>> ReturnAccountAsync(int Id)
        {
            var data = await GetAccountByIDForDelete(Id);
            if (data != null)
            {
                data.Description = "ReturnData";
                await _db.SaveChangesAsync();
            }
            var response = await GetAllAccountAsync();
            return response;
        }
    }
}
