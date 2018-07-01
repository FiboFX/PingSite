using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Services;
using PingSite.Models.Building;

namespace PingSite.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBuilding addBuilding)
        {
            var status = await _buildingService.AddAsync(addBuilding.Name);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var building = await _buildingService.GetAsync(id);

            return View(new EditBuilding { Id = id, Name = building.Name });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBuilding editBuilding)
        {
            var status = await _buildingService.UpdateAsync(editBuilding.Id, editBuilding.Name);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _buildingService.RemoveAsync(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
