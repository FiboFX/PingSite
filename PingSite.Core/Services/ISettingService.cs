using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface ISettingService
    {
        Task<Settings> GetAsync();
        Task UpdateAsync(Settings settings);
    }
}
