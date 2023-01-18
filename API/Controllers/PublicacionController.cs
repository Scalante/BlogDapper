using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {

        private readonly IPublicacionRepository _publicacionRepository;

        public PublicacionController(IPublicacionRepository publicacionRepository)
        {
            this._publicacionRepository = publicacionRepository;
        }

        [HttpGet]
        public async Task<IResult> ObtenerPublicaciones()
        {
            try
            {
                return Results.Ok(await _publicacionRepository.GetPublicaciones());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IResult> ObtenerPublicacion(int id)
        {
            try
            {
                var publicacion = await _publicacionRepository.GetPublicacion(id);
                if (publicacion == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(publicacion);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        /// <summary>
        /// Método que permite actualizar una publicación por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publicacionDto"></param>
        /// <returns>Retorna un status 204</returns>
        [HttpPut("{id:int}")]
        public async Task<IResult> ActualizarPublicacion(int id, UpsertPublicacionDto publicacionDto)
        {
            try
            {
                var publicacionBd = await _publicacionRepository.GetPublicacion(id);
                if (publicacionBd is null)
                {
                    return Results.NotFound();
                }

                await _publicacionRepository.UpdatePublicacion(id, publicacionDto);
                return Results.NoContent();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IResult> EliminarPublicacion(int id)
        {
            try
            {
                var publicacionBd = await _publicacionRepository.GetPublicacion(id);
                if (publicacionBd is null)
                {
                    return Results.NotFound();
                }

                await _publicacionRepository.DeletePublicacion(id);
                return Results.NoContent();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
