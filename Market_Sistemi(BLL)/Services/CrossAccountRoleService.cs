using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Domain.Entities.Cross;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Interfaces;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Market.Services
{
    public class CrossAccountRoleService : ICrossAccountRole
    {
        private readonly IMapper _mapper;
        private readonly MarketDbContext _db;
        private readonly IRole _Role;
        public CrossAccountRoleService(IMapper mapper, MarketDbContext db, IRole role)
        {
            _db = db;
            _mapper = mapper;
            _Role = role;
        }


        private ICollection<CrossGetDto> Get_Back(List<Account> data)
        {
            List<CrossGetDto> response = new();
            CrossGetDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<CrossGetDto>(item);
                foreach (var sub_item in item.Cross_Account_Role)
                {
                    var sub_Request = _mapper.Map<Cross_Account_RoleBackGetDto>(sub_item);
                    request.Cross_Account_RoleBackGetDtoes.Add(sub_Request);
                }
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<CrossGetDto>> GetCrossAsync()
        {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).ToListAsync();
            var response = Get_Back(data);
            return response;
        }


        private CrossGetDto Get_BackById(Account data)
        {
            var response = _mapper.Map<CrossGetDto>(data);
            foreach (var sub_item in data.Cross_Account_Role)
            {
                var sub_Request = _mapper.Map<Cross_Account_RoleBackGetDto>(sub_item);
                response.Cross_Account_RoleBackGetDtoes.Add(sub_Request);
            }
            return response;
        }
        public async Task<CrossGetDto> GetCrossByIdAsync(int Id)
        {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == Id && a.Id > 1);
            var response = Get_BackById(data);
            return response;
        }

        public async Task<CrossGetDto> GetOwnerCrossByIdAsync(int Id)
        {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == Id);
            var response = _mapper.Map<CrossGetDto>(data);
            return response;
        }

        private async Task<Account> GetAccountForPost(int Id)
        {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == Id && a.Id > 1);
            return data;
        }

        public async Task<ICollection<CrossGetDto>> PostCrossAsync(Cross_Account_RoleDto dto)
        {
            var data = await GetAccountForPost(dto.AccountId);
            if (data != null && dto.RoleId > 1 && dto.AccountId > 1)
            {
                data.Cross_Account_Role.Add(new Cross_Account_Role() { AccountId = dto.AccountId, RoleId = dto.RoleId });
                await _db.SaveChangesAsync();
            }
            var response = await GetCrossAsync();
            return response;
        }
        private async Task<Account> GetAccountForOwnerPost(int Id)
        {
            var data = await _db.Accounts.Include(c => c.Cross_Account_Role).FirstOrDefaultAsync(a => a.Id == Id);
            return data;
        }

        public async Task<ICollection<CrossGetDto>> PostOwnerCrossAsync(Cross_Account_RoleDto dto)
        {
            var data = await GetAccountForOwnerPost(dto.AccountId);
            if (data != null)
            {
                data.Cross_Account_Role.Add(new Cross_Account_Role() { AccountId = dto.AccountId, RoleId = dto.RoleId });
                await _db.SaveChangesAsync();
            }
            var response = await GetCrossAsync();
            return response;
        }

        private async Task Back_DeleteCrossAsync(Account data, int RoleId)
        {

            if (data != null && data.Cross_Account_Role.Count > 0)
            {
                foreach (var item in data.Cross_Account_Role)
                {
                    if (item.RoleId == RoleId)
                    {
                        _db.Cross_Account_Role.Remove(item);
                        await _db.SaveChangesAsync();
                    }
                }
            }
        }
        public async Task<CrossGetDto> DeleteCrossAsync(Cross_Account_RoleDto dto)
        {
            CrossGetDto response = new();
            if (dto.AccountId > 1 && dto.RoleId > 1)
            {
                var data = await GetAccountForPost(dto.AccountId);
                await Back_DeleteCrossAsync(data, dto.RoleId);
                response = await GetCrossByIdAsync(dto.AccountId);
            }
            return response;
        }

        public async Task<CrossGetDto> DeleteOwnerCrossAsync(Cross_Account_RoleDto dto)
        {
            var data = await GetAccountForOwnerPost(dto.AccountId);
            await Back_DeleteCrossAsync(data, dto.RoleId);
            var request = await GetAccountForOwnerPost(dto.AccountId);
            var response = _mapper.Map<CrossGetDto>(request);
            return response;
        }


    }
}
