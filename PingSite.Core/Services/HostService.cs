using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HostService(IHostRepository hostRepository, IRoomRepository roomRepository, ICategoryRepository categoryRepository)
        {
            _hostRepository = hostRepository;
            _roomRepository = roomRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<HostDto> GetAsync(int id)
        {
            var host = await _hostRepository.GetAsync(id);
            
            var hostDto = new HostDto()
            {
                Id = host.Id,
                Name = host.Name,
                Address = host.Address,
                CategoryId = host.Category.Id
            };

            return hostDto;
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

        public async Task<bool> AddAsync(string name, string address, int roomId, int categoryId)
        {
            var room = await _roomRepository.GetAsync(roomId);
            var category = await _categoryRepository.GetAsync(categoryId);
            bool lastStatus = false;

            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(address);
                lastStatus = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }

            var host = Host.Create(null, name, address, lastStatus, category, room);
            await _hostRepository.AddAsync(host);

            return true;
        }

        public async Task<bool> EditAsync(int id, string name, string address, int roomId, int categoryId)
        {
            var host = await _hostRepository.GetAsync(id);
            var category = await _categoryRepository.GetAsync(categoryId);
            var room = await _roomRepository.GetAsync(roomId);
            bool lastStatus = false;

            host.SetName(name);
            host.SetAddress(address);
            host.SetCategory(category);
            host.SetRoom(room);

            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(address);
                lastStatus = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }
            host.SetLastStatus(lastStatus);

            await _hostRepository.UpdateAsync(host);

            return true;
        }
    }
}
