using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Repositories
{
    public interface IHostHistoryRepository
    {
        Task<HostHistory> GetAsync(int id);
        Task<IEnumerable<HostHistory>> GetAllAsync();
        Task AddAsync(HostHistory hostHistory);
        Task RemoveAsync(HostHistory hostHistory);
    }
}
