using Core.Dtos;
using Core.Interfaces;

namespace Api
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/publicaciones", ObtenerPublicaciones);
            app.MapGet("/publicacion/{id}", ObtenerPublicacion);
            app.MapPost("/publicaciones", AgregarPublicacion);
            app.MapPut("/publicaciones/{id}", ActualizarPublicacion);
            app.MapDelete("/publicaciones/{id}", EliminarPublicacion);
        }

        private static async Task<IResult> EliminarPublicacion(IPublicacionRepository publicacionRepository, int id)
        {
            try
            {
                var publicacionBd = await publicacionRepository.GetPublicacion(id);
                if (publicacionBd is null)
                {
                    return Results.NotFound();
                }

                await publicacionRepository.DeletePublicacion(id);
                return Results.NoContent();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> ActualizarPublicacion(IPublicacionRepository publicacionRepository, int id, UpsertPublicacionDto publicacionDto)
        {
            try
            {
                var publicacionBd = await publicacionRepository.GetPublicacion(id);
                if (publicacionBd is null)
                {
                    return Results.NotFound();
                }

                await publicacionRepository.UpdatePublicacion(id, publicacionDto);
                return Results.NoContent();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> AgregarPublicacion(IPublicacionRepository publicacionRepository, UpsertPublicacionDto publicacionDto)
        {
            try
            {
                var publicacionBd = await publicacionRepository.CreatePublicacion(publicacionDto);
                return Results.Created($"/publicaciones/{publicacionBd.Id}", publicacionBd);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> ObtenerPublicaciones(IPublicacionRepository publicacionRepository)
        {
            try
            {
                return Results.Ok(await publicacionRepository.GetPublicaciones());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> ObtenerPublicacion(IPublicacionRepository publicacionRepository, int id)
        {
            try
            {
                var publicacion = await publicacionRepository.GetPublicacion(id);
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
    }
}
