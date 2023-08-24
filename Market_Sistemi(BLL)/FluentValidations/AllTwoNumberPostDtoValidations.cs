using FluentValidation;
using Market_Sistemi_BLL_.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class AllTwoNumberPostDtoValidations:AbstractValidator<AllTwoNumberPostDto>
    {
        public AllTwoNumberPostDtoValidations()
        {
            RuleFor(x => x.Number1).NotNull().WithMessage("Number1 Cannot Be Null");
            RuleFor(x => x.Number2).NotNull().WithMessage("Number2 Cannot Be Null");
        }
    }
}
