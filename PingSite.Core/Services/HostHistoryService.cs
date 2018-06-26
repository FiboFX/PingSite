using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class HostHistoryService : IHostHistoryService
    {
        private readonly IHostHistoryRepository _hostHistoryRepository;
        private readonly IHostRepository _hostRepository;

        public HostHistoryService(IHostHistoryRepository hostHistoryRepository, IHostRepository hostRepository)
        {
            _hostHistoryRepository = hostHistoryRepository;
            _hostRepository = hostRepository;
        }

        public async Task<IEnumerable<HostHistoryDto>> GetAllAsync(int hostId)
        {
            var allHostHistory = await _hostHistoryRepository.GetAllAsync();
            var host = await _hostRepository.GetAsync(hostId);
            var hostHistory = allHostHistory.Where(x => x.Host == host);

            List<HostHistoryDto> hostHistoryDtos = new List<HostHistoryDto>();

            foreach(var history in hostHistory)
            {
                hostHistoryDtos.Add(new HostHistoryDto
                {
                    Id = history.Id,
                    DateOnline = history.DateOnline
                });
            }

            return hostHistoryDtos.OrderByDescending(x => x.DateOnline).Take(10);
        }

        public async Task AddAsync(DateTime dateOnline, int hostId)
        {
            var host = await _hostRepository.GetAsync(hostId);
            var hostHistory = HostHistory.Create(null, dateOnline, host);

            await _hostHistoryRepository.AddAsync(hostHistory);
        }

        public async Task RemoveAllAsync(int hostId)
        {
            var host = await _hostRepository.GetAsync(hostId);
            var allHostHistory = await _hostHistoryRepository.GetAllAsync();
            var hostHistory = allHostHistory.Where(x => x.Host == host);

            foreach(var history in hostHistory)
            {
                await _hostHistoryRepository.RemoveAsync(history);
            }
        }

        public async Task RemoveAsync(int id)
        {
            var history = await _hostHistoryRepository.GetAsync(id);

            await _hostHistoryRepository.RemoveAsync(history);
        }
    }
}
