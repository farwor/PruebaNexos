using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class TblAutor
    {
        public TblAutor()
        {
            TblLibros = new HashSet<TblLibro>();
        }

        public decimal IdAutor { get; set; }
        public string AutNombreCompleto { get; set; } = null!;
        public DateTime AutFchNacimiento { get; set; }
        public string AutCiudad { get; set; } = null!;
        public string AutCorreo { get; set; } = null!;

        public virtual ICollection<TblLibro> TblLibros { get; set; }
    }
}
