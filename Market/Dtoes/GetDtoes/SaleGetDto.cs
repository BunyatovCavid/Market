namespace Market.Dtoes.Get_Dtoes
{
    public class SaleGetDto
    {
        public int Id { get; set; }
        public int ItemBarkod { get; set; }
        public string ItemName { get; set; }
        public int Number { get; set; }
        public float Amount { get; set; }
        public int CheckId { get; set; }
        public string? Description { get; set; }
    }
}
