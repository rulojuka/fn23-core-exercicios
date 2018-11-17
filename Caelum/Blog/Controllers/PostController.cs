using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }

    }
}
