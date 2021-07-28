using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pcf.GivingToCustomer.Core.Abstractions.EventContracts;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;


namespace Pcf.GivingToCustomer.Core.Services
{
     public class PromoCodesService
    {
        private readonly IRepository<PromoCode> _promoCodeRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Preference> _preferenceRepository;
        private readonly ILogger<PromoCodesService> _logger;

        public PromoCodesService(
            IRepository<PromoCode> promoCodeRepository,
            IRepository<Customer> customerRepository,
            IRepository<Preference> preferenceRepository,
            ILogger<PromoCodesService> logger)
        {
            _promoCodeRepository = promoCodeRepository;
            _customerRepository = customerRepository;
            _preferenceRepository = preferenceRepository;
            _logger = logger;
        }

        public async Task<PromoCode> GivePromoCodesToCustomersWithPreferenceAsync(IReceivePromoCodeEvent message)
        {
            var preference = await _preferenceRepository.GetByIdAsync(message.PreferenceId);
            if (preference == null)
            {
                _logger.LogWarning($"Preference by Id \"{message.PreferenceId.ToString()}\" not found.");
                return null;
            }

            var customers = await _customerRepository
                .GetWhere(d => d.Preferences.Any(x =>
                    x.Preference.Id == preference.Id));

            var promoCode = MapFromMessage(message, preference, customers);

            await _promoCodeRepository.AddAsync(promoCode);
            
            _logger.LogInformation($"Promo code \"{promoCode.Code}\" given to {promoCode.Customers.Count.ToString()} customer(s).");
            return promoCode;
        }
        
        private static PromoCode MapFromMessage(IReceivePromoCodeEvent message, Preference preference, IEnumerable<Customer> customers)
        {
            var promocode = new PromoCode
            {
                Id = message.PromoCodeId,
                PartnerId = message.PartnerId,
                Code = message.PromoCode,
                ServiceInfo = message.ServiceInfo,
                BeginDate = DateTime.Parse(message.BeginDate),
                EndDate = DateTime.Parse(message.EndDate),
                Preference = preference,
                PreferenceId = preference.Id,
                Customers = new List<PromoCodeCustomer>()
            };

            foreach (var item in customers)
            {
                promocode.Customers.Add(new PromoCodeCustomer()
                {
                    CustomerId = item.Id,
                    Customer = item,
                    PromoCodeId = promocode.Id,
                    PromoCode = promocode
                });
            };

            return promocode;
        }
    }
}
