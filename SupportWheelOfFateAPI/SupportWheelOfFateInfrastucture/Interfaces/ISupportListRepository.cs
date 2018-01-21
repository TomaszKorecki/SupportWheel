using System;
using System.Collections.Generic;
using System.Text;
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateInfrastructure.Interfaces
{
    public interface ISupportListRepository
    {
        List<SupportDay> GetSupportList();
        void SaveSupportList(List<SupportDay> supportDays);
    }
}
