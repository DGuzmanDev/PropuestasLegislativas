using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PropuestasLegislativas.Pages
{
    [BindProperties]
    public class RegistroNuevaPropuestaModel : PageModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3, ErrorMessage = "El nombre del empresa debe ser al menos de 3 caracteres")]
        public String? Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [MinLength(2, ErrorMessage = "Los apellidos deben tener al menos 2 caracteres")]
        public String? Apellidos { get; set; }

        public String[] TiposIdentificacion = { "Nacional", "DIMEX" };

        [Required(ErrorMessage = "El tipo de identificacion es requerido")]
        public String? TipoIdentificacion { get; set; }

        //Esto es en base al tipo de identificacion
        [Required(ErrorMessage = "La identificación es requerida")]
        [MinLength(10, ErrorMessage = "La identificación debe tener al menos 10 caracteres")]
        [MaxLength(10, ErrorMessage = "La identificación debe tener máximo 12 caracteres")]
        public String? Identificacion { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido")]
        [MinLength(8, ErrorMessage = "El número de teléfono debe tener al menos 8 dígitos")]
        public String? Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [MinLength(3, ErrorMessage = "El correo electrónico debe tener al menos 3 caracteres")]
        public String? Correo { get; set; }

        [Required(ErrorMessage = "La provincia es requerida")]
        public String? Provincia { get; set; }

        [Required(ErrorMessage = "El cantón es requerido")]
        public String? Canton { get; set; }

        [Required(ErrorMessage = "La propuesta es requerida")]
        [MinLength(50, ErrorMessage = "La propuesta debe tener al menos 50 caracteres y máximo 200 caracteres")]
        [MaxLength(200, ErrorMessage = "La propuesta debe tener un maximo un 200 caracteres")]
        public String? Propuesta { get; set; }
    }
}
