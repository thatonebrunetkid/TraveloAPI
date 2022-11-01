using Domain.Alert.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Travels.DTO
{
    public class GetUpcomingTravelDTO
    {
        public string CountryName { get; set; }
        public string Currency { get; set; }
        public Decimal PlannedBudget { get; set; }
        public Decimal UsedBudget { get; set; }
        public string FlagUrl { get; set; }
        public List<AllAlertsDTO> CountryAlerts { get; set; }
    }
}
