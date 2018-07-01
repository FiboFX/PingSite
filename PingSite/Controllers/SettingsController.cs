using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.DTO;
using PingSite.Core.Services;

namespace PingSite.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<IActionResult> General()
        {
            var settings = await _settingService.GetAsync();

            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> General(Settings settings)
        {
            if(ModelState.IsValid)
            {
                await _settingService.UpdateAsync(settings);

                return RedirectToAction("General");
            }

            return View(settings);
        }
    }
}
