namespace Market.Domain.Entities
{
    public class Bonus_Card_Report
    {
        public int Id { get; set; }
        public int Bonus_CardId { get; set; }
        public int Amount { get; set; }

        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public Bonus_Card Bonus_Card { get; set; }
    }
}
