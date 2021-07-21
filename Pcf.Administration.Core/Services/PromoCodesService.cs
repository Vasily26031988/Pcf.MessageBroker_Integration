using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pcf.Administration.Core.Abstractions.Repositories;
using Pcf.Administration.Core.Domain.Administration;

namespace Pcf.Administration.Core.Services
{
    public class PromoCodesService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly ILogger<PromoCodesService> _logger;

        public PromoCodesService(
            IRepository<Employee> employeeRepository,
            ILogger<PromoCodesService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<bool> UpdateAppliedPromoCodesAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                _logger?.LogWarning($"Employee by Id \"{id.ToString()}\" not found.");
                return false;
            }

            employee.AppliedPromocodesCount++;
            await _employeeRepository.UpdateAsync(employee);
            
            _logger?.LogInformation($"Updated applied promo codes for {employee.FullName}: {employee.AppliedPromocodesCount.ToString()}.");
            return true;
        }
    }
}
