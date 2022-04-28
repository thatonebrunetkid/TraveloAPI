using Application.DTOs.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Spot
{
    public class AddSpotDto
    {
        public string Note { get; set; }
        public int Order { get; set; }
        public string Street { get; set; }
        public string BuildingNo { get; set; }
        public string FlatNo { get; set; }
        public string ZipCode { get; set; }
        public AddExpenseDto Expense { get; set; }
    }
}
