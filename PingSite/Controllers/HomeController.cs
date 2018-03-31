using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Models;

namespace PingSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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

            return View();
        }
    }
}
