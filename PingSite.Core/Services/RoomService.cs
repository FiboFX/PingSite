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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IHostRepository _hostRepository;

        public RoomService(IRoomRepository roomRepository, IBuildingRepository buildingRepository, IHostRepository hostRepository)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
            _hostRepository = hostRepository;
        }

        public async Task<RoomDto> GetAsync(int roomId)
        {
            var room = await _roomRepository.GetAsync(roomId);

            return new RoomDto { Id = room.Id, Name = room.Name };
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            List<RoomDto> roomsDto = new List<RoomDto>();

            foreach(var room in rooms)
            {
                roomsDto.Add(new RoomDto
                {
                    Id = room.Id,
                    Name = room.Name
                });
            }

            return roomsDto;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync(int buildingId)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var building = await _buildingRepository.GetAsync(buildingId);

            var buildingRooms = rooms.Where(x => x.Building == building);
            var buildingRoomsDto = new List<RoomDto>();

            foreach(var r in buildingRooms)
            {
                buildingRoomsDto.Add(new RoomDto
                {
                    Id = r.Id,
                    Name = r.Name
                });
            }

            return buildingRoomsDto;
        }

        public async Task<bool> AddAsync(string name, int buildingId)
        {
            var building = await _buildingRepository.GetAsync(buildingId);
            var room = Room.Create(null, name, building);

            await _roomRepository.AddAsync(room);

            return true;
        }

        public async Task<bool> EditAsync(int id, string name)
        {
            var room = await _roomRepository.GetAsync(id);
            if(room == null)
            {
                return false;
            }

            room.SetName(name);
            await _roomRepository.UpdateAsync(room);
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var room = await _roomRepository.GetAsync(id);
            if(room != null)
            {
                var allHosts = await _hostRepository.GetAllAsync();
                var hosts = allHosts.Where(x => x.Room == room);
                if(hosts != null)
                {
                    foreach(var host in hosts)
                    {
                        await _hostRepository.RemoveAsync(host);
                    }
                }

                await _roomRepository.RemoveAsync(room);
            }

            return true;
        }
    }
}
