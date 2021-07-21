using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Pcf.GivingToCustomer.Core.Abstractions.EventContracts;
using Pcf.GivingToCustomer.Core.Services;

namespace Pcf.GivingToCustomer.WebHost.EventConsumers
{
    internal class ReceivePromoCodeCustomerEventConsumer :
        IConsumer<IReceivePromoCodeEvent>
    {
        private readonly PromoCodesService _promoCodesService;
        private readonly ILogger<ReceivePromoCodeCustomerEventConsumer> _logger;

        public ReceivePromoCodeCustomerEventConsumer(
            PromoCodesService promoCodesService,
            ILogger<ReceivePromoCodeCustomerEventConsumer> logger)
        {
            _promoCodesService = promoCodesService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IReceivePromoCodeEvent> context)
        {
            await _promoCodesService.GivePromoCodesToCustomersWithPreferenceAsync(context.Message);
        }
    }
}
