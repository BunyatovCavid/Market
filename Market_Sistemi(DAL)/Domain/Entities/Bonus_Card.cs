
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Bonus_Card
    {
        public Bonus_Card()
        {
            Bonus_Card_Report = new HashSet<Bonus_Card_Report>();
        }
        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Bonus { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public Check Check { get; set; }
        public ICollection<Bonus_Card_Report> Bonus_Card_Report { get; set; }
    }
}
