using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AutorDTO
    {
        public decimal IdAutor { get; set; }
        public string AutNombreCompleto { get; set; } = null!;
        public DateTime AutFchNacimiento { get; set; }
        public string AutCiudad { get; set; } = null!;
        public string AutCorreo { get; set; } = null!;
    }
}
