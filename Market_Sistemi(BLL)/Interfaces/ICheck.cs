using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.GetDtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PostDtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface ICheck
    {

        public Task<ICollection<CheckGetDto>> GetChecksAsync();
        public Task<ICollection<CheckAllGetDto>> GetAllChecksAsync();
        public Task<CheckGetDto> GetCheckbyIdAsync(int Id);

        public Task<ICollection<CheckGetDto>> CreateCheckAsync(CheckPostDto dto);
        public Task<CheckGetDto> UseBonus_CardAsync(UseCardPostDto dto);
        public Task<CheckGetDto> UseBonusAsync(UseCardPostDto dto);
        public Task<CheckGetDto> UseDiscount_CardAsync(UseCardPostDto dto);
        public Task<CheckGetDto> AddAmountInCheckAsync(AddAmountPostDto dto);
        public Task<CheckGetDto> SaveCheckByIncluded(int CheckId);


        public Task<ICollection<CheckGetDto>> DeleteCheckAsync(int Number);
        public Task<ICollection<CheckAllGetDto>> DeleteCheckRealAsync(int Number);
        public Task<ICollection<CheckAllGetDto>> ReturnCheckAsync(int Number);



    }
}
