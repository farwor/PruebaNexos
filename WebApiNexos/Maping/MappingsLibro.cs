using Datos.Models;
using DTOs;

namespace ApiNexos.WebAPI.Mappings
{
    public static partial class Mapper
    {

        /// <summary>
        /// Convierte de ModelContext a DTO
        /// </summary>
        /// <param name="model"></param>
        /// <returns>LibroDTO</returns>
        public static LibroDTO ToDTO(this TblLibro model) 
        {
            return new LibroDTO()
            {
                idLibro = model.IdLibro,
                lbrTitulo = model.LbrTitulo,
                lbrAnio = model.LbrAnio,
                LbrGenero = model.LbrGenero,
                lbrNumPag = model.LbrNumPag,
                idAutor = model.IdAutor

            };
        }
    }

    public static partial class Mapper
    {

        /// <summary>
        /// Convierte de DTO a ModelContext
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>TblLibro</returns>
        public static TblLibro ToDatabase(this LibroDTO dto)
        {
            return new TblLibro()
            {
                IdLibro = dto.idLibro,
                LbrTitulo = dto.lbrTitulo,
                LbrAnio = dto.lbrAnio,
                LbrGenero = dto.LbrGenero,
                LbrNumPag = dto.lbrNumPag,
                IdAutor = dto.idAutor
            };
        }
    }
}