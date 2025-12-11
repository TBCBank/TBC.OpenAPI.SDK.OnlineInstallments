using FluentValidation;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Validators
{
    public class MerchantApplicationStatusRequestValidator : AbstractValidator<MerchantApplicationStatusRequest>
    {
        public MerchantApplicationStatusRequestValidator()
        {
            RuleFor(x => x.MerchantKey)
                .NotEmpty()
                .WithMessage("MerchantKey is empty")
                .NotNull()
                .WithMessage("MerchantKey is null");
        }
    }
}
