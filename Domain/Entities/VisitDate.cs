using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VisitDate
    {
        [Key]
        public int TravelDateId { get; set; }
        public int TravelId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

    }
}
