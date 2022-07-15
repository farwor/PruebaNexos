using Datos.Models;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicios.Autor;
using WebApiNexos.Mappings;

namespace WebApiNexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : Controller
    {
        private readonly IAutorService _servicio;

        public AutorController(IAutorService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Listar()
        {
            var retorno = await _servicio.Listar();
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperAutor.ToDTO).ToList(); //OrderByDescending(id);
            else
                return StatusCode(retorno.Estado, retorno.Error);

        }

        [HttpGet("{id}")] //Eliminar carga al controlador
        public async Task<ActionResult<TblAutor>> GetById(int id)
        {
            var retorno = await _servicio.GetById(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO().ToDatabase();
            else
                return StatusCode(retorno.Estado, retorno.Error);

        }

        [HttpPost]
        public async Task<ActionResult<AutorDTO>> Guardar(AutorDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<AutorDTO>> Actualizar(AutorDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            var retorno = await _servicio.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }
    }
}
