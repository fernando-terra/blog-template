namespace Blog.Migrations
{
    using Blog.Infra;
    using Blog.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("admin");
            Usuario usuarioAdmin = new Usuario()
            {
                UserName = "admin",
                PasswordHash = password,
                UltimoAcesso = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(u => u.UserName, usuarioAdmin);
        }
    }
}
