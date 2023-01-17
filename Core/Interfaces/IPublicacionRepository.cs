using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPublicacionRepository
    {
        public Task<IEnumerable<Publicacion>> GetPublicaciones();
        public Task<Publicacion> GetPublicacion(int id);
        public Task<Publicacion> CreatePublicacion(UpsertPublicacionDto publicacionDto);
        public Task UpdatePublicacion(int id, UpsertPublicacionDto publicacionDto);
        public Task DeletePublicacion(int id);


    }
}
