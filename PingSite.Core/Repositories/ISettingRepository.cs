using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Repositories
{
    public interface ISettingRepository
    {
        Task<Setting> GetAsync(string name);
        Task<IEnumerable<Setting>> GetAllAsync();
        Task UpdateAsync(Setting setting);
    }
}
