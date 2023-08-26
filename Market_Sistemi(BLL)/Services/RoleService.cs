using AutoMapper;
using Market.Domain;
using Market.Domain.Entities;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Market.Services
{
    public class RoleService : IRole
    {
        private MarketDbContext _db { get; set; }
        private IMapper _mapper { get; set; }


        public RoleService(MarketDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private ICollection<RoleDto> Get_Back(List<Role> data)
        {
            List<RoleDto> response = new();
            RoleDto request = new();
            foreach (var item in data)
            {
                request = _mapper.Map<RoleDto>(item);
                response.Add(request);
            }
            return response;
        }
        public async Task<ICollection<RoleDto>> GetRoleAsync()
        {
            var data = await _db.Roles.ToListAsync();
            var response = Get_Back(data);
            return response;
        }

        public async Task<RoleDto> GetRoleByIdAsync(int Id)
        {
            var data = await _db.Roles.FirstOrDefaultAsync(r => r.Id == Id);
            var response = _mapper.Map<RoleDto>(data);
            return response;
        }
        private async Task<Role> GetRoleByIdAsync(RoleDto dto)
        {
            var data = await _db.Roles.FirstOrDefaultAsync(r => dto.Id != 0 ? r.Id == dto.Id : r.Name == dto.Name);
            return data;
        }

        public async Task<ICollection<RoleDto>> PostRoleAsync(RolePostDto dto)
        {
            var check = await GetRoleByIdAsync(new RoleDto { Name = dto.Name });
            if (check == null)
            {
                var data = _mapper.Map<Role>(dto);
                await _db.AddAsync(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetRoleAsync();
            return response;
        }

        public async Task<ICollection<RoleDto>> PutRoleAsync(RoleDto dto)
        {
            var data = await GetRoleByIdAsync(new RoleDto { Id = dto.Id });
            if (data != null)
            {
                _mapper.Map(dto, data);
                await _db.SaveChangesAsync();
            }
            var response = await GetRoleAsync();
            return response;
        }

        public async Task<ICollection<RoleDto>> DeleteRoleAsync(int id)
        {
            var data = await GetRoleByIdAsync(new RoleDto { Id = id });
            if (data != null)
            {
                _db.Roles.Remove(data);
                await _db.SaveChangesAsync();
            }
            var response = await GetRoleAsync();
            return response;
        }

    }
}
