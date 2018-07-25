using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingSite.Core.Services;
using PingSite.Core.Tools;
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
                var status = await _categoryService.AddAsync(addCategory.Name, addCategory.File);

                return RedirectToAction("Categories", "Settings");
            }

            return View(addCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetAsync(id);

            var editCategory = new EditCategory
            {
                Id = (int)category.Id,
                Name = category.Name,
                ImgUrl = category.ImgUrl
            };

            return View(editCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategory editCategory)
        {
            if(ModelState.IsValid)
            {
                var status = await _categoryService.EditAsync(editCategory.Id, editCategory.Name, editCategory.File);

                return RedirectToAction("Categories", "Settings");
            }

            return View(editCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _categoryService.RemoveAsync(id);

            return RedirectToAction("Categories", "Settings");
        }
    }
}
