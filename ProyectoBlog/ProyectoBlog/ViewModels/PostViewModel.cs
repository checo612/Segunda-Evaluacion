using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBlog.Models;

namespace ProyectoBlog.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Category> Categories { get; set; }

        public PostViewModel()
        {
            this.Categories = DbBlog.DbPosts.Categories;
        }
    }
}