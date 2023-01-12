using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Apellidos { get; set; }

    public string Email { get; set; }

    public string Contrasena { get; set; }

    public int PerfilId { get; set; }

    public int DepartamentoId { get; set; }

    [ForeignKey("DepartamentoId")]
    [InverseProperty("Usuarios")]
    public virtual Departamento Departamento { get; set; }

    [ForeignKey("PerfilId")]
    [InverseProperty("Usuarios")]
    public virtual Perfil Perfil { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new HashSet<Publicacion>();
}
