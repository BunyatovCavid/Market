using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class Sub_CategoryPutDtoValidations:AbstractValidator<Sub_CategoryPutDto>
    {
        public Sub_CategoryPutDtoValidations()
        {
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
            RuleFor(x => x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x => x.Discount_Check).NotNull().WithMessage("Discount Check Cannot Be Null");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId Cannot Be Null");
            RuleFor(x => x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
        }
    }
}
