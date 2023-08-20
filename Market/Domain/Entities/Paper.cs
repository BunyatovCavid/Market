using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Paper
    {
        public Paper()
        {
            Includeds = new HashSet<Included>();
        }
        public int Id { get; set; }
        public int Paper_Number { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public float? Concession { get; set; }
        public float? Discount { get; set; }
        public float Amount { get; set; }
        public float Final_Amount { get; set; }
        public int Inclusive { get; set; }
        public int Correction { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<Included> Includeds { get; set; }

    }
}
