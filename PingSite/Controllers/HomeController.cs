using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.DTO;
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
            var host = new HostDto();
            host.Id = 1;
            host.Address = "192.168.2.8";
            
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(host.Address);
                host.LastStatus = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }

            return View(host);
        }
    }
}
