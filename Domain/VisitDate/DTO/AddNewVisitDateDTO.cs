using Domain.Spot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VisitDate.DTO
{
    public class AddNewVisitDateDTO
    {
        public DateTime Date { get; set; }
        public string? Title { get; set; }
        public List<AddNewSpotDTO>? Spot { get; set; }
    }
}
