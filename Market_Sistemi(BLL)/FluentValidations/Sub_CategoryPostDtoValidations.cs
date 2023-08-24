using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class Sub_CategoryPostDtoValidations : AbstractValidator<Sub_CategoryPostDto>
    {
        public Sub_CategoryPostDtoValidations()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Discount_Check).NotNull().WithMessage("Discount Check Cannot Be Null");
            RuleFor(x=>x.CategoryId).NotNull().WithMessage("CategoryId Cannot Be Null");
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
        }
    }
}
