using Market.Domain.Entities.Cross;
using Microsoft.AspNetCore.Mvc;

namespace Market.Dtoes.Get_Dtoes
{
    public class AccountGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
    }
}
