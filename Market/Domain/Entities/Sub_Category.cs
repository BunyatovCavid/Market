using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Sub_Category
    {
        public Sub_Category()
        {
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public bool Discount_Check { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
