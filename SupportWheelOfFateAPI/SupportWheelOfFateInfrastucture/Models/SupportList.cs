using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWheelOfFateInfrastructure.Models
{
    public class SupportList
    {
        public List<SupportDay> SupportDays { get; }

        public SupportList(List<SupportDay> supportDays)
        {
            SupportDays = supportDays;
        }
    }
}
