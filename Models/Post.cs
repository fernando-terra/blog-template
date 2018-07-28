using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")][MaxLength(50)][Display(Name ="Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")][Display(Name ="Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")][Display(Name ="Resumo")]
        public string Resumo { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public bool Publicado { get; set; }

        public virtual Usuario Autor { get; set; }
    }
}