using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.Post_Dtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.GetDtoes;
using Microsoft.AspNetCore.Mvc;

namespace Market.Interfaces
{
    public interface IDiscount_Card
    {
        public Task<ICollection<Discount_CardGetDto>> GetDiscount_CardAsync();
        public Task<ICollection<Discount_CardAllGetDto>> GetAllDiscount_CardAsync();

        public Task<ICollection<Discount_CardGetDto>> CreateDiscount_CardAsync(Discount_CardPostDto dto);

        public Task<ICollection<Discount_CardGetDto>> PutDiscount_CardAsync(Discount_CardPutDto dto);

        public Task<ICollection<Discount_CardGetDto>> DeleteDiscount_CardAsync(int Id);
        public Task<ICollection<Discount_CardAllGetDto>> DeleteDiscount_CardRealAsync(int Id); 
        public Task<ICollection<Discount_CardAllGetDto>> ReturnDiscount_CardAsync(int Id);
    }
}
