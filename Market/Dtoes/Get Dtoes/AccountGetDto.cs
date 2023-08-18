using Market.Domain.Entities.Cross;
using Microsoft.AspNetCore.Mvc;

namespace Market.Dtoes.Get_Dtoes
{
    public class AccountGetDto
    {
        public AccountGetDto()
        {
            Cross_Account_Role = new HashSet<Cross_Account_Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public string Description { get; set; }
        public ICollection<Cross_Account_Role> Cross_Account_Role { get; set; }
    }
}
