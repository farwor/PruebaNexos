using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class RespuestaServicio<T>
    {   
        public RespuestaServicio()
        {
            Estado = 200;
        }

        public T? Objeto { get; set; }
        public string? Error { get; set; }
        public int Estado { get; set; }
        public bool Exito { get; set; }
        //agregar respuestas a los controladores 
        public void AgregarBadRequest(string mensaje)
        {
            Estado = 400;
            Error = mensaje;
        }

        public void AgregarInternalServerError(string mensaje)
        {
            Estado = 500;
            Error = mensaje;
        }
    }
}