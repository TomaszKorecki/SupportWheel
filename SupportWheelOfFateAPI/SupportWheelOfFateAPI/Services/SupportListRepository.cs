using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
using Microsoft.Extensions.Caching.Memory;
using SupportWheelOfFateInfrastructure.Interfaces;
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateAPI.Services
{
    public class SupportListRepository : ISupportListRepository
    {
        private IMemoryCache MemoryCache { get; }
        private string SupportListEntryKey = "support_list";

        public SupportListRepository (IMemoryCache memoryMemoryCache)
        {
            MemoryCache = memoryMemoryCache;
        }

        public SupportList GetSupportList()
        {
            return MemoryCache.Get<SupportList>(SupportListEntryKey);
        }

        public void SaveSupportList(SupportList supportDays)
        {
            MemoryCache.Set(SupportListEntryKey, supportDays);
        }
    }
}
