using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingSite.Core.EF;
using PingSite.Core.Models;

namespace PingSite.Core.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly PingSiteContext _context;

        public BuildingRepository(PingSiteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
            => await _context.Buildings.ToListAsync();

        public async Task AddAsync(Building building)
        {
            await _context.Buildings.AddAsync(building);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Building building)
        {
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();
        }
    }
}
