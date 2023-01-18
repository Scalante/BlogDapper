using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PublicacionRepositorySP : IPublicacionRepository
    {
        private readonly DapperContext _context;

        public PublicacionRepositorySP(DapperContext context)
        {
            this._context = context;
        }

        public async Task<Publicacion> CreatePublicacion(UpsertPublicacionDto publicacionDto)
        {
            var storedProcedureName = "spCreatePublicacion";
            var parameters = new DynamicParameters();
            parameters.Add("Id", publicacionDto.Id, DbType.Int32, direction:ParameterDirection.Output);
            parameters.Add("Titulo", publicacionDto.Titulo, DbType.String);
            parameters.Add("Resumen", publicacionDto.Resumen, DbType.String);
            parameters.Add("Contenido", publicacionDto.Contenido, DbType.String);
            parameters.Add("Etiquetas", publicacionDto.Etiquetas, DbType.String);
            parameters.Add("UsuarioId", publicacionDto.UsuarioId, DbType.Int32);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(storedProcedureName, parameters, commandType:CommandType.StoredProcedure);
            var id = parameters.Get<int>("@Id");
            return new Publicacion
            {
                Id = id,
                Contenido = publicacionDto.Contenido,
                Etiquetas = publicacionDto.Etiquetas,
                Resumen = publicacionDto.Resumen,
                Titulo = publicacionDto.Titulo,
                UsuarioId = publicacionDto.UsuarioId
            };
        }

        public async Task DeletePublicacion(int id)
        {
            var storedProcedureName = "spDeletePublicacion";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(storedProcedureName, new { id }, commandType:CommandType.StoredProcedure);
        }

        public async Task<Publicacion> GetPublicacion(int id)
        {
            var storedProcedureName = "spGetPublicacion";
            using var connection = _context.CreateConnection();
            var publicacion = await connection.QuerySingleOrDefaultAsync<Publicacion>(storedProcedureName, new { id }, 
                commandType: CommandType.StoredProcedure);
            return publicacion;
        }

        public async Task<IEnumerable<Publicacion>> GetPublicaciones()
        {
            var storedProcedureName = "spGetAllPublicacion";
            using var connection = _context.CreateConnection();
            var publicaciones = await connection.QueryAsync<Publicacion>(storedProcedureName, null, commandType: CommandType.StoredProcedure);
            return publicaciones;
        }

        public async Task UpdatePublicacion(int id, UpsertPublicacionDto publicacionDto)
        {
            var storedProcedureName = "spUpdatePublicacion";
            var parameters = new DynamicParameters();
            parameters.Add("Id", publicacionDto.Id, DbType.Int32);
            parameters.Add("Titulo", publicacionDto.Titulo, DbType.String);
            parameters.Add("Resumen", publicacionDto.Resumen, DbType.String);
            parameters.Add("Contenido", publicacionDto.Contenido, DbType.String);
            parameters.Add("Etiquetas", publicacionDto.Etiquetas, DbType.String);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
