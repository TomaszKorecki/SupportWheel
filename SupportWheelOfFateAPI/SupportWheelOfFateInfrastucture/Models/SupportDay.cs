using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWheelOfFateInfrastructure.Models
{
    public class SupportDay
    {
        public DateTime Date { get; set; }
        public Employee ShiftOne { get; set; }
        public Employee ShiftTwo { get; set; }
    }
}
