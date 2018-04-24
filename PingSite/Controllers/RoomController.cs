using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Services;
using PingSite.Models.Room;

namespace PingSite.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var addRoom = new AddRoom();
            addRoom.BuildingId = id;

            return View(addRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoom addRoom)
        {
            var status = await _roomService.AddAsync(addRoom.Name, addRoom.BuildingId);

            return RedirectToAction("Rooms", "Home", new { id = addRoom.BuildingId });
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoom editRoom)
        {
            var status = await _roomService.EditAsync(editRoom.Id, editRoom.Name);

            return RedirectToAction("Index", "Home");
        }
    }
}
