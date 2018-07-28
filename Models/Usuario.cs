using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime? UltimoAcesso { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}