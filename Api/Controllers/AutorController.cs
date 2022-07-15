using DTOs;
using Microsoft.AspNetCore.Mvc;
using Servicios.Autor;
using Api.Maping;
using Datos.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private IAutorService _srvAutor;

        public AutorController(IAutorService servicio)
        {
            _srvAutor = servicio;
        }

        // GET: api/<AutorController>
        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Listar()
        {
            var retorno = await _srvAutor.Listar();
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperAutor.ToDTO).ToList();
            else
                return StatusCode(retorno.Estado, retorno.Error);

        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAutor>> GetById(int id)
        {
            var retorno = await _srvAutor.GetById(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO().ToDatabase();
            else
                return StatusCode(retorno.Estado, retorno.Error);

        }

        [HttpPost]
        public async Task<ActionResult<AutorDTO>> Guardar(AutorDTO c)
        {
            var retorno = await _srvAutor.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<AutorDTO>> Actualizar(AutorDTO c)
        {
            var retorno = await _srvAutor.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            var retorno = await _srvAutor.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Estado, retorno.Error);
        }
    }
}
