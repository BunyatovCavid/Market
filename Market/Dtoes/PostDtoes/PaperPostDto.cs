using Microsoft.AspNetCore.Mvc;

namespace Market.Dtoes.Post_Dtoes
{
    public class PaperPostDto
    {
        public int CompanyId { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public float? Concession { get; set; }
        public float? Discount { get; set; }
        public float Amount { get; set; }
        public float Final_Amount { get; set; }

        public int AccountId { get; set; }

    }
}
