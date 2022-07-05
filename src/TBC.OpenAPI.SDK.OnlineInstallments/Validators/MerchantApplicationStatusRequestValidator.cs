using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
