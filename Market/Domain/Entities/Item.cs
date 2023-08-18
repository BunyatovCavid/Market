using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Market.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public int Barkod { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Sub_CategoryId { get; set; }
        [MaxLength(5)]
        public int Number { get; set; }
        public int CompanyId { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }


        public Discount_Card_Report Discount_Card_Report { get; set; } 
        public Category Category { get; set; }
        public Sub_Category Sub_Category { get; set; }
        public Company Company { get; set; }
        public Sale Sale { get; set; }
        public Included Included { get; set; }
        public Account Account { get; set; }
    }
}
