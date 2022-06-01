using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using RASCH_FLOTILLAS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace RASCH_FLOTILLAS.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Business Business { get; set; }


        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:5001/images/sinfoto.png"
            : $"https://proyectoe.blob.core.windows.net/user/{ImageId}";    

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [JsonIgnore]
        public ICollection<Business> Busines { get; set; }

    }
}