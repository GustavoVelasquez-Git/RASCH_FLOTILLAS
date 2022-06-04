using System.ComponentModel.DataAnnotations;

namespace RASCH_FLOTILLAS.Data.Entities
{
    public class Brands
    {
        public int Id { get; set; }

        [Display(Name = "Marcas")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
    }
}
