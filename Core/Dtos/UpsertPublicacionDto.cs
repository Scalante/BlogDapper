using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UpsertPublicacionDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Contenido { get; set; }
        public string Etiquetas { get; set; }
        public int UsuarioId { get; set; }
    }
}
