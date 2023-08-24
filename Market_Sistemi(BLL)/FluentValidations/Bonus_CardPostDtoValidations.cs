using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class Bonus_CardPostDtoValidations:AbstractValidator<Bonus_CardPostDto>
    {
        public Bonus_CardPostDtoValidations()
        {
            RuleFor(x=>x.Barkod).NotNull().WithMessage("Barcode Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Phone).NotNull().WithMessage("Phone Cannot Be Null");
        }
    }
}
