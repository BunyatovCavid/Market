using FluentValidation;
using Market.Dtoes.Post_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public  class Discount_CardPostDtoValidations:AbstractValidator<Discount_CardPostDto>
    {
        public Discount_CardPostDtoValidations()
        {
            RuleFor(x=>x.Phone).NotNull().WithMessage("Phone Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Fin).NotNull().WithMessage("Fin Cannot Be Null");
            RuleFor(x=>x.Barkod).NotNull().WithMessage("Barkod Cannot Be Null");
        }
    }
}
