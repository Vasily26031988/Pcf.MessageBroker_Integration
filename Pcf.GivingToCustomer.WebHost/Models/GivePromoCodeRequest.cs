using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Abstractions.EventContracts;


namespace Pcf.GivingToCustomer.WebHost.Models
{
    public class GivePromoCodeRequest : IReceivePromoCodeEvent
    {
        public string ServiceInfo { get; set; }
        public Guid PartnerId { get; set; }
        public Guid PromoCodeId { get; set; }
        public string PromoCode { get; set; }
        public Guid PreferenceId { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public Guid? PartnerManagerId { get; }
    }
}
