namespace Market.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Sub_Categories = new HashSet<Sub_Category>();
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public ICollection<Sub_Category> Sub_Categories { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
