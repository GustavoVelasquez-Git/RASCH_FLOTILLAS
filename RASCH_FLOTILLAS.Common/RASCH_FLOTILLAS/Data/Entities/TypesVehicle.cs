using System.ComponentModel.DataAnnotations;

namespace RASCH_FLOTILLAS.Data.Entities
{
    public class TypesVehicle
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Vehiculo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
    }
}

