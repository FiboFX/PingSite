using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PingSite.Core.Tools
{
    public class FileTool
    {
        public async Task CopyFile(IFormFile file)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\images",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public void DeleteImg(string imgUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + imgUrl);

            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
