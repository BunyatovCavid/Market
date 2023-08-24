namespace Market.Dtoes.Get_Dtoes
{
    public class ItemFilterDto
    {
        public int? Barkod { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public int? Sub_CategoryId { get; set; }
        public int CompanyId { get; set; }
        public DateTime? Before_Date { get; set; }
        public DateTime? After_Date { get; set; }
        public int? AccountId { get; set; }
    }
}
