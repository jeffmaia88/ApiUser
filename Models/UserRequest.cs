using API.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "O Campo precisa ter ao menos 3 caracteres")]
        public string Nome { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "O Campo precisa ter ao menos 3 caracteres")]
        public string Sobrenome { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "O Campo precisa ter ao menos 11 caracteres")]
        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
