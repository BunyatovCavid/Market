using FluentValidation;
using Market.Dtoes.PutDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Sistemi_BLL_.FluentValidations
{
    public class ItemPutDtoValidations:AbstractValidator<ItemPutDto>
    {
        public ItemPutDtoValidations()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Barkod).NotNull().WithMessage("Barkod Cannot Be Null");
        }
    }
}
