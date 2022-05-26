﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public Decimal Cost { get; set; }
        public int SpotId { get; set; }
        public int TravelId { get; set; }
    }
}