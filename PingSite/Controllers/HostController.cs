using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Services;
using PingSite.Models.Host;

namespace PingSite.Controllers
{
    public class HostController : Controller
    {
        private readonly IHostService _hostService;
        private readonly ICategoryService _categoryService;

        public HostController(IHostService hostService, ICategoryService categoryService)
        {
            _hostService = hostService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var addHost = new AddHost() { RoomId = id, Categories = categories };

            return View(addHost);
        }

        public async Task<IActionResult> Add(AddHost addHost)
        {
            var status = await _hostService.AddAsync(addHost.Name, addHost.Address, addHost.RoomId, addHost.CategoryId);

            return RedirectToAction("Hosts", "Home", new { id = addHost.RoomId });
        }
    }
}
