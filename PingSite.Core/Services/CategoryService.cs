using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PingSite.Core.DTO;
using PingSite.Core.Repositories;

namespace PingSite.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            List<CategoryDto> categoriesDto = new List<CategoryDto>();

            foreach(var category in categories)
            {
                categoriesDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImgUrl = category.ImgUrl
                });
            }

            return categoriesDto;
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectItemListAsync()
        {
            var categories = await GetAllAsync();
            var selectListItem = new List<SelectListItem>();
            foreach (var category in categories)
            {
                selectListItem.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                });
            }

            return selectListItem;
        }
    }
}
