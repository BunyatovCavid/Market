using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Number { get; set; }
        public float Amount { get; set; }
        public int CheckId { get; set; }
        public string? Description { get; set; }
        public Check Check { get; set; }
        public Item Item { get; set; }
    }
}
