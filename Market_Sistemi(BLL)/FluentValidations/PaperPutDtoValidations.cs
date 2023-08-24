using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class PaperPutDtoValidations:AbstractValidator<PaperPutDto>
    {
        public PaperPutDtoValidations()
        {
            RuleFor(x => x.PaperNumber).NotNull().WithMessage("Paper Number Cannot Be Null");
            RuleFor(x => x.CompanyId).NotNull().WithMessage("CompanyId Cannot Be Null");
            RuleFor(x => x.AccountId).NotNull().WithMessage("AccountID Cannot Be Null");
        }
    }
}
