using FluentValidation;
using Market_Sistemi_BLL_.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class AllOneNamePostDtoValidations:AbstractValidator<AllOneNamePostDto>
    {
        public AllOneNamePostDtoValidations()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name Cannot be Null");
        }
    }
}
