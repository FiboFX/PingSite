using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface IBuildingService
    {
        Task<IEnumerable<BuildingDto>> GetAllAsync();
        Task<bool> AddAsync(string name);
        Task<bool> UpdateAsync(int id, string name);
        Task<bool> RemoveAsync(int id);
    }
}
