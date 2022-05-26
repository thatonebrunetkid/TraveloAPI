using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travels
    {
        [Key]
        public int TravelId { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string HotelName { get; set; }
        public bool? IdFav { get; set; }
        public string Note { get; set; }
        public int ParticipatNumber { get; set; }
        public Decimal PlannedBudget { get; set; }
        public string? LinkUrl { get; set; }
        public DateTime? LinkExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
