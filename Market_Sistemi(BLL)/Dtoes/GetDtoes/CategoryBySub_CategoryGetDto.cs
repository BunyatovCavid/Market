using Market.Domain.Entities;
using System.Collections.Generic;

namespace Market.Dtoes.Get_Dtoes
{
    public class CategoryBySub_CategoryGetDto
    {
        public CategoryBySub_CategoryGetDto()
        {
            Sub_Categories = new HashSet<Sub_Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sub_Category> Sub_Categories { get; set; }
    }
}
