using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Publicacion")]
public partial class Publicacion
{
    [Key]
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Resumen { get; set; }

    public string Contenido { get; set; }

    public string Etiquetas { get; set; }

    public int? UsuarioId { get; set; }

    [InverseProperty("Publicacion")]
    public virtual ICollection<Comentario> Comentarios { get; } = new HashSet<Comentario>();

    //[ForeignKey("UsuarioId")]
    //[InverseProperty("Publicaciones")]
    ////public virtual Usuario? Usuario { get; set; }
}
