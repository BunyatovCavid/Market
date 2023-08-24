using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IItem
    {

        public Task<ICollection<ItemGetDto>> Delete(ItemFilterDto dto);
        public Task<ICollection<ItemGetDto>> GetItemsByFilter(ItemFilterDto dto);
        public Task<ICollection<ItemGetDto>> CreateItemAsync(ItemGetDto dto);
        public Task<ICollection<ItemGetDto>> Put(ItemPutDto dto, ItemGetDto putdto);
    }
}
