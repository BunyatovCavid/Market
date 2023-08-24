using FluentValidation;
using Market_Sistemi_BLL_.Dtoes.PostDtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class ItemPostDtoValidations:AbstractValidator<ItemPostDto>
    {
        public ItemPostDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.Amount).NotNull().WithMessage("Amount Cannot Be Null");
            RuleFor(x=>x.Barkod).NotNull().WithMessage("Barkod Cannot Be Null");
            RuleFor(x=>x.CategoryId).NotNull().WithMessage("CategoryId Cannot Be Null");
            RuleFor(x=>x.CompanyId).NotNull().WithMessage("CompanyId Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Number).NotNull().WithMessage("Number Cannot Be Null");
            RuleFor(x=>x.Sub_CategoryId).NotNull().WithMessage("Sub_Category Cannot Be Null");
        }
    }
}
