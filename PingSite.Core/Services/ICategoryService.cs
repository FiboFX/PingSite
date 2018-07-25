using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace PingSite.Core.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<IEnumerable<SelectListItem>> GetSelectItemListAsync();
        Task<bool> AddAsync(string name, IFormFile file);
        Task<bool> EditAsync(int id, string name, IFormFile file);
        Task<bool> RemoveAsync(int id);
    }
}
