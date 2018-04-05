using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PingSite.Core.DTO;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
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
    }
}
