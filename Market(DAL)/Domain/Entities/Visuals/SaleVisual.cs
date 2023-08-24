namespace Market.Domain.Entities.Visuals
{
    public class SaleVisual
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Number { get; set; }
        public float? Amount { get; set; }
        public int CheckId { get; set; }
        public string? Description { get; set; }
        public CheckVisual Check { get; set; }
        public Item Item { get; set; }
    }
}
