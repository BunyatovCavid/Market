using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Dtoes.Get_Dtoes;
using Market.Dtoes.PutDto;

namespace Market.Interfaces
{
    public interface IItem
    {
        public Task<ICollection<Item>> GetAllMal(ItemFilterDto dto);
        public Task<ICollection<Category>> GetKategori(CategoryDto dto);
        public Task<ICollection<Sub_Category>> GetSub_Category(Category dto);
        public Task<ICollection<Item>> Post(ItemGetDto dto);
        public Task<Item> Put(ItemPutDto dto,ItemGetDto putdto);
        public Task<ICollection<Item>> Delete(ItemPutDto dto);


    }
}
