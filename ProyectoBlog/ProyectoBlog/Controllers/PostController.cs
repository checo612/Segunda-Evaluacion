using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBlog.Models;
using ProyectoBlog.ViewModels;

namespace ProyectoBlog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            using (var db = new DbBlog.DbPosts())
            {
                List<Post> post = db.Posts.ToList();
                return View(post);
            }
        }

        //Añadir
        [HttpGet]
        public ActionResult Add()
        {
            return View(new PostViewModel());
        }

        [HttpPost]
        public ActionResult Add(PostViewModel postVM)
        {
           
                postVM.Post.Fecha = DateTime.Now;

                Category category = DbBlog.DbPosts.Categories.FirstOrDefault(p => p.Id == postVM.Post.CategoryId);

                postVM.Post.CategoryName = category.Name;

                using (var db = new DbBlog.DbPosts())
                {

                    db.Posts.Add(postVM.Post);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

        }

        //Editar

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new DbBlog.DbPosts())
            {
                PostViewModel postVM = new PostViewModel
                {
                    Post = db.Posts.FirstOrDefault(p => p.Id == id),
                    Categories = DbBlog.DbPosts.Categories
                };
                return View(postVM);
            }
        }


        [HttpPost]
        public ActionResult Edit(PostViewModel postVM)
        {
            postVM.Post.Fecha = DateTime.Now;

            Category category = DbBlog.DbPosts.Categories.FirstOrDefault(p => p.Id == postVM.Post.CategoryId);

            postVM.Post.CategoryName = category.Name;

            using (var db = new DbBlog.DbPosts())
            {
                Post postFromDb = db.Posts.FirstOrDefault(p => p.Id == postVM.Post.Id);

                postFromDb.Title = postVM.Post.Title;
                postFromDb.Content = postVM.Post.Content;
                postFromDb.CategoryName = postVM.Post.CategoryName;
                postFromDb.Fecha = postVM.Post.Fecha;
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        //Delete
        [HttpGet]
        public ActionResult Delete( int id)
        {
            using (var db = new DbBlog.DbPosts())
            {
                Post post = db.Posts.FirstOrDefault(p => p.Id == id);
                   
                return View(post);
            }
        }

        [HttpPost]
        public ActionResult Delete(Post postVM)
        {
            using (var db = new DbBlog.DbPosts())
            {
                Post PostToRemove = db.Posts.First(p => p.Id == postVM.Id);
                db.Posts.Remove(PostToRemove);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

    }
}