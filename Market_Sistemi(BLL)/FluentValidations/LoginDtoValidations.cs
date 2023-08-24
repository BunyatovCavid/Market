using FluentValidation;
using Market.Dtoes.Get_Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class LoginDtoValidations:AbstractValidator<LoginDto>
    {
        public LoginDtoValidations()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x => x.Password).NotNull().WithMessage("Password Cannot Be Null");
        }
    }
}
