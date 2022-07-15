using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LibroDTO
    {
        public decimal idLibro { get; set; }
        public string lbrTitulo { get; set; } = null!;
        public string lbrAnio { get; set; } = null!;
        public string LbrGenero { get; set; } = null!;
        public decimal lbrNumPag { get; set; }
        public decimal? idAutor { get; set; }
    }
}
