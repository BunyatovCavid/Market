using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class Discount_CardPutDtoValidations:AbstractValidator<Discount_CardPutDto>
    {
        public Discount_CardPutDtoValidations()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id Cannot be Null");
            RuleFor(x => x.Phone).NotNull().WithMessage("Phone Cannot be Null");
            RuleFor(x => x.Name).NotNull().WithMessage("Name Cannot be Null");
            RuleFor(x => x.Fin).NotNull().WithMessage("Fin Cannot be Null");
            RuleFor(x => x.Barkod).NotNull().WithMessage("Barkod Cannot be Null");
        }
    }
}
