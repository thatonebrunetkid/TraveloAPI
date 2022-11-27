using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Travels.DTO
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Note { get; set; }
        public Decimal PlannedBudget { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public string? HotelName { get; set; }
        public string PickedCurrency { get; set; }
        public string? HotelStreet { get; set; }
        public int? HotelBuildingNo { get; set; }
        public int? HotelFlatNo { get; set; }
        public string? HotelZipCode { get; set; }
        public string? HotelCity { get; set; }
    }
}
