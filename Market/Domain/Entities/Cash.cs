using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Cash
    {
        public Cash()
        {
            Checks = new HashSet<Check>();
        }
        public int Id { get; set; }
        [MaxLength(2)]
        public int Number { get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public ICollection<Check>  Checks{ get; set; }
    }
}
