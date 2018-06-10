using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Services
{
    public interface IHostService
    {
        Task<IEnumerable<HostDto>> GetAllAsync(int id);
        Task<bool> AddAsync(string name, string address, int roomId, int categoryId);
    }
}
