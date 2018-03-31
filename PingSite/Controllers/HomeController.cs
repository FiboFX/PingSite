using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Repositories;
using PingSite.Models;

namespace PingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildingRepository _buildingRepository;

        public HomeController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<IActionResult> Index()
        {
            bool isOnline = false;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send("192.168.2.8");
                isOnline = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }

            ViewBag.IsOnline = isOnline;
            var buildList = await _buildingRepository.GetAllAsync();

            return View();
        }
    }
}
