using Blog.DAO;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO DAO;

        public HomeController(PostDAO dao)
        {
            this.DAO = dao;
        }

        public ActionResult Index()
        {
            IList<Post> publicados = new List<Post>();
            var vazio = false;

            publicados = DAO.GetPublicados();                       
            if (publicados.Count == 0) { vazio = true; }
            ViewBag.Vazio = vazio;

            var auth = HttpContext.GetOwinContext().Request.User.Identity.IsAuthenticated;
            ViewBag.Autenticado = auth;

            return View(publicados);
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> posts = DAO.BuscaPeloTermo(termo);

            var vazio = false;
            if(posts.Count == 0) { vazio = true; }
            ViewBag.Vazio = vazio;

            return View("Index", posts);
        }        
    }
}