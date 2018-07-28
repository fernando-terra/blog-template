using Blog.Models;
using System.Data.Entity;
using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Infra
{
    public class BlogContext : IdentityDbContext
    { 
        public BlogContext() : base("name = blog") { }

        public DbSet<Post> Posts { get; set; }
    }
}