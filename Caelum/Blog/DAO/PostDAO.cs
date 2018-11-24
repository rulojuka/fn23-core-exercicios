using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

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

        public void Remove(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                // Remove em apenas uma query
                Post p = new Post() { Id = id };
                contexto.Posts.Remove(p);
                contexto.SaveChanges();
            }
            // Também é possível fazer de uma maneira mais simples, porém com 2 queries
            // Post post = contexto.Posts.Find(id);
            // contexto.Posts.Remove(post);
        }

        public Post BuscaPorId(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                return post;
            }
        }

        public void Atualiza(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

    }
}