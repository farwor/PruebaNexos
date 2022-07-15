using System.ComponentModel.DataAnnotations;

namespace WebApp.Entity
{
    public class LibroEntity
    {
        [Display(Name = "Id Libro")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idLibro { get; set; }
        [Required(ErrorMessage = "El Tìtulo es obligatorio")]
        [Display(Name = "Titulo del libro")]
        public string lbrTitulo { get; set; }
        [Required(ErrorMessage = "El Año es obligatorio")]
        [Display(Name = "Año del libro")]
        public string lbrAnio { get; set; }
        [Required(ErrorMessage = "El Genero del libro es obligatorio")]
        [Display(Name = "Genero del libro")]
        public string LbrGenero { get; set; }
        [Required(ErrorMessage = "El Nùmero de pàginas obligatorio")]
        [Display(Name = "N° Páginas")]
        public int lbrNumPag { get; set; }
        [Display(Name = "Autor id")]
        public int? idAutor { get; set; }
    }
}
