using FluentValidation;
using Market.Dtoes.PostDtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class AddAmountPostDtoValidations:AbstractValidator<AddAmountPostDto>
    {
        public AddAmountPostDtoValidations()
        {
            RuleFor(x => x.Amount).NotNull().WithMessage("Amount Cannot Be Null");
            RuleFor(x => x.CheckId).NotNull().WithMessage("CheckId Cannot Be Null");
        }
    }
}
