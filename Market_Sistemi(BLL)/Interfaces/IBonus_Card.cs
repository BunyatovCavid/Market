using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Market_Sistemi_BLL_.Interfaces;

namespace Market.Interfaces
{
    public interface IBonus_Card
    {
        public Task<ICollection<Bonus_CardGetDto>> GetBonus_CardAsync();
        public Task<ICollection<Bonus_CardAllGetDto>> GetAllBonus_CardAsync();



        public Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardAsync(Bonus_CardPostDto dto);

        public Task<ICollection<Bonus_CardGetDto>> PutBonus_CardAsync(Bonus_cardPutDto dto);

        public Task<ICollection<Bonus_CardGetDto>> DeleteBonus_CardAsync(int Id);
        public Task<ICollection<Bonus_CardAllGetDto>> DeleteBonus_CardRealAsync(int Id);
        public Task<ICollection<Bonus_CardAllGetDto>> ReturnBonus_CardAsync(int Id);

        public Task<ICollection<Bonus_CardAllGetDto>> GetAllBonus_CardReportAsync();
        public Task<Bonus_CardGetDto> CreateBonus_CardReportAsync(Bonus_Card_ReportPostDto dto);

        public Task<ICollection<Bonus_CardGetDto>> DeleteBonus_Card_ReportAsync(Bonus_Card_ReportDeleteDto dto);
        public Task<Bonus_CardAllGetDto> DeleteBonus_Card_ReportRealAsync(int Id, int Barkod);
        public Task<Bonus_CardAllGetDto> ReturnBonus_Card_ReportAsync(int Barkod, int Id);


    }
}
