using Market.Domain.Entities;

namespace Market.Dtoes.Get_Dtoes
{
    public class Bonus_Card_ReportGetDto
    {
        public Bonus_Card_ReportGetDto()
        {
            Bonus_Card_Reports = new HashSet<Bonus_Card_Report>();
        }
        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public ICollection<Bonus_Card_Report> Bonus_Card_Reports { get; set; }
        public string? Description { get; set; }
    }
}
