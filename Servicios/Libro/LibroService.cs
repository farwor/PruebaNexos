using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Libro
{
    /// <summary>
    /// Se implementa la interfaz del servicio
    /// </summary>
    /// 
    public class LibroService : ILibroService
    {
        private ModelContext _context;

        public LibroService(ModelContext context)
        {
            _context = context;
        }
        
        public async Task<RespuestaServicio<TblLibro>> Actualizar(TblLibro l)
        {
            var res = new RespuestaServicio<TblLibro>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == l.IdLibro);

            if (Libro == null)
                res.AgregarBadRequest("El id del libro ingresado no está creado");
            else
            {
                Libro.LbrTitulo = l.LbrTitulo;
                Libro.LbrAnio = l.LbrAnio;
                Libro.LbrGenero = l.LbrGenero;
                Libro.LbrNumPag = l.LbrNumPag;

                try
                {
                    _context.TblLibros.Update(Libro);
                    await _context.SaveChangesAsync();

                    res.Objeto = Libro;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaServicio<TblLibro>> GetById(int id)
        {
            var res = new RespuestaServicio<TblLibro>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id del libro ingresado no está creado");
            else
                res.Objeto = Libro;

            return res;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var res = new RespuestaServicio<bool>();
            var Libro = await _context.TblLibros.FirstOrDefaultAsync(x => x.IdLibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id del libro ingresado no está creado");
            else
            {
                try
                {
                    _context.TblLibros.Remove(Libro);
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

        public async Task<RespuestaServicio<TblLibro>> Guardar(TblLibro c)
        {
            var res = new RespuestaServicio<TblLibro>();

            try
            {
                await _context.TblLibros.AddAsync(c);
                await _context.SaveChangesAsync();
                c.IdLibro = await _context.TblLibros.MaxAsync(u => u.IdLibro);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError("El autor no esta registrado");
            }

            return res;
        }

        public async Task<RespuestaServicio<List<TblLibro>>> Listar()
        {
            var res = new RespuestaServicio<List<TblLibro>>();
            var lista = await _context.TblLibros.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error interno");

            return res;
        }
    }
}
