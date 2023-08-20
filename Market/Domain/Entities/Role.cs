using Market.Domain.Entities.Cross;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Cross_Account_Role = new HashSet<Cross_Account_Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cross_Account_Role> Cross_Account_Role { get; set; }
    }
}
