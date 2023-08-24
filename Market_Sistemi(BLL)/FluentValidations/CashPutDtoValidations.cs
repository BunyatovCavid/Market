using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class CashPutDtoValidations:AbstractValidator<CashPutDto>
    {
        public CashPutDtoValidations()
        {
            RuleFor(x=>x.Number).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
        }
    }
}
