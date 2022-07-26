using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsFav { get; set; }
        public string Note { get; set; }
        public int ParticipantNumber { get; set; }
        public Decimal PlannedBudget { get; set; }
        public string? LinkUrl { get; set; }
        public DateTime? LinkExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public string HotelName { get; set; }
    }
}
