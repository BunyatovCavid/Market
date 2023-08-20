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
        public int Number { get; set; }
        public string? Description { get; set; }
        public ICollection<Check>  Checks{ get; set; }
    }
}
