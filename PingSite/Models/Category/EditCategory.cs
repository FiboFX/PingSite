using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Category
{
    public class EditCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile File { get; set; }
    }
}