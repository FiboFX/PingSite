using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Services;
using PingSite.Models.Category;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PingSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategory addCategory)
        {
            if(ModelState.IsValid)
            {
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/images",
                        addCategory.File.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addCategory.File.CopyToAsync(stream);
                }

                var status = await _categoryService.Add(addCategory.Name, addCategory.File.FileName);

                return RedirectToAction("Categories", "Settings");
            }

            return View(addCategory);
        }
    }
}
