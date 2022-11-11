using Domain.VisitDate.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Travels.DTO
{
    public class AddNewTravelDTO
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string HotelName { get; set; }
        public string HotelStreet { get; set; }
        public int HotelBuildingNo { get; set; }
        public int HotelFlatNo { get; set; }
        public string HotelZipCode { get; set; }
        public string HotelCity { get; set; }
        public Decimal PlannedBudget { get; set; }
        public string Currency { get; set; }
        public List<AddNewVisitDateDTO> VisitDate { get; set; }

    }
}
