﻿using Core.Dtos;
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
    public class PublicacionRepository : IPublicacionRepository
    {
        private readonly DapperContext _context;

        public PublicacionRepository(DapperContext context)
        {
            this._context= context;
        }

        public async Task<Publicacion> CreatePublicacion(UpsertPublicacionDto publicacionDto)
        {
            var query = @"INSERT INTO Publicacion (Titulo, Resumen, Contenido, Etiquetas,UsuarioId)
                                VALUES(@Titulo,@Resumen,@Contenido,@Etiquetas,@UsuarioId);
                                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("Titulo", publicacionDto.Titulo, DbType.String);
            parameters.Add("Resumen", publicacionDto.Resumen, DbType.String);
            parameters.Add("Contenido", publicacionDto.Contenido, DbType.String);
            parameters.Add("Etiquetas", publicacionDto.Etiquetas, DbType.String);
            parameters.Add("UsuarioId", publicacionDto.UsuarioId, DbType.Int32);
            using var connection = _context.CreateConnection();
            var id = await connection.QueryFirstAsync<int>(query, parameters);
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
            var query = "DELETE FROM Publicacion WHERE Id=@Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { id });
        }

        public async Task<Publicacion> GetPublicacion(int id)
        {
            var query = "SELECT * FROM Publicacion WHERE Id=@Id";
            using var connection = _context.CreateConnection();
            var publicacion = await connection.QuerySingleOrDefaultAsync<Publicacion>(query, new {id});
            return publicacion;

        }

        public async Task<IEnumerable<Publicacion>> GetPublicaciones()
        {
            var query = "SELECT * FROM Publicacion";
            using var connection = _context.CreateConnection();
            var publicaciones = await connection.QueryAsync<Publicacion>(query);
            return publicaciones;
        }

        public async Task UpdatePublicacion(int id,UpsertPublicacionDto publicacionDto)
        {
            var query = @"UPDATE Publicacion SET Titulo=@Titulo, Resumen=@Resumen,
                        Contenido=@Contenido, Etiquetas=@Etiquetas WHERE Id=@Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", publicacionDto.Id, DbType.Int32);
            parameters.Add("Titulo", publicacionDto.Titulo, DbType.String);
            parameters.Add("Resumen", publicacionDto.Resumen, DbType.String);
            parameters.Add("Contenido", publicacionDto.Contenido, DbType.String);
            parameters.Add("Etiquetas", publicacionDto.Etiquetas, DbType.String);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
