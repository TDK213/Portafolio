using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace trabajopalacasa.Models.ViewModels
{
    public class SoliViewModels
    {
        public string Mensaje { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo_solicitud { get; set; }
        public string Estado { get; set; }
        public string Remitente { get; set; }
        public DateTime Fecha { get; set; }

    }

    public class NuevaSolicitud
    {
        [Required]
        [Display(Name = "Titulo Solicitud")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Tipo Solicitud")]
        public string Tipo_solicitud { get; set; }
        [Required]
        [StringLength(700, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 20)]
        [Display(Name = "Mensaje de la Solicitud")]
        public string Mensaje { get; set; }
    }

    public class EditarSolicitud
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titulo Solicitud")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Tipo Solicitud")]
        public string Tipo_solicitud { get; set; }
        [Required]
        [StringLength(700, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 20)]
        [Display(Name = "Mensaje de la Solicitud")]
        public string Mensaje { get; set; }
    }
    public class MostrarSolicitud
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Remitente { get; set; }
        public string Tipo_solicitud { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}