using Market.Domain.Entities.Cross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.Dtoes.GetDtoes
{
    public class CrossGetDto
    {
        public CrossGetDto()
        {
            Cross_Account_Roles = new HashSet<Cross_Account_Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Cross_Account_Role> Cross_Account_Roles { get; set; }
    }
}
