using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.DTO;
using PingSite.Core.Repositories;
using PingSite.Core.Services;
using PingSite.Models;
using PingSite.Models.Host;

namespace PingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildingService _buildingService;
        private readonly IRoomService _roomService;
        private readonly IHostService _hostService;
        private readonly ICategoryService _categoryService;

        public HomeController(IBuildingService buildingService, IRoomService roomService, IHostService hostService, ICategoryService categoryService)
        {
            _buildingService = buildingService;
            _roomService = roomService;
            _hostService = hostService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Buildings");
        }

        [HttpGet]
        public async Task<IActionResult> Buildings()
        {
            var buildings = await _buildingService.GetAllAsync();

            return View(buildings);
        }

        [HttpGet]
        public async Task<IActionResult> Rooms(int id)
        {
            var rooms = await _roomService.GetAllAsync(id);
            ViewBag.BuildingId = id;

            return View(rooms);
        }

        [HttpGet]
        public async Task<IActionResult> AllRooms()
        {
            var rooms = await _roomService.GetAllAsync();

            return View(rooms);
        }

        public async Task<IActionResult> Hosts(int id)
        {
            ListHosts listHosts = new ListHosts();
            listHosts.Hosts = await _hostService.GetAllAsync(id);
            listHosts.Categories = await _categoryService.GetAllAsync();
            ViewBag.RoomId = id;

            return View(listHosts);
        }
    }
}
