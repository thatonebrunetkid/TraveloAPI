using Application.DTOs.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.VisitDate
{
    public class AddVisitDateDto
    {
        public DateTime VisitDate { get; set; }
        public string Title { get; set; }
        public AddSpotDto[] Spots { get; set; }
    }
}
