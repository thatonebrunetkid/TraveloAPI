using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Travel
{
    public class GetCurrentTravelInformationDto
    {
        public string CountryName { get; set; }
        public string Currency { get; set; }
        public Decimal PlannedBudged { get; set; }
        public Decimal UsedBudget { get; set; }
        public string FlagUrl { get; set; }
        public List<Domain.Entities.Alert> CountryAlerts { get; set; }
    }
}
