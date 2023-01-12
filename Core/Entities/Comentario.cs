using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Comentario")]
public partial class Comentario
{
    [Key]
    public int Id { get; set; }

    public string Asunto { get; set; }

    public string Email { get; set; }

    public string Contenido { get; set; }

    public bool Aprobado { get; set; }

    public bool EsVisible => Aprobado == true ? true : false;

    //public int? PublicacionId { get; set; }

    //[ForeignKey("PublicacionId")]
    //[InverseProperty("Comentarios")]
    //public virtual Publicacion Publicacion { get; set; }
}
