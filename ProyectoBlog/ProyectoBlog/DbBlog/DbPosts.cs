using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProyectoBlog.Models;

namespace ProyectoBlog.DbBlog
{
    public class DbPosts:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public static List<Category> Categories = new List<Category>
        {
            new Category{Id=1, Name= "Beagle"},
            new Category{Id=2, Name= "Pastor Aleman"},
            new Category{Id=3, Name= "Bulldog"},
            new Category{Id=4, Name= "Chihuahua"},
            new Category{Id=5, Name= "Pug"}
        };
    }
}