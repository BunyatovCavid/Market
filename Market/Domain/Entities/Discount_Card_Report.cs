using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Discount_Card_Report
    {
        public int Id { get; set; }
        public int Discount_CardId { get; set; }
        public int ItemId { get; set; }
        public int Report { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public Item Item { get; set; }

        public Discount_Card Discount_Card { get; set; }
    }
}
