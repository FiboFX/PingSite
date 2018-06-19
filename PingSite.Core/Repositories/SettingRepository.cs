using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingSite.Core.EF;
using PingSite.Core.Models;

namespace PingSite.Core.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly PingSiteContext _context;

        public SettingRepository(PingSiteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
            => await _context.Settings.ToListAsync();

        public async Task UpdateAsync(Setting setting)
        {
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
        }
    }
}
