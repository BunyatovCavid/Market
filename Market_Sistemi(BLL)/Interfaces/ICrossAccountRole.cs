using Market.Domain.Entities;
using Market.Dtoes;
using Market.Dtoes.Get_Dtoes;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;

namespace Market.Interfaces
{
    public interface ICrossAccountRole
    {
        public Task<ICollection<CrossGetDto>> GetCrossAsync();
        public Task<CrossGetDto> GetCrossByIdAsync(int id);
        public Task<CrossGetDto> GetOwnerCrossByIdAsync(int id);
        public Task<ICollection<CrossGetDto>> PostCrossAsync(Cross_Account_RoleDto dto);
        public Task<ICollection<CrossGetDto>> PostOwnerCrossAsync(Cross_Account_RoleDto dto);
        public Task<CrossGetDto> DeleteCrossAsync(Cross_Account_RoleDto dto);
        public Task<CrossGetDto> DeleteOwnerCrossAsync(Cross_Account_RoleDto dto);

    }
}
