namespace Market.Dtoes.Get_Dtoes
{
    public class ItemGetDto
    {
        public int Barkod { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public int CategoryId { get; set; }
        public int Sub_CategoryId { get; set; }
        public int Number { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
    }
}
