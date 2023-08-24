using Market.Domain.Entities;

namespace Market.Dtoes.Get_Dtoes
{
    public class Bonus_CardGetDto
    {
        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
