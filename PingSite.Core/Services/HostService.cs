using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IRoomRepository _roomRepository;

        public HostService(IHostRepository hostRepository, IRoomRepository roomRepository)
        {
            _hostRepository = hostRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<HostDto>> GetAllAsync(int id)
        {
            var room = await _roomRepository.GetAsync(id);
            if(room == null)
            {
                return new List<HostDto>();
            }
            var allHosts = await _hostRepository.GetAllAsync();
            var hosts = allHosts.Where(x => x.Room == room);

            List<HostDto> hostsDto = new List<HostDto>();
            foreach(var host in hosts)
            {
                hostsDto.Add(new HostDto() { Id = host.Id, Name = host.Name, Address = host.Address, LastStatus = host.LastStatus });
            }

            return hostsDto;
        }
    }
}
