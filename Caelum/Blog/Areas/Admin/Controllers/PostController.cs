using System.Collections.Generic;
using Blog.DAO;
using Blog.Filters;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Areas.Admin.Controllers
{
    [AutorizacaoFilter]
    [Area("Admin")]
    public class PostController : Controller
    {
        private PostDAO dao;
        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }
        public IActionResult Index()
        {
            IList<Post> lista = dao.Lista();
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            if (ModelState.IsValid)
            {
                string usuarioJson = HttpContext.Session.GetString("usuario");
                Usuario logado = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
                dao.Adiciona(post,logado);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", post);
            }
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }

        public IActionResult Remove(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edita(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }

        public IActionResult Publica(int id)
        {
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }


    }
}
