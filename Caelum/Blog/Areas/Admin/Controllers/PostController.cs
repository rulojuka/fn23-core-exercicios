using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
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
            if(ModelState.IsValid){
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else{
                return View("Novo", post);
            }
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }

        public IActionResult Remove(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edita(Post post)
        {
            if(ModelState.IsValid){
                PostDAO dao = new PostDAO();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else{
                return View("Visualiza", post);
            }
        }

        public IActionResult Publica(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            PostDAO dao = new PostDAO();
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }


    }
}
