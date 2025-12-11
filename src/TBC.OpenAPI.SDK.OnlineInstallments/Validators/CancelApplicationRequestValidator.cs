using FluentValidation;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Validators
{
    public class CancelApplicationRequestValidator : AbstractValidator<CancelApplicationRequest>
    {
        public CancelApplicationRequestValidator()
        {
            RuleFor(x => x.SessionId)
                .NotEmpty()
                .WithMessage("SessionId is empty")
                .NotNull()
                .WithMessage("SessionId is null");

            RuleFor(x => x.MerchantKey)
                .NotEmpty()
                .WithMessage("MerchantKey is empty")
                .NotNull()
                .WithMessage("MerchantKey is null");
        }
    }
}
