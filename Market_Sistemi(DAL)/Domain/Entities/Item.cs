
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Market.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Sub_CategoryId { get; set; }
        public int Number { get; set; }
        public int CompanyId { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Category Category { get; set; }
        public Sub_Category Sub_Category { get; set; }
        public Company Company { get; set; }
        public Sale Sale { get; set; }
        public Included Included { get; set; }
        public Account Account { get; set; }
    }
}
