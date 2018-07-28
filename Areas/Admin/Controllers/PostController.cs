using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IList<Post> posts;
        private PostDAO DAO;

        public PostController(PostDAO dao)
        {
            this.DAO = dao;
            this.posts = new List<Post>();
        }

        public ActionResult Index()
        {            
            IList<Post> lista = new List<Post>();
            lista = DAO.GetPosts();

            return View(lista);
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            var lista = DAO.GetPost(categoria);
            return View("Index", lista);
        }

        public ActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            if(ModelState.IsValid)
            {
                DAO.InsertPost(post);
            }
            else
            {
                return View("Novo", post);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            DAO.RemovePost(id);
            return RedirectToAction("Index");
        }

        public ActionResult ViewPost(int id)
        {
            Post post = DAO.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edita(Post post)
        {
            if (ModelState.IsValid)
            {
                DAO.UpdatePost(post);
            }
            else
            {
                return View("Novo", post);
            }

            return RedirectToAction("Index");          
        }

        public ActionResult Publica(int id)
        {
            DAO.PublishPost(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutoComplete(string caracteres)
        {
            var lista = DAO.CategoriaAutoComplete(caracteres);
            return Json(lista);
        }
    }
}