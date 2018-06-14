using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface IHostService
    {
        Task<HostDto> GetAsync(int id);
        Task<IEnumerable<HostDto>> GetAllAsync(int id);
        Task<bool> AddAsync(string name, string address, int roomId, int categoryId);
        Task<bool> EditAsync(int id, string name, string address, int roomId, int categoryId);
        Task<bool> RemoveAsync(int id);
    }
}
