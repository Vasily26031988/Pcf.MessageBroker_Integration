using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.Core.Domain
{
    public class CustomerPreference
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }
    }
}
