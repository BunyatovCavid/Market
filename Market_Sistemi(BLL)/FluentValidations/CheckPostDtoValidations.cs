using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class CheckPostDtoValidations:AbstractValidator<CheckPostDto>
    {
        public CheckPostDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.CashId).NotNull().WithMessage("CashId Cannot Be Null");
        }
    }
}
