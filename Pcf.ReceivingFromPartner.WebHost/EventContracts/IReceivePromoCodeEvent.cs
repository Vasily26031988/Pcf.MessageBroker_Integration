using System;

namespace Pcf.ReceivingFromPartner.Core.EventContracts
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