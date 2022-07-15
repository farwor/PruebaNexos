using System;
using System.Collections.Generic;

namespace Datos.Models
{
    public partial class TblLibro
    {
        public decimal IdLibro { get; set; }
        public string LbrTitulo { get; set; } = null!;
        public string LbrAnio { get; set; } = null!;
        public string LbrGenero { get; set; } = null!;
        public decimal LbrNumPag { get; set; }
        public decimal? IdAutor { get; set; }

        public virtual TblAutor? IdAutorNavigation { get; set; }
    }
}
