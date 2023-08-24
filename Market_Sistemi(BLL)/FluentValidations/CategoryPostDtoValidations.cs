using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class CategoryPostDtoValidations:AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
        }
    }
}
