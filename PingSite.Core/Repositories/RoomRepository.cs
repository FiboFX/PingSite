using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingSite.Core.EF;
using PingSite.Core.Models;

namespace PingSite.Core.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly PingSiteContext _context;

        public RoomRepository(PingSiteContext context)
        {
            _context = context;
        }

        public async Task<Room> GetAsync(int id)
            => await _context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await _context.Rooms.ToListAsync();

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Room room)
        {
            _context.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
