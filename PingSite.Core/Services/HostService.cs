using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;
using PingSite.Core.Tools;

namespace PingSite.Core.Services
{
    public class HostService : IHostService
    {
        private readonly IHostRepository _hostRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHostHistoryService _hostHistoryService;

        public HostService(IHostRepository hostRepository, IRoomRepository roomRepository, ICategoryRepository categoryRepository, IHostHistoryService hostHistoryService)
        {
            _hostRepository = hostRepository;
            _roomRepository = roomRepository;
            _categoryRepository = categoryRepository;
            _hostHistoryService = hostHistoryService;
        }

        public async Task<HostDto> GetAsync(int id)
        {
            var host = await _hostRepository.GetAsync(id);

            var hostDto = new HostDto()
            {
                Id = host.Id,
                Name = host.Name,
                Address = host.Address,
                LastStatus = host.LastStatus,
                Category = new CategoryDto
                {
                    Id = host.Category.Id,
                    Name = host.Category.Name,
                    ImgUrl = host.Category.ImgUrl
                },
                Room = new RoomDto
                {
                    Id = host.Room.Id,
                    Name = host.Room.Name
                }
            };

            return hostDto;
        }

        public async Task<IEnumerable<HostDto>> GetAllAsync()
        {
            var allHosts = await _hostRepository.GetAllAsync();

            List<HostDto> hostsDto = new List<HostDto>();
            foreach (var host in allHosts)
            {
                hostsDto.Add(new HostDto
                {
                    Id = host.Id,
                    Name = host.Name,
                    Address = host.Address,
                    LastStatus = host.LastStatus,
                    Category = new CategoryDto
                    {
                        Id = host.Category.Id,
                        Name = host.Category.Name,
                        ImgUrl = host.Category.ImgUrl
                    },
                    Room = new RoomDto
                    {
                        Id = host.Room.Id,
                        Name = host.Room.Name
                    }
                });
            }

            return hostsDto;
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
                hostsDto.Add(new HostDto
                {
                    Id = host.Id,
                    Name = host.Name,
                    Address = host.Address,
                    LastStatus = host.LastStatus,
                    Category = new CategoryDto
                    {
                        Id = host.Category.Id,
                        Name = host.Category.Name,
                        ImgUrl = host.Category.ImgUrl
                    },
                    Room = new RoomDto
                    {
                        Id = host.Room.Id,
                        Name = host.Room.Name
                    }
                });
            }

            return hostsDto;
        }

        public async Task<bool> AddAsync(string name, string address, int roomId, int categoryId)
        {
            var room = await _roomRepository.GetAsync(roomId);
            var category = await _categoryRepository.GetAsync(categoryId);
            bool lastStatus = PingTool.CheckPingStatus(address);

            var host = Host.Create(null, name, address, lastStatus, category, room);
            await _hostRepository.AddAsync(host);

            return true;
        }

        public async Task<bool> EditAsync(int id, string name, string address, int roomId, int categoryId)
        {
            var host = await _hostRepository.GetAsync(id);
            var category = await _categoryRepository.GetAsync(categoryId);
            var room = await _roomRepository.GetAsync(roomId);
            bool lastStatus = PingTool.CheckPingStatus(address);

            host.SetName(name);
            host.SetAddress(address);
            host.SetCategory(category);
            host.SetRoom(room);
            host.SetLastStatus(lastStatus);

            await _hostRepository.UpdateAsync(host);

            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var host = await _hostRepository.GetAsync(id);

            await _hostHistoryService.RemoveAllAsync(id);
            await _hostRepository.RemoveAsync(host);
            return true;
        }
    }
}
