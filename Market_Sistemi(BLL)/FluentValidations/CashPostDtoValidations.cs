using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class CashPostDtoValidations:AbstractValidator<CashPostDto>
    {
        public CashPostDtoValidations()
        {
            RuleFor(x=>x.Number).NotNull().WithMessage("Name Cannot Be Null");
        }
    }
}
