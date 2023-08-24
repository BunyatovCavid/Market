using FluentValidation;
using Market.Dtoes.Get_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class IncludedGetDtoValidations:AbstractValidator<IncludedGetDto>
    {
        public IncludedGetDtoValidations()
        {
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
            RuleFor(x=>x.PaperId).NotNull().WithMessage("PaperId Cannot Be Null");
            RuleFor(x=>x.Sale_Amount).NotNull().WithMessage("Sale Amount Cannot Be Null");
            RuleFor(x=>x.ItemId).NotNull().WithMessage("ItemId Cannot Be Null");
            RuleFor(x=>x.Buy_Amount).NotNull().WithMessage("Buy Amount Cannot Be Null");
        }
    }
}
