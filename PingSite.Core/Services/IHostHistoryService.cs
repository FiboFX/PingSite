using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface IHostHistoryService
    {
        Task<IEnumerable<HostHistoryDto>> GetAllAsync(int hostId);
        Task AddAsync(DateTime dateOnline, int hostId);
        Task RemoveAsync(int id);
        Task RemoveAllAsync(int hostId);
    }
}
