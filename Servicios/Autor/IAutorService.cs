using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Autor
{
    public interface IAutorService
    {
        Task<RespuestaServicio<List<TblAutor>>> Listar();

        Task<RespuestaServicio<TblAutor>> GetById(int id);

        Task<RespuestaServicio<TblAutor>> Guardar(TblAutor c);

        Task<RespuestaServicio<TblAutor>> Actualizar(TblAutor c);

        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
