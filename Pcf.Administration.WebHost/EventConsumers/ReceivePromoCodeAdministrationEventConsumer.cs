using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Pcf.Administration.Core.Abstractions.EventContracts;
using Pcf.Administration.Core.Services;

namespace Pcf.Administration.WebHost.EventConsumers
{
    internal class ReceivePromoCodeAdministrationEventConsumer :
        IConsumer<IReceivePromoCodeEvent>
    {
        private readonly PromoCodesService _promoCodesService;

        public ReceivePromoCodeAdministrationEventConsumer(PromoCodesService promoCodesService)
        {
            _promoCodesService = promoCodesService;
        }

        public async Task Consume(ConsumeContext<IReceivePromoCodeEvent> context)
        {
            if (context.Message.PartnerManagerId.HasValue)
                await _promoCodesService.UpdateAppliedPromoCodesAsync(context.Message.PartnerManagerId.Value);
        }
    }
}
