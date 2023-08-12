namespace Market.Dtoes.Get_Dtoes
{
    public class ItemFilterDto
    {
        public int Barkod { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Sub_Category { get; set; }
        public int Company { get; set; }
        public DateTime Before_Date { get; set; }
        public DateTime After_Date { get; set; }
        public int Account { get; set; }
    }
}
