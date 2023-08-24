using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Company
    {
        public Company()
        {
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
