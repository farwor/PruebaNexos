using Datos.Models;
using DTOs;

namespace WebApiNexos.Mappings
{
    public static partial class MapperAutor
    {

        /// <summary>
        /// Convierte de ModelContext a DTO
        /// </summary>
        /// <param name="model"></param>
        /// <returns>AutorDTO</returns>
        public static AutorDTO ToDTO(this TblAutor model)
        {
            return new AutorDTO()
            {
                IdAutor = model.IdAutor,
                AutNombreCompleto = model.AutNombreCompleto,
                AutFchNacimiento = model.AutFchNacimiento,
                AutCiudad = model.AutCiudad,
                AutCorreo = model.AutCorreo,

            };
        }
    }

    public static partial class MapperAutor
    {

        /// <summary>
        /// Convierte de DTO a ModelContext
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>TblAutor</returns>
        public static TblAutor ToDatabase(this AutorDTO dto)
        {
            return new TblAutor()
            {
                IdAutor = dto.IdAutor,
                AutNombreCompleto = dto.AutNombreCompleto,
                AutFchNacimiento = dto.AutFchNacimiento,
                AutCiudad = dto.AutCiudad,
                AutCorreo = dto.AutCorreo,

            };
        }
    }
}