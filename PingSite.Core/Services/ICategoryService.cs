using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PingSite.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<IEnumerable<SelectListItem>> GetSelectItemListAsync();
        Task<bool> Add(string name, string fileName);
    }
}
