using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Autor
{
    
    /// <summary>
    /// Se implementa la interfaz del servicio
    /// </summary>
    /// 

    public class AutorService : IAutorService
    {
        private ModelContext _context;

        public AutorService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaServicio<TblAutor>> Actualizar(TblAutor l)
        {
            var res = new RespuestaServicio<TblAutor>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == l.IdAutor);

            if (Autor == null)
                res.AgregarBadRequest("El id del autor ingresado no está creado");
            else
            {
                Autor.AutNombreCompleto = l.AutNombreCompleto;
                Autor.AutFchNacimiento = l.AutFchNacimiento;
                Autor.AutCiudad = l.AutCiudad;
                Autor.AutCorreo = l.AutCorreo;

                try
                {
                    _context.TblAutors.Update(Autor);
                    await _context.SaveChangesAsync();

                    res.Objeto = Autor;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaServicio<TblAutor>> GetById(int id)
        {
            var res = new RespuestaServicio<TblAutor>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == id);

            if (Autor == null)
                res.AgregarBadRequest("El id del autor ingresado no está creado");
            else
                res.Objeto = Autor;

            return res;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var res = new RespuestaServicio<bool>();
            var Autor = await _context.TblAutors.FirstOrDefaultAsync(x => x.IdAutor == id);

            if (Autor == null)
                res.AgregarBadRequest("El id del autor ingresado no está creado");
            else
            {
                try
                {
                    _context.TblAutors.Remove(Autor);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaServicio<TblAutor>> Guardar(TblAutor c)
        {
            var res = new RespuestaServicio<TblAutor>();

            try
            {
                await _context.TblAutors.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdAutor = await _context.TblAutors.MaxAsync(u => u.IdAutor);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaServicio<List<TblAutor>>> Listar()
        {
            var res = new RespuestaServicio<List<TblAutor>>();
            var lista = await _context.TblAutors.ToListAsync();
            
            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error interno");

            return res;
        }
    }
}
