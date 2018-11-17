using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Blog.Infra;
using Blog.Models;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            var lista = new List<Post>();
            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }
            return lista;
        }
    }
}