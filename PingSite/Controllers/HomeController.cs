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

namespace PingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildingService _buildingService;
        private readonly IRoomService _roomService;
        private readonly IHostService _hostService;

        public HomeController(IBuildingService buildingService, IRoomService roomService, IHostService hostService)
        {
            _buildingService = buildingService;
            _roomService = roomService;
            _hostService = hostService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var host = new HostDto();
            //host.Id = 1;
            //host.Address = "192.168.2.8";

            //Ping ping = new Ping();
            //try
            //{
            //    PingReply reply = ping.Send(host.Address);
            //    host.LastStatus = reply.Status == IPStatus.Success;
            //}
            //catch (PingException)
            //{

            //}

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

        public async Task<IActionResult> Hosts(int id)
        {
            var hosts = await _hostService.GetAllAsync(id);

            return View(hosts);
        }
    }
}
