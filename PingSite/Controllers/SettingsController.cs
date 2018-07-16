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
        private readonly ICategoryService _categoryService;

        public SettingsController(ISettingService settingService, ICategoryService categoryService)
        {
            _settingService = settingService;
            _categoryService = categoryService;
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

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _categoryService.GetAllAsync();

            return View(categories);
        }
    }
}
