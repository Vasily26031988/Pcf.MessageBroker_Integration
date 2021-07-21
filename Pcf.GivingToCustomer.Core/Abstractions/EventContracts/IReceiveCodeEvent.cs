using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Abstractions.EventContracts
{
    public interface IReceivePromoCodeEvent
    {
        string ServiceInfo { get; }
        Guid PartnerId { get; }
        Guid PromoCodeId { get; }
        string PromoCode { get; }
        Guid PreferenceId { get; }
        string BeginDate { get; }
        string EndDate { get; }
        Guid? PartnerManagerId { get; }
    }
}
