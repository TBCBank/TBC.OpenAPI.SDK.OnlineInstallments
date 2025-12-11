using FluentValidation;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Validators
{
    public class InitiateInstallmentRequestValidator : AbstractValidator<InitiateInstallmentRequest>
    {
        public InitiateInstallmentRequestValidator()
        {
            RuleFor(x=>x.MerchantKey)
                .NotNull()
                .WithMessage("MerchantKey is null")
                .NotEmpty()
                .WithMessage("MerchantKey is empty");

            RuleFor(x=>x.PriceTotal)
                .NotNull()
                .WithMessage("PriceTotal is null")
                .NotEmpty()
                .WithMessage("PriceTotal is empty");

            RuleFor(x=>x.Products)
                .Must(x=>x != null && x.Count() > 0)
                .WithMessage("Products null or empty");
        }
    }
}
