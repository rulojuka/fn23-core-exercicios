using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Blog.Infra;
using Blog.Models;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                IList<Post> lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                return lista;
                //var query = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;
                //return query.ToList();
            }
        }


    }
}