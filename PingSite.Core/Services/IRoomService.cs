using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync(int buildingId);
        Task<bool> AddAsync(string name, int buildingId);
        Task<bool> EditAsync(int id, string name);
        Task<bool> RemoveAsync(int id);
    }
}
