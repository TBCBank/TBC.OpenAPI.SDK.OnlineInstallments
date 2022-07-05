using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Validators
{
    public class MerchantApplicationStatusSyncRequestValidator : AbstractValidator<MerchantApplicationStatusSyncRequest>
    {
        public MerchantApplicationStatusSyncRequestValidator()
        {
            RuleFor(x => x.MerchantKey)
                .NotEmpty()
                .WithMessage("MerchantKey is empty")
                .NotNull()
                .WithMessage("MerchantKey is null");

            RuleFor(x => x.SynchronizationRequestId)
                .NotEmpty()
                .WithMessage("SynchronizationRequestId is empty")
                .NotNull()
                .WithMessage("SynchronizationRequestId is null");
        }
    }
}
