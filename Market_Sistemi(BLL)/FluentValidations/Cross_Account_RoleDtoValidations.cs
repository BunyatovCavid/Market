using FluentValidation;
using Market.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class Cross_Account_RoleDtoValidations:AbstractValidator<Cross_Account_RoleDto>
    {
        public Cross_Account_RoleDtoValidations()
        {
            RuleFor(x=>x.AccountId).NotNull().WithMessage("AccountId Cannot Be Null");
            RuleFor(x=>x.RoleId).NotNull().WithMessage("RoleId Cannot Be Null");
        }
    }
}
