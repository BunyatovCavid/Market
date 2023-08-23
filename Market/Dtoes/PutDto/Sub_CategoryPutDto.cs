namespace Market.Dtoes.PutDto
{
    public class Sub_CategoryPutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool Discount_Check { get; set; }
    }
}
