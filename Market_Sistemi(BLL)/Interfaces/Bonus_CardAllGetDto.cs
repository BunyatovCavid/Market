using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.Interfaces
{
    public class Bonus_CardAllGetDto
    {

        public int Id { get; set; }
        public int Barkod { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public int AccountId { get; set; }
    }
}
