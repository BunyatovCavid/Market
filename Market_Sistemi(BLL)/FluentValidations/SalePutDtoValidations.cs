using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class SalePutDtoValidations:AbstractValidator<SalePutDto>
    {
        public SalePutDtoValidations()
        {
            RuleFor(x=>x.Number).NotNull().WithMessage("Number Cannot Be Null");
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
            RuleFor(x=>x.CheckNumber).NotNull().WithMessage("Check Number Cannot Be Null");
        }
    }
}
