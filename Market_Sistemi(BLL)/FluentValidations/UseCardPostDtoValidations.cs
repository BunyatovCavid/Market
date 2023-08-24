using FluentValidation;
using Market.Dtoes.PostDtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class UseCardPostDtoValidations:AbstractValidator<UseCardPostDto>
    {
        public UseCardPostDtoValidations()
        {
            RuleFor(x => x.CheckId).NotNull().WithMessage("CheckId Cannot be Null");
            RuleFor(x => x.CardBarkod).NotNull().WithMessage("Card Barcode Cannot be Null");
        }
    }
}
