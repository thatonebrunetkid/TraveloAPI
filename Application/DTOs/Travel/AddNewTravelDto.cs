using Application.DTOs.VisitDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Travel
{
    public class AddNewTravelDto
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public int ParticipatNumber { get; set; }
        public Decimal PlannedBudget { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public AddVisitDateDto VisitDate { get; set; }
    }
}
