using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VisitDate.Entities
{
    public class VisitDate
    {
        [Key]
        public int VisitDateId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public int TravelId { get; set; }
    }
}
