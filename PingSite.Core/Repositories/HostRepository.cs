using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingSite.Core.EF;
using PingSite.Core.Models;

namespace PingSite.Core.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly PingSiteContext _context;

        public HostRepository(PingSiteContext context)
        {
            _context = context;
        }

        public async Task<Host> GetAsync(int id)
            => await _context.Hosts
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Host>> GetAllAsync()
            => await _context.Hosts
                .Include(x => x.Category)
                .ToListAsync();

        public async Task AddAsync(Host host)
        {
            await _context.Hosts.AddAsync(host);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Host host)
        {
            _context.Hosts.Update(host);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Host host)
        {
            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();
        }
    }
}
