using System.ComponentModel.DataAnnotations;

namespace ShoppingPrep.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Região/Estado")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }


        public int CountryId { get; set; } 
    }
}
