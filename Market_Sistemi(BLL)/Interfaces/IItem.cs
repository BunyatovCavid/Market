using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;
using Market_Sistemi_BLL_.Dtoes.PostDtoes;

namespace Market.Interfaces
{
    public interface IItem
    {
        public  Task<ICollection<Item>> GetItems();
        public Task<ICollection<ItemGetDto>> Delete(ItemFilterDto dto);
        public Task<ICollection<ItemGetDto>> GetItemsByFilter(ItemFilterDto dto);
        public Task<ICollection<ItemGetDto>> CreateItemAsync(ItemPostDto dto);
        public Task<ICollection<ItemGetDto>> PutItemAsync(ItemPutDto dto, ItemPostDto putdto);
    }
}
