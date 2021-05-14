using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRESTFULL_paises.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Descripcion es Obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Capital es Obligatoria")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Capital")]
        public string Capital { get; set; }
    }
}
