using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Included
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
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
        public Paper Paper { get; set; }
        public Item Item { get; set; }


    }
}
