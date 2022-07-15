using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Libro
{
    public interface ILibroService
    {
        Task<RespuestaServicio<List<TblLibro>>> Listar();

        Task<RespuestaServicio<TblLibro>> GetById(int id);

        Task<RespuestaServicio<TblLibro>> Guardar(TblLibro c);

        Task<RespuestaServicio<TblLibro>> Actualizar(TblLibro c);

        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
