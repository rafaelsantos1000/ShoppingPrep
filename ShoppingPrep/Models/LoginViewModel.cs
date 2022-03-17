using System.ComponentModel.DataAnnotations;

namespace ShoppingPrep.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Deves inserir email válido.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Palavra-passe")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no máximo {1} carateres.")]
        public string Password { get; set; }

        [Display(Name = "Relembra-me neste browser")]
        public bool RememberMe { get; set; }
    }
}
