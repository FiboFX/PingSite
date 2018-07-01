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
            var addRoom = new AddRoom
            {
                BuildingId = id
            };

            return View(addRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoom addRoom)
        {
            if(ModelState.IsValid)
            {
                var status = await _roomService.AddAsync(addRoom.Name, addRoom.BuildingId);

                return RedirectToAction("Rooms", "Home", new { id = addRoom.BuildingId });
            }

            return View(addRoom);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, int buildingId = 0)
        {
            var room = await _roomService.GetAsync(id);
            var editRoom = new EditRoom() { Id = id, Name = room.Name, BuildingId = buildingId };
            return View(editRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoom editRoom)
        {
            if(ModelState.IsValid)
            {
                var status = await _roomService.EditAsync(editRoom.Id, editRoom.Name);

                if (editRoom.BuildingId == 0)
                {
                    return RedirectToAction("AllRooms", "Home");
                }
                else
                {
                    return RedirectToAction("Rooms", "Home", new { id = editRoom.BuildingId });
                }
            }

            return View(editRoom);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int buildingId)
        {
            var status = await _roomService.RemoveAsync(id);

            if(buildingId == 0)
            {
                return RedirectToAction("AllRooms", "Home");
            }
            else
            {
                return RedirectToAction("Rooms", "Home", new { id = buildingId });
            }
        }
    }
}
