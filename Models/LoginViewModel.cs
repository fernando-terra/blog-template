using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]      
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}