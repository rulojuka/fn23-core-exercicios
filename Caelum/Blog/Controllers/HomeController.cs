using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public IActionResult Busca(string termo)
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }

    }
}
