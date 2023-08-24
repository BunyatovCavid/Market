using Microsoft.AspNetCore.Mvc;

namespace Market.Dtoes.Post_Dtoes
{
    public class PaperPostDto
    {
        public int CompanyId { get; set; }
        public string Status { get; set; }
        public float? Concession { get; set; }
        public float? Discount { get; set; }

        public int AccountId { get; set; }

    }
}
