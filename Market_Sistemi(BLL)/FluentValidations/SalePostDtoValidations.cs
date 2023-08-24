using FluentValidation;
using Market.Dtoes.PostDtoes;

namespace Market.Independents
{
    public class SalePostDtoValidations:AbstractValidator<SalePostDto>
    {
        public SalePostDtoValidations()
        {
            RuleFor(x=>x.CheckId).NotNull().WithMessage("CheckId Cannot be Null");
            RuleFor(x=>x.ItemId).NotNull().WithMessage("ItemId Cannot be Null");
            RuleFor(x=>x.Number).NotNull().WithMessage("Number Cannot be Null");
        }
    }
}
