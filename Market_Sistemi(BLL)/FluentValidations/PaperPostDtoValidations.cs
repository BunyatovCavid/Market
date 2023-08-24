using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class PaperPostDtoValidations:AbstractValidator<PaperPostDto>
    {
        public PaperPostDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.CompanyId).NotNull().WithMessage("CompanyId Cannot Be Null");
            RuleFor(x=>x.Status).NotNull().WithMessage("Status Cannot Be Null");
        }
    }
}
