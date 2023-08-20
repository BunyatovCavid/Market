using AutoMapper.Configuration.Annotations;
using Market.Domain.Entities.Cross;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Market.Domain.Entities
{
    public class Account
    {
        public Account()
        {
            Cross_Account_Role = new HashSet<Cross_Account_Role>();
            Bonus_Cards = new HashSet<Bonus_Card>();
            Bonus_Card_Reports = new HashSet<Bonus_Card_Report>();
            Categorys = new HashSet<Category>();
            Checks = new HashSet<Check>();
            Companies = new HashSet<Company>();
            Company_Reports = new HashSet<Company_Report>();
            Discount_Cards = new HashSet<Discount_Card>();
            Papers = new HashSet<Paper>();
            Sub_Categories = new HashSet<Sub_Category>();
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public string? Description { get; set; }

        public ICollection<Cross_Account_Role> Cross_Account_Role { get; set; }
        public ICollection<Bonus_Card> Bonus_Cards { get; set; }
        public ICollection<Bonus_Card_Report> Bonus_Card_Reports { get; set; }
        public ICollection<Category> Categorys { get; set; }
        public ICollection<Check> Checks { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Company_Report> Company_Reports { get; set; }
        public ICollection<Discount_Card> Discount_Cards { get; set; }
        public ICollection<Paper> Papers { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Sub_Category> Sub_Categories { get; set; }
    }
}
