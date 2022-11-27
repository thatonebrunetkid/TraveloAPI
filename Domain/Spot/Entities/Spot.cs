using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Spot.Entities
{
    public class Spot
    {
        [Key]
        public int SpotId { get; set; }
        public string? Note { get; set; }
        public int Order { get; set; }
        public string? Street { get; set; }
        public string? BuildingNo { get; set; }
        public string? FlatNo { get; set; }
        public string? ZipCode { get; set; }
        public int VisitDateId { get; set; }
        public int ExpenseId { get; set; }
        public Decimal? CoordinateX { get; set; }
        public Decimal? CoordinateY { get; set; }
        public string? Name { get; set; }
    }

}
