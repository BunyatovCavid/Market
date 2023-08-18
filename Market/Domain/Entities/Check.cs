using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Check
    {
        public Check()
        {
            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public int Bonus_CardId { get; set; }
        public int Discount_CardId { get; set; }
        public float Amount { get; set; }
        public float Add_Amount { get; set; }
        public float Out_Amount { get; set; }
        public int Bonus_Amount { get; set; }
        public float Final_Amount { get; set; }
        public int CashId { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }


        public ICollection<Sale> Sales { get; set; }
        public Bonus_Card Bonus_Card { get; set; }
        public Discount_Card Discount_Card { get; set; }
        public Account Account { get; set; }
        public Cash Cash { get; set; }
    }
}
