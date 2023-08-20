using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Discount_Card
    {  
        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public string Fin { get; set; }
        public string Phone { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public Check Check { get; set; }
    }
}
