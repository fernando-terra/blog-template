using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext context;

        public PostDAO(BlogContext obj)
        {
            this.context = obj;
        }

        public IList<Post> GetPosts()
        {
            IList<Post> lista = new List<Post>();
            /*
            using (SqlConnection cnx = ConnectionFactory.CriaConexao())
            {
                var cmdSql = @"SELECT ID,
                                      TITULO,
                                      RESUMO,
                                      CATEGORIA
                                 FROM POSTS";

                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = cmdSql;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Post
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Titulo = Convert.ToString(reader["TITULO"]),
                        Categoria = Convert.ToString(reader["CATEGORIA"]),
                        Resumo = Convert.ToString(reader["RESUMO"])
                    });
                }
            }*/


            lista = context.Posts.ToList();

            return lista;
        }

        public IList<Post> GetPost(string categoria)
        {
            IList<Post> lista = new List<Post>();
            lista = context.Posts.Where(x => x.Categoria.Contains(categoria)).ToList();
            return lista;
        }

        public Post GetPost(int id)
        {
            Post post = new Post();
            post = context.Posts.Find(id);
            return post;
        }

        public void InsertPost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();        
        }

        public void RemovePost(int id)
        {
            Post post = new Post() { Id = id };
            context.Entry(post).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void ViewPost(Post p)
        {
            Post post = new Post() { Id = p.Id };
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();            
        }

        public void UpdatePost(Post p)
        {
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void PublishPost(int id)
        {
            Post post = new Post()
            {
                Id = id,
                Publicado = true,
                DataPublicacao = DateTime.Now
            };
            context.Posts.Attach(post);
            context.Entry(post).Property(x => x.Publicado).IsModified = true;
            context.Entry(post).Property(x => x.DataPublicacao).IsModified = true;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
        }

        public IList<string> CategoriaAutoComplete(string caracteres)
        {
            IList<string> response;
            response = context.Posts.Where(post => post.Categoria.Contains(caracteres)).Select(post => post.Categoria).Distinct().ToList();

            return response;
        }

        public IList<Post> GetPublicados()
        {
            return context.Posts.Where(post => post.Publicado).ToList();
        }

        public IList<Post> BuscaPeloTermo(string termo)
        {
            return context.Posts
                .Where(post => post.Publicado && (post.Titulo.Contains(termo) || post.Resumo.Contains(termo)))
                .Select(post => post)
                .ToList();
        }
    }
}