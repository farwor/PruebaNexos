using ApiNexos.WebAPI.Mappings;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Servicios.Libro;

namespace WebApiNexos.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _servicio;

        public LibroController(ILibroService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet] //Eliminar carga al controlador
        public async Task<ActionResult<List<LibroDTO>>> Listar()
        {
            var retorno = await _servicio.Listar();
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }



        [HttpGet("{id}")]  //Eliminar carga al controlador
        public async Task<ActionResult<LibroDTO>> GetById(int id)
        {
            var retorno = await _servicio.GetById(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDTO>> Guardar(LibroDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<LibroDTO>> Actualizar(LibroDTO c)
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
