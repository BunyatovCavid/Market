using FluentValidation;
using Market_Sistemi_BLL_.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class AllOneNumberPostDtoValidations:AbstractValidator<AllOneNumberPostDto>
    {
        public AllOneNumberPostDtoValidations()
        {
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
        }
    }
}
