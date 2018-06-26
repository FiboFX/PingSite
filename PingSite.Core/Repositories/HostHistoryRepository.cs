using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingSite.Core.EF;
using PingSite.Core.Models;

namespace PingSite.Core.Repositories
{
    public class HostHistoryRepository : IHostHistoryRepository
    {
        private readonly PingSiteContext _context;

        public HostHistoryRepository(PingSiteContext context)
        {
            _context = context;
        }

        public async Task<HostHistory> GetAsync(int id)
            => await _context.HostsHistory.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<HostHistory>> GetAllAsync()
            => await _context.HostsHistory.ToListAsync();

        public async Task AddAsync(HostHistory hostHistory)
        {
            await _context.HostsHistory.AddAsync(hostHistory);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(HostHistory hostHistory)
        {
            _context.HostsHistory.Remove(hostHistory);
            await _context.SaveChangesAsync();
        }
    }
}
