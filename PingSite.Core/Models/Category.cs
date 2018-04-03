using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ImgUrl { get; private set; }

        protected Category() { }

        protected Category(int id, string name, string imgUrl)
        {
            Id = id;
            SetName(name);
            SetImgUrl(imgUrl);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Category name can't be empty");
            }
            Name = name;
        }

        public void SetImgUrl(string imgUrl)
        {
            if (string.IsNullOrWhiteSpace(imgUrl))
            {
                throw new Exception("Img url can't be empty");
            }
            ImgUrl = imgUrl;
        }

        public static Category Create(int id, string name, string imgUrl)
            => new Category(id, name, imgUrl);
    }
}
