using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Departamento")]
public partial class Departamento
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int AreaId { get; set; }
    [ForeignKey("AreaId")]
    [InverseProperty("Departamentos")]
    public virtual Area Area { get; set; }

    [InverseProperty("Departamento")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
}
