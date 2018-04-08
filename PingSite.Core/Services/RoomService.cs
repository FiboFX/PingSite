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

        public RoomService(IRoomRepository roomRepository, IBuildingRepository buildingRepository)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync(int buildingId)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var building = await _buildingRepository.GetAsync(buildingId);

            var buildingRooms = rooms.Where(x => x.Building == building);
            var buildingRoomsDto = new List<RoomDto>();

            foreach(var r in buildingRooms)
            {
                buildingRoomsDto.Add(new RoomDto() { Id = r.Id, Name = r.Name });
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
    }
}
