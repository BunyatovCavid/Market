using FluentValidation;
using Market.Dtoes.PutDto;

namespace Market.Controllers
{
    public class AccountPutDtoValidations:AbstractValidator<AccountPutDto>
    {
        public AccountPutDtoValidations()
        {
            RuleFor(x=>x.Id).NotNull().WithMessage("Id Cannot Be Null");
            RuleFor(x=>x.Name).NotNull().WithMessage("Name Cannot Be Null");
            RuleFor(x=>x.Password).NotNull().WithMessage("Password Cannot Be Null");
        }
    }
}
