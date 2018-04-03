using PingSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Repositories
{
    public interface IHostRepository
    {
        Task<Host> GetAsync(int id);
        Task<IEnumerable<Host>> GetAllAsync();
        Task AddAsync(Host host);
        Task UpdateAsync(Host host);
        Task RemoveAsync(Host host);
    }
}
