using System.ComponentModel.DataAnnotations;

namespace ShoppingPrep.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }


        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }


        [Display(Name = "Regiões/Estados")]
        public ICollection<State> States { get; set; }


        [Display(Name = "Regiões/Estados")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
