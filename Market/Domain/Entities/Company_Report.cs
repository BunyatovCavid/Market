using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Entities
{
    public class Company_Report
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public float First_Debt { get; set; }
        public float Our_Debt { get; set; }
        public float  Us_Debt { get; set; }
        public float Final_Debt{ get; set; }
        [MaxLength(12)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public Company Company { get; set; }

    }
}
