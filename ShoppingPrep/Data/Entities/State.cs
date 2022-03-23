using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingPrep.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Região/Estado")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} carateres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }


        [JsonIgnore]
        public Country Country { get; set; }


        public ICollection<City> Cities { get; set; }


        [Display(Name = "Cidades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
