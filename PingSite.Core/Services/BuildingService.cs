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
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHostRepository _hostRepository;

        public BuildingService(IBuildingRepository buildingRepository, IRoomRepository roomRepository, IHostRepository hostRepository)
        {
            _buildingRepository = buildingRepository;
            _roomRepository = roomRepository;
            _hostRepository = hostRepository;
        }

        public async Task<BuildingDto> GetAsync(int buildingId)
        {
            var building = await _buildingRepository.GetAsync(buildingId);

            return new BuildingDto { Id = buildingId, Name = building.Name };
        }

        public async Task<IEnumerable<BuildingDto>> GetAllAsync()
        {
            var buildings = await _buildingRepository.GetAllAsync();
            var buildingsDto = new List<BuildingDto>();

            foreach(var b in buildings)
            {
                buildingsDto.Add(new BuildingDto() { Id = b.Id, Name = b.Name });
            }

            return buildingsDto;
        }

        public async Task<bool> AddAsync(string name)
        {
            var building = Building.Create(null, name);
            await _buildingRepository.AddAsync(building);

            return true;
        }

        public async Task<bool> UpdateAsync(int id, string name)
        {
            var building = await _buildingRepository.GetAsync(id);
            if(building == null)
            {
                return false;
            }
            building.SetName(name);
            await _buildingRepository.UpdateAsync(building);

            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var building = await _buildingRepository.GetAsync(id);
            if(building == null)
            {
                return false;
            }
            var rooms = await _roomRepository.GetAllAsync();
            var buildingRooms = rooms.Where(x => x.Building == building);

            if(buildingRooms != null)
            {
                foreach (var room in buildingRooms)
                {
                    var allHosts = await _hostRepository.GetAllAsync();
                    var hosts = allHosts.Where(x => x.Room == room);
                    if (hosts != null)
                    {
                        foreach (var host in hosts)
                        {
                            await _hostRepository.RemoveAsync(host);
                        }
                    }

                    await _roomRepository.RemoveAsync(room);
                }
            }

            await _buildingRepository.RemoveAsync(building);

            return true;
        }
    }
}
