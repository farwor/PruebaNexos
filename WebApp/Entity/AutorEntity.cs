using System.ComponentModel.DataAnnotations;

namespace WebApp.Entity
{
    public class AutorEntity
    {
        [Display(Name = "Id Autor")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El Nombre Completo es obligatorio")]
        [Display(Name = "Nombre completo")]
        public string AutNombreCompleto { get; set; }
        [Required(ErrorMessage = "La Fecha Nacimiento es obligatoria en Formato dd/mm/aaaa")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime AutFchNacimiento { get; set; }
        [Required(ErrorMessage = "La Ciudad de procedencia es obligatoria")]
        [Display(Name = "Ciudad de procedencia")]
        public string AutCiudad { get; set; }
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        public string AutCorreo { get; set; }

    }
}
