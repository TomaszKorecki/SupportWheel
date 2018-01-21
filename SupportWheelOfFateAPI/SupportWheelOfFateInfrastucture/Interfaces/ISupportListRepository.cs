using System;
using System.Collections.Generic;
using System.Text;
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateInfrastructure.Interfaces
{
    public interface ISupportListRepository
    {
        SupportList GetSupportList();
        void SaveSupportList(SupportList supportDays);
    }
}
