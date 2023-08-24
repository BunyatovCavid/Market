using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.Dtoes.PostDtoes
{
    public class ItemPostDto
    {
        public int Barkod { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public int CategoryId { get; set; }
        public int Sub_CategoryId { get; set; }
        public int Number { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
    }
}
