namespace Market.Dtoes.Get_Dtoes
{
    public class IncludedGetDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Number { get; set; }
        public float Buy_Price { get; set; }
        public float Sale_Percentage { get; set; }
        public float Sale_Price { get; set; }
        public float? Concession { get; set; }
        public float? Discount { get; set; }
        public float? Discount_Percentage { get; set; }
        public float Buy_Amount { get; set; }
        public float Sale_Amount { get; set; }
        public float Final { get; set; }
        public int Print_Number { get; set; }
        public string Description { get; set; }
        public int PaperId { get; set; }
    }
}
