namespace Market.Dtoes.GetDtoes
{
    public class CheckAllGetDto
    {
        public int Id { get; set; }
        public int CheckNumber { get; set; }
        public int? Bonus_CardId { get; set; }
        public int? Discount_CardId { get; set; }
        public float Amount { get; set; }
        public float? Add_Amount { get; set; }
        public float? Out_Amount { get; set; }
        public int? Bonus_Amount { get; set; }
        public float? Final_Amount { get; set; }
        public int CashId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

    }
}
