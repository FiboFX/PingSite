using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Repositories
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<Building>> GetAllAsync();
        Task AddAsync(Building building);
        Task UpdateAsync(Building building);
        Task RemoveAsync(Building building);
    }
}
