﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Abstractions.Gateways
{
    public interface INotificationGateway
    {
        Task SendNotificationToPartnerAsync(Guid partnerId, string message);
    }
}
