using Market.Dtoes;
using Market.Dtoes.Post_Dtoes;

namespace Market.Interfaces
{
    public interface IRole
    {
        public Task<ICollection<RoleDto>> GetRoleAsync();
        public Task<RoleDto> GetRoleByIdAsync(RoleDto dto);
        public Task<ICollection<RoleDto>> PostRoleAsync(RolePostDto dto);
        public Task<ICollection<RoleDto>> PutRoleAsync(RoleDto dto);
        public Task<ICollection<RoleDto>> DeleteRoleAsync(int id);
    }
}
