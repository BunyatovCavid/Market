using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Discount_Card
    {
        public Discount_Card()
        {
            Discount_Card_Reports = new HashSet<Discount_Card_Report>();
        }
        public int Id { get; set; }
        [MaxLength(15)]
        public int Barkod { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Fin { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public Check Check { get; set; }

        public ICollection<Discount_Card_Report> Discount_Card_Reports { get; set; }
    }
}
