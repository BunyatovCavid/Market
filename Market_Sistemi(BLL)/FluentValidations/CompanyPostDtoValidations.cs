using FluentValidation;
using Market.Dtoes.PostDtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class CompanyPostDtoValidations:AbstractValidator<CompanyPostDto>
    {
        public CompanyPostDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
        }
    }
}
