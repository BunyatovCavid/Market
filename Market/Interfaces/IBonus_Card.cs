using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IBonus_Card
    {
        public Task<ICollection<Bonus_CardGetDto>> GetBonus_CardAsync();



        public Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardAsync(Bonus_CardPostDto dto);

        public Task<ICollection<Bonus_CardGetDto>> PutBonus_CardAsync(Bonus_cardPutDto dto);

        public Task<ICollection<Bonus_CardGetDto>> DeleteBonus_CardAsync(Bonus_cardPutDto dto);

        public Task<ICollection<Bonus_CardGetDto>> CreateBonus_CardReportAsync(Bonus_Card_ReportPostDto dto);

        public Task<Bonus_Card_ReportGetDto> DeleteBonus_Card_ReportAsync(int Barkod, int id);


    }
}
