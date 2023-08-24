namespace Market.Dtoes.PutDto
{
    public class PaperPutDto
    {
        public int Paper_Number { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public float? Concession { get; set; }
        public float? Discount { get; set; }
        public float Amount { get; set; }
        public float Final_Amount { get; set; }

        public int AccountId { get; set; }
    }
}
