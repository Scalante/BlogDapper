using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Perfil")]
public partial class Perfil
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }

    [InverseProperty("Perfil")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
}
