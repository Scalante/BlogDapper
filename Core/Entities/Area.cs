using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Area")]
public  class Area
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }

    [InverseProperty("Area")]
    public virtual ICollection<Departamento> Departamentos { get; set; } = new HashSet<Departamento>();
}
