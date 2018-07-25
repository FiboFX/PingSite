using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PingSite.Core.DTO;
using PingSite.Core.Models;
using PingSite.Core.Repositories;
using PingSite.Core.Tools;

namespace PingSite.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ImgUrl = category.ImgUrl
            };

            return categoryDto;
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

        public async Task<bool> AddAsync(string name, IFormFile file)
        {
            FileTool fileTool = new FileTool();
            await fileTool.CopyFile(file);

            Category category = Category.Create(null, name, "/images/" + file.FileName);
            await _categoryRepository.AddAsync(category);

            return true;
        }

        public async Task<bool> EditAsync(int id, string name, IFormFile file)
        {
            var category = await _categoryRepository.GetAsync(id);

            if(file != null)
            {
                FileTool fileTool = new FileTool();
                fileTool.DeleteImg(category.ImgUrl);
                await fileTool.CopyFile(file);
                category.SetImgUrl("/images/" + file.FileName);
            }
            category.SetName(name);
            
            await _categoryRepository.UpdateAsync(category);

            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if(category == null)
            {
                return false;
            }

            try
            {
                await _categoryRepository.RemoveAsync(category);
            }
            catch(Exception e)
            {
                return false;
            }
            FileTool fileTool = new FileTool();
            fileTool.DeleteImg(category.ImgUrl);
            return true;
        }
    }
}
